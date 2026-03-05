using CyberQuiz.Application.Interfaces;
using CyberQuiz.Application.Services;
using CyberQuiz.Infrastructure.Entities;
using CyberQuiz.Infrastructure.Repositories;
using CyberQuiz.Shared.DTOs.Catalog;
using CyberQuiz.Shared.DTOs.Progress;
using CyberQuiz.Shared.DTOs.Quiz;
using Moq;

namespace CyberQuiz.Tests;

public class QuizServiceTests
{
    private readonly Mock<ICategoryRepository> _categoryRepoMock;
    private readonly Mock<ISubCategoryRepository> _subCategoryRepoMock;
    private readonly Mock<IQuestionRepository> _questionRepoMock;
    private readonly Mock<IAnswerRepository> _answerRepoMock;
    private readonly Mock<IUserResultRepository> _userResultRepoMock;
    private readonly Mock<IProgressCalculator> _progressMock;
    private readonly QuizService _sut;

    public QuizServiceTests()
    {
        _categoryRepoMock = new Mock<ICategoryRepository>();
        _subCategoryRepoMock = new Mock<ISubCategoryRepository>();
        _questionRepoMock = new Mock<IQuestionRepository>();
        _answerRepoMock = new Mock<IAnswerRepository>();
        _userResultRepoMock = new Mock<IUserResultRepository>();
        _progressMock = new Mock<IProgressCalculator>();

        _sut = new QuizService(
            _categoryRepoMock.Object,
            _subCategoryRepoMock.Object,
            _questionRepoMock.Object,
            _answerRepoMock.Object,
            _userResultRepoMock.Object,
            _progressMock.Object
        );
    }

    #region GetCategoriesForUserAsync Tests

    [Fact]
    public async Task GetCategoriesForUserAsync_ReturnsEmptyList_WhenNoCategoriesExist()
    {
        // Arrange
        var userId = "user123";
        _categoryRepoMock.Setup(x => x.GetAllCategoriesWithSubCategoriesAsync())
            .ReturnsAsync(new List<Category>());

        // Act
        var result = await _sut.GetCategoriesForUserAsync(userId);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetCategoriesForUserAsync_ReturnsCategories_WithCorrectLockingLogic()
    {
        // Arrange
        var userId = "user123";
        var categories = new List<Category>
        {
            new()
            {
                Id = 1,
                Name = "Category 1",
                SubCategories = new List<SubCategory>
                {
                    new() { Id = 1, Name = "Sub 1", OrderIndex = 1, CategoryId = 1 },
                    new() { Id = 2, Name = "Sub 2", OrderIndex = 2, CategoryId = 1 },
                    new() { Id = 3, Name = "Sub 3", OrderIndex = 3, CategoryId = 1 }
                }
            }
        };

        var progress1 = new SubCategoryProgressDto
        {
            SubCategoryId = 1,
            IsCompleted = true,
            PercentCorrect = 0.9m,
            TotalQuestions = 10
        };
        var progress2 = new SubCategoryProgressDto
        {
            SubCategoryId = 2,
            IsCompleted = false,
            PercentCorrect = 0.5m,
            TotalQuestions = 10
        };
        var progress3 = new SubCategoryProgressDto
        {
            SubCategoryId = 3,
            IsCompleted = false,
            PercentCorrect = 0m,
            TotalQuestions = 10
        };

        _categoryRepoMock.Setup(x => x.GetAllCategoriesWithSubCategoriesAsync())
            .ReturnsAsync(categories);
        _progressMock.Setup(x => x.GetSubCategoryProgressAsync(1, userId)).ReturnsAsync(progress1);
        _progressMock.Setup(x => x.GetSubCategoryProgressAsync(2, userId)).ReturnsAsync(progress2);
        _progressMock.Setup(x => x.GetSubCategoryProgressAsync(3, userId)).ReturnsAsync(progress3);

        // Act
        var result = await _sut.GetCategoriesForUserAsync(userId);

        // Assert
        Assert.Single(result);
        Assert.Equal(3, result[0].SubCategories.Count);
        
        // First subcategory should be unlocked
        Assert.False(result[0].SubCategories[0].IsLocked);
        Assert.True(result[0].SubCategories[0].IsCompleted);
        
        // Second subcategory should be unlocked (previous is completed)
        Assert.False(result[0].SubCategories[1].IsLocked);
        Assert.False(result[0].SubCategories[1].IsCompleted);
        
        // Third subcategory should be locked (previous is not completed)
        Assert.True(result[0].SubCategories[2].IsLocked);
        Assert.False(result[0].SubCategories[2].IsCompleted);
    }

    #endregion

    #region GetNextQuestionAsync Tests

    [Fact]
    public async Task GetNextQuestionAsync_ReturnsNull_WhenNoQuestionsExist()
    {
        // Arrange
        var subCategoryId = 1;
        var userId = "user123";
        _questionRepoMock.Setup(x => x.GetBySubCategoryAsync(subCategoryId))
            .ReturnsAsync(new List<Question>());

        // Act
        var result = await _sut.GetNextQuestionAsync(subCategoryId, userId);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetNextQuestionAsync_ReturnsFirstQuestion_WithAnswerOptions()
    {
        // Arrange
        var subCategoryId = 1;
        var userId = "user123";
        var questions = new List<Question>
        {
            new() { Id = 1, SubCategoryId = subCategoryId, Text = "Question 1", OrderIndex = 1 },
            new() { Id = 2, SubCategoryId = subCategoryId, Text = "Question 2", OrderIndex = 2 }
        };
        var answerOptions = new List<AnswerOption>
        {
            new() { Id = 1, Text = "Answer A", QuestionId = 1, IsCorrect = true },
            new() { Id = 2, Text = "Answer B", QuestionId = 1, IsCorrect = false },
            new() { Id = 3, Text = "Answer C", QuestionId = 1, IsCorrect = false }
        };

        _questionRepoMock.Setup(x => x.GetBySubCategoryAsync(subCategoryId))
            .ReturnsAsync(questions);
        _answerRepoMock.Setup(x => x.GetByQuestionIdAsync(1))
            .ReturnsAsync(answerOptions);

        // Act
        var result = await _sut.GetNextQuestionAsync(subCategoryId, userId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.QuestionId);
        Assert.Equal("Question 1", result.Text);
        Assert.Equal(3, result.AnswerOptions.Count);
        Assert.Equal("Answer A", result.AnswerOptions[0].Text);
        Assert.Equal("Answer B", result.AnswerOptions[1].Text);
        Assert.Equal("Answer C", result.AnswerOptions[2].Text);
    }

    #endregion

    #region SubmitAnswerAsync Tests

    [Fact]
    public async Task SubmitAnswerAsync_ThrowsException_WhenQuestionNotFound()
    {
        // Arrange
        var dto = new SubmitAnswerRequestDto
        {
            QuestionId = 999,
            SubCategoryId = 1,
            SelectedAnswerOptionId = 1
        };
        var userId = "user123";

        _questionRepoMock.Setup(x => x.GetByIdAsync(999))
            .ReturnsAsync((Question?)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(
            () => _sut.SubmitAnswerAsync(dto, userId));
        Assert.Contains("Question 999 not found", exception.Message);
    }

    [Fact]
    public async Task SubmitAnswerAsync_ThrowsException_WhenQuestionDoesNotBelongToSubCategory()
    {
        // Arrange
        var dto = new SubmitAnswerRequestDto
        {
            QuestionId = 1,
            SubCategoryId = 1,
            SelectedAnswerOptionId = 1
        };
        var userId = "user123";
        var question = new Question
        {
            Id = 1,
            SubCategoryId = 2, // Different subcategory
            Text = "Question"
        };

        _questionRepoMock.Setup(x => x.GetByIdAsync(1))
            .ReturnsAsync(question);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(
            () => _sut.SubmitAnswerAsync(dto, userId));
        Assert.Contains("does not belong to subcategory", exception.Message);
    }

    [Fact]
    public async Task SubmitAnswerAsync_ThrowsException_WhenAnswerOptionNotFound()
    {
        // Arrange
        var dto = new SubmitAnswerRequestDto
        {
            QuestionId = 1,
            SubCategoryId = 1,
            SelectedAnswerOptionId = 999
        };
        var userId = "user123";
        var question = new Question
        {
            Id = 1,
            SubCategoryId = 1,
            Text = "Question"
        };

        _questionRepoMock.Setup(x => x.GetByIdAsync(1))
            .ReturnsAsync(question);
        _answerRepoMock.Setup(x => x.GetByIdAsync(999))
            .ReturnsAsync((AnswerOption?)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(
            () => _sut.SubmitAnswerAsync(dto, userId));
        Assert.Contains("Answer option 999 not found", exception.Message);
    }

    [Fact]
    public async Task SubmitAnswerAsync_ReturnsCorrectResponse_WhenAnswerIsCorrect()
    {
        // Arrange
        var dto = new SubmitAnswerRequestDto
        {
            QuestionId = 1,
            SubCategoryId = 1,
            SelectedAnswerOptionId = 1
        };
        var userId = "user123";
        var question = new Question { Id = 1, SubCategoryId = 1, Text = "Question" };
        var selectedOption = new AnswerOption { Id = 1, IsCorrect = true, QuestionId = 1, Text = "Correct" };
        var allOptions = new List<AnswerOption> { selectedOption };
        var progress = new SubCategoryProgressDto
        {
            SubCategoryId = 1,
            TotalQuestions = 5,
            CorrectAttempts = 1,
            TotalAttempts = 1,
            PercentCorrect = 1.0m,
            HasAttemptedAllQuestions = false,
            IsCompleted = false
        };

        _questionRepoMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(question);
        _answerRepoMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(selectedOption);
        _answerRepoMock.Setup(x => x.GetByQuestionIdAsync(1)).ReturnsAsync(allOptions);
        _userResultRepoMock.Setup(x => x.AddAsync(It.IsAny<UserResult>())).Returns(Task.CompletedTask);
        _progressMock.Setup(x => x.GetSubCategoryProgressAsync(1, userId)).ReturnsAsync(progress);

        // Act
        var result = await _sut.SubmitAnswerAsync(dto, userId);

        // Assert
        Assert.True(result.IsCorrect);
        Assert.Equal(1, result.CorrectAnswerOptionId);
        Assert.NotNull(result.Progress);
        Assert.Equal(1, result.Progress.CorrectAttempts);
        
        // Verify that UserResult was saved
        _userResultRepoMock.Verify(x => x.AddAsync(It.Is<UserResult>(ur =>
            ur.UserId == userId &&
            ur.QuestionId == 1 &&
            ur.SubCategoryId == 1 &&
            ur.SelectedAnswerOptionId == 1 &&
            ur.IsCorrect == true
        )), Times.Once);
    }

    [Fact]
    public async Task SubmitAnswerAsync_ReturnsCorrectAnswerId_WhenAnswerIsIncorrect()
    {
        // Arrange
        var dto = new SubmitAnswerRequestDto
        {
            QuestionId = 1,
            SubCategoryId = 1,
            SelectedAnswerOptionId = 2
        };
        var userId = "user123";
        var question = new Question { Id = 1, SubCategoryId = 1, Text = "Question" };
        var selectedOption = new AnswerOption { Id = 2, IsCorrect = false, QuestionId = 1, Text = "Wrong" };
        var correctOption = new AnswerOption { Id = 1, IsCorrect = true, QuestionId = 1, Text = "Correct" };
        var allOptions = new List<AnswerOption> { correctOption, selectedOption };
        var progress = new SubCategoryProgressDto
        {
            SubCategoryId = 1,
            TotalQuestions = 5,
            CorrectAttempts = 0,
            TotalAttempts = 1,
            PercentCorrect = 0m,
            HasAttemptedAllQuestions = false,
            IsCompleted = false
        };

        _questionRepoMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(question);
        _answerRepoMock.Setup(x => x.GetByIdAsync(2)).ReturnsAsync(selectedOption);
        _answerRepoMock.Setup(x => x.GetByQuestionIdAsync(1)).ReturnsAsync(allOptions);
        _userResultRepoMock.Setup(x => x.AddAsync(It.IsAny<UserResult>())).Returns(Task.CompletedTask);
        _progressMock.Setup(x => x.GetSubCategoryProgressAsync(1, userId)).ReturnsAsync(progress);

        // Act
        var result = await _sut.SubmitAnswerAsync(dto, userId);

        // Assert
        Assert.False(result.IsCorrect);
        Assert.Equal(1, result.CorrectAnswerOptionId);
        Assert.NotNull(result.Progress);
        
        // Verify that incorrect answer was saved
        _userResultRepoMock.Verify(x => x.AddAsync(It.Is<UserResult>(ur =>
            ur.IsCorrect == false &&
            ur.SelectedAnswerOptionId == 2
        )), Times.Once);
    }

    #endregion
}