using CyberQuiz.Application.Interfaces;
using CyberQuiz.Application.Services;
using CyberQuiz.Infrastructure.Entities;
using CyberQuiz.Infrastructure.Repositories;
using CyberQuiz.Shared.DTOs.Quiz;
using CyberQuiz.Shared.DTOs.Progress;
using Moq;

namespace CyberQuiz.Tests.Services;

public class QuizServiceTests
{
    private readonly Mock<ICategoryRepository> _categoryRepoMock;
    private readonly Mock<ISubCategoryRepository> _subCategoryRepoMock;
    private readonly Mock<IQuestionRepository> _questionRepoMock;
    private readonly Mock<IAnswerRepository> _answerRepoMock;
    private readonly Mock<IUserResultRepository> _userResultRepoMock;
    private readonly Mock<IProgressCalculator> _progressMock;
    private readonly QuizService _sut; // System Under Test

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

    #region GetNextQuestionAsync Tests

    [Fact]
    public async Task GetNextQuestionAsync_WhenNoQuestionsExist_ReturnsNull()
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
    public async Task GetNextQuestionAsync_WhenAllQuestionsAnswered_ReturnsNull()
    {
        // Arrange
        var subCategoryId = 1;
        var userId = "user123";
        var questions = new List<Question>
        {
            new() { Id = 1, SubCategoryId = subCategoryId, Text = "Q1", OrderIndex = 1 },
            new() { Id = 2, SubCategoryId = subCategoryId, Text = "Q2", OrderIndex = 2 }
        };
        var userResults = new List<UserResult>
        {
            new() { QuestionId = 1, UserId = userId },
            new() { QuestionId = 2, UserId = userId }
        };

        _questionRepoMock.Setup(x => x.GetBySubCategoryAsync(subCategoryId))
            .ReturnsAsync(questions);
        _userResultRepoMock.Setup(x => x.GetBySubCategoryAsync(userId, subCategoryId))
            .ReturnsAsync(userResults);

        // Act
        var result = await _sut.GetNextQuestionAsync(subCategoryId, userId);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetNextQuestionAsync_WhenUnansweredQuestionExists_ReturnsFirstUnansweredQuestion()
    {
        // Arrange
        var subCategoryId = 1;
        var userId = "user123";
        var questions = new List<Question>
        {
            new() { Id = 1, SubCategoryId = subCategoryId, Text = "Q1", OrderIndex = 1 },
            new() { Id = 2, SubCategoryId = subCategoryId, Text = "Q2", OrderIndex = 2 },
            new() { Id = 3, SubCategoryId = subCategoryId, Text = "Q3", OrderIndex = 3 }
        };
        var userResults = new List<UserResult>
        {
            new() { QuestionId = 1, UserId = userId }
        };
        var answerOptions = new List<AnswerOption>
        {
            new() { Id = 1, Text = "Answer 1", QuestionId = 2, IsCorrect = true },
            new() { Id = 2, Text = "Answer 2", QuestionId = 2, IsCorrect = false }
        };

        _questionRepoMock.Setup(x => x.GetBySubCategoryAsync(subCategoryId))
            .ReturnsAsync(questions);
        _userResultRepoMock.Setup(x => x.GetBySubCategoryAsync(userId, subCategoryId))
            .ReturnsAsync(userResults);
        _answerRepoMock.Setup(x => x.GetByQuestionIdAsync(2))
            .ReturnsAsync(answerOptions);

        // Act
        var result = await _sut.GetNextQuestionAsync(subCategoryId, userId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.QuestionId);
        Assert.Equal("Q2", result.Text);
        Assert.Equal(2, result.AnswerOptions.Count);
        Assert.Equal("Answer 1", result.AnswerOptions[0].Text);
        Assert.Equal("Answer 2", result.AnswerOptions[1].Text);
    }

    [Fact]
    public async Task GetNextQuestionAsync_RespectsOrderIndex()
    {
        // Arrange
        var subCategoryId = 1;
        var userId = "user123";
        var questions = new List<Question>
        {
            new() { Id = 3, SubCategoryId = subCategoryId, Text = "Q3", OrderIndex = 3 },
            new() { Id = 1, SubCategoryId = subCategoryId, Text = "Q1", OrderIndex = 1 },
            new() { Id = 2, SubCategoryId = subCategoryId, Text = "Q2", OrderIndex = 2 }
        };
        var answerOptions = new List<AnswerOption>
        {
            new() { Id = 1, Text = "Answer 1", QuestionId = 1, IsCorrect = true }
        };

        _questionRepoMock.Setup(x => x.GetBySubCategoryAsync(subCategoryId))
            .ReturnsAsync(questions);
        _userResultRepoMock.Setup(x => x.GetBySubCategoryAsync(userId, subCategoryId))
            .ReturnsAsync(new List<UserResult>());
        _answerRepoMock.Setup(x => x.GetByQuestionIdAsync(1))
            .ReturnsAsync(answerOptions);

        // Act
        var result = await _sut.GetNextQuestionAsync(subCategoryId, userId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.QuestionId);
    }

    #endregion

    #region SubmitAnswerAsync Tests

    [Fact]
    public async Task SubmitAnswerAsync_WhenQuestionNotFound_ThrowsInvalidOperationException()
    {
        // Arrange
        var dto = new SubmitAnswerRequestDto
        {
            QuestionId = 1,
            SubCategoryId = 1,
            SelectedAnswerOptionId = 1
        };
        var userId = "user123";

        _questionRepoMock.Setup(x => x.GetByIdAsync(1))
            .ReturnsAsync((Question?)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(
            () => _sut.SubmitAnswerAsync(dto, userId));
        Assert.Contains("Question 1 not found", exception.Message);
    }

    [Fact]
    public async Task SubmitAnswerAsync_WhenQuestionDoesNotBelongToSubCategory_ThrowsInvalidOperationException()
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
            SubCategoryId = 2, // Different from dto.SubCategoryId
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
    public async Task SubmitAnswerAsync_WhenAnswerOptionNotFound_ThrowsInvalidOperationException()
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
            SubCategoryId = 1,
            Text = "Question"
        };

        _questionRepoMock.Setup(x => x.GetByIdAsync(1))
            .ReturnsAsync(question);
        _answerRepoMock.Setup(x => x.GetByIdAsync(1))
            .ReturnsAsync((AnswerOption?)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(
            () => _sut.SubmitAnswerAsync(dto, userId));
        Assert.Contains("Answer option 1 not found", exception.Message);
    }

    [Fact]
    public async Task SubmitAnswerAsync_WhenAnswerIsCorrect_ReturnsCorrectResponse()
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
        var selectedOption = new AnswerOption { Id = 1, IsCorrect = true, QuestionId = 1 };
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
        Assert.Equal(progress, result.Progress);
        _userResultRepoMock.Verify(x => x.AddAsync(It.Is<UserResult>(ur =>
            ur.UserId == userId &&
            ur.QuestionId == 1 &&
            ur.SubCategoryId == 1 &&
            ur.SelectedAnswerOptionId == 1 &&
            ur.IsCorrect == true
        )), Times.Once);
    }

    [Fact]
    public async Task SubmitAnswerAsync_WhenAnswerIsIncorrect_ReturnsCorrectAnswerId()
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
        var selectedOption = new AnswerOption { Id = 2, IsCorrect = false, QuestionId = 1 };
        var correctOption = new AnswerOption { Id = 1, IsCorrect = true, QuestionId = 1 };
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
        Assert.Equal(progress, result.Progress);
        _userResultRepoMock.Verify(x => x.AddAsync(It.Is<UserResult>(ur =>
            ur.IsCorrect == false
        )), Times.Once);
    }

    #endregion
}