using CyberQuiz.Application.Services;
using CyberQuiz.Infrastructure.Repositories;
using Moq;

namespace CyberQuiz.Tests;

public class ProgressCalculatorTests
{
    private readonly Mock<IQuestionRepository> _questionRepoMock;
    private readonly Mock<IUserResultRepository> _userResultRepoMock;
    private readonly ProgressCalculator _sut;

    public ProgressCalculatorTests()
    {
        _questionRepoMock = new Mock<IQuestionRepository>();
        _userResultRepoMock = new Mock<IUserResultRepository>();
        _sut = new ProgressCalculator(_questionRepoMock.Object, _userResultRepoMock.Object);
    }

    [Fact]
    public async Task GetSubCategoryProgressAsync_ReturnsZeroProgress_WhenNoQuestionsExist()
    {
        // Arrange
        var subCategoryId = 1;
        var userId = "user123";

        _questionRepoMock.Setup(x => x.CountQuestionsInSubCategoryAsync(subCategoryId))
            .ReturnsAsync(0);

        // Act
        var result = await _sut.GetSubCategoryProgressAsync(subCategoryId, userId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(subCategoryId, result.SubCategoryId);
        Assert.Equal(0, result.TotalQuestions);
        Assert.Equal(0, result.TotalAttempts);
        Assert.Equal(0, result.CorrectAttempts);
        Assert.Equal(0m, result.PercentCorrect);
        Assert.False(result.HasAttemptedAllQuestions);
        Assert.False(result.IsCompleted);
    }

    [Fact]
    public async Task GetSubCategoryProgressAsync_ReturnsCorrectProgress_WhenUserHasNotStarted()
    {
        // Arrange
        var subCategoryId = 1;
        var userId = "user123";

        _questionRepoMock.Setup(x => x.CountQuestionsInSubCategoryAsync(subCategoryId))
            .ReturnsAsync(10);
        _userResultRepoMock.Setup(x => x.CountTotalAnswersAsync(userId, subCategoryId))
            .ReturnsAsync(0);
        _userResultRepoMock.Setup(x => x.CountCorrectAnswersAsync(userId, subCategoryId))
            .ReturnsAsync(0);
        _userResultRepoMock.Setup(x => x.CountDistinctQuestionsAttemptedAsync(userId, subCategoryId))
            .ReturnsAsync(0);

        // Act
        var result = await _sut.GetSubCategoryProgressAsync(subCategoryId, userId);

        // Assert
        Assert.Equal(10, result.TotalQuestions);
        Assert.Equal(0, result.TotalAttempts);
        Assert.Equal(0, result.CorrectAttempts);
        Assert.Equal(0m, result.PercentCorrect);
        Assert.False(result.HasAttemptedAllQuestions);
        Assert.False(result.IsCompleted);
    }

    [Fact]
    public async Task GetSubCategoryProgressAsync_CalculatesPercentCorrect_Correctly()
    {
        // Arrange
        var subCategoryId = 1;
        var userId = "user123";

        _questionRepoMock.Setup(x => x.CountQuestionsInSubCategoryAsync(subCategoryId))
            .ReturnsAsync(10);
        _userResultRepoMock.Setup(x => x.CountTotalAnswersAsync(userId, subCategoryId))
            .ReturnsAsync(10);
        _userResultRepoMock.Setup(x => x.CountCorrectAnswersAsync(userId, subCategoryId))
            .ReturnsAsync(7);
        _userResultRepoMock.Setup(x => x.CountDistinctQuestionsAttemptedAsync(userId, subCategoryId))
            .ReturnsAsync(10);

        // Act
        var result = await _sut.GetSubCategoryProgressAsync(subCategoryId, userId);

        // Assert
        Assert.Equal(10, result.TotalQuestions);
        Assert.Equal(10, result.TotalAttempts);
        Assert.Equal(7, result.CorrectAttempts);
        Assert.Equal(0.7m, result.PercentCorrect);
        Assert.True(result.HasAttemptedAllQuestions);
        Assert.False(result.IsCompleted); // Not completed because less than 80%
    }

    [Fact]
    public async Task GetSubCategoryProgressAsync_MarksAsCompleted_WhenAtLeast80PercentCorrect()
    {
        // Arrange
        var subCategoryId = 1;
        var userId = "user123";

        _questionRepoMock.Setup(x => x.CountQuestionsInSubCategoryAsync(subCategoryId))
            .ReturnsAsync(10);
        _userResultRepoMock.Setup(x => x.CountTotalAnswersAsync(userId, subCategoryId))
            .ReturnsAsync(10);
        _userResultRepoMock.Setup(x => x.CountCorrectAnswersAsync(userId, subCategoryId))
            .ReturnsAsync(8);
        _userResultRepoMock.Setup(x => x.CountDistinctQuestionsAttemptedAsync(userId, subCategoryId))
            .ReturnsAsync(10);

        // Act
        var result = await _sut.GetSubCategoryProgressAsync(subCategoryId, userId);

        // Assert
        Assert.Equal(0.8m, result.PercentCorrect);
        Assert.True(result.HasAttemptedAllQuestions);
        Assert.True(result.IsCompleted); // Should be completed at exactly 80%
    }

    [Fact]
    public async Task GetSubCategoryProgressAsync_NotCompleted_WhenNotAllQuestionsAttempted()
    {
        // Arrange
        var subCategoryId = 1;
        var userId = "user123";

        _questionRepoMock.Setup(x => x.CountQuestionsInSubCategoryAsync(subCategoryId))
            .ReturnsAsync(10);
        _userResultRepoMock.Setup(x => x.CountTotalAnswersAsync(userId, subCategoryId))
            .ReturnsAsync(5);
        _userResultRepoMock.Setup(x => x.CountCorrectAnswersAsync(userId, subCategoryId))
            .ReturnsAsync(5);
        _userResultRepoMock.Setup(x => x.CountDistinctQuestionsAttemptedAsync(userId, subCategoryId))
            .ReturnsAsync(5); // Only 5 out of 10 attempted

        // Act
        var result = await _sut.GetSubCategoryProgressAsync(subCategoryId, userId);

        // Assert
        Assert.Equal(1.0m, result.PercentCorrect); // 100% correct on attempted
        Assert.False(result.HasAttemptedAllQuestions);
        Assert.False(result.IsCompleted); // Not completed because not all questions attempted
    }

    [Fact]
    public async Task GetSubCategoryProgressAsync_HandlesPerfectScore()
    {
        // Arrange
        var subCategoryId = 1;
        var userId = "user123";

        _questionRepoMock.Setup(x => x.CountQuestionsInSubCategoryAsync(subCategoryId))
            .ReturnsAsync(10);
        _userResultRepoMock.Setup(x => x.CountTotalAnswersAsync(userId, subCategoryId))
            .ReturnsAsync(10);
        _userResultRepoMock.Setup(x => x.CountCorrectAnswersAsync(userId, subCategoryId))
            .ReturnsAsync(10);
        _userResultRepoMock.Setup(x => x.CountDistinctQuestionsAttemptedAsync(userId, subCategoryId))
            .ReturnsAsync(10);

        // Act
        var result = await _sut.GetSubCategoryProgressAsync(subCategoryId, userId);

        // Assert
        Assert.Equal(1.0m, result.PercentCorrect);
        Assert.True(result.HasAttemptedAllQuestions);
        Assert.True(result.IsCompleted);
    }
}