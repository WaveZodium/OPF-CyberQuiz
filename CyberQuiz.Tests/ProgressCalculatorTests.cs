using CyberQuiz.Application.Services;
using CyberQuiz.Infrastructure.Data;
using CyberQuiz.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CyberQuiz.Tests;

public class ProgressCalculatorTests
{
    private ApplicationDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Unik DB per test
            .Options;

        return new ApplicationDbContext(options);
    }

    [Fact]
    public async Task GetSubCategoryProgressAsync_NoQuestions_ReturnsZeroProgress()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var calculator = new ProgressCalculator(context);

        // Act
        var result = await calculator.GetSubCategoryProgressAsync(999, "user1");

        // Assert
        Assert.Equal(0, result.TotalQuestions);
        Assert.Equal(0, result.TotalAttempts);
        Assert.False(result.IsCompleted);
    }

    [Fact]
    public async Task GetSubCategoryProgressAsync_80PercentCorrect_ReturnsCompleted()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var calculator = new ProgressCalculator(context);

        // Seed: 10 frågor i subkategori 1
        var subCategory = new SubCategory { Id = 1, Name = "Test", CategoryId = 1, OrderIndex = 1 };
        context.SubCategories.Add(subCategory);

        for (int i = 1; i <= 10; i++)
        {
            var question = new Question
            {
                Id = i,
                SubCategoryId = 1,
                Text = $"Question {i}",
                OrderIndex = i
            };
            context.Questions.Add(question);

            // Användaren har svarat på varje fråga (8 rätt, 2 fel)
            var result = new UserResult
            {
                UserId = "user1",
                QuestionId = i,
                SubCategoryId = 1,
                SelectedAnswerOptionId = 1,
                IsCorrect = i <= 8, // Första 8 är rätt
                AnsweredAtUtc = DateTime.UtcNow
            };
            context.UserResults.Add(result);
        }

        await context.SaveChangesAsync();

        // Act
        var progress = await calculator.GetSubCategoryProgressAsync(1, "user1");

        // Assert
        Assert.Equal(10, progress.TotalQuestions);
        Assert.Equal(10, progress.TotalAttempts);
        Assert.Equal(8, progress.CorrectAttempts);
        Assert.Equal(0.80m, progress.PercentCorrect);
        Assert.True(progress.HasAttemptedAllQuestions);
        Assert.True(progress.IsCompleted); // 80% + alla frågor besvarade
    }

    [Fact]
    public async Task GetSubCategoryProgressAsync_70Percent_NotCompleted()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var calculator = new ProgressCalculator(context);

        var subCategory = new SubCategory { Id = 1, Name = "Test", CategoryId = 1, OrderIndex = 1 };
        context.SubCategories.Add(subCategory);

        for (int i = 1; i <= 10; i++)
        {
            var question = new Question
            {
                Id = i,
                SubCategoryId = 1,
                Text = $"Question {i}",
                OrderIndex = i
            };
            context.Questions.Add(question);

            var result = new UserResult
            {
                UserId = "user1",
                QuestionId = i,
                SubCategoryId = 1,
                SelectedAnswerOptionId = 1,
                IsCorrect = i <= 7, // Endast 7 rätt (70%)
                AnsweredAtUtc = DateTime.UtcNow
            };
            context.UserResults.Add(result);
        }

        await context.SaveChangesAsync();

        // Act
        var progress = await calculator.GetSubCategoryProgressAsync(1, "user1");

        // Assert
        Assert.Equal(0.70m, progress.PercentCorrect);
        Assert.True(progress.HasAttemptedAllQuestions);
        Assert.False(progress.IsCompleted); // Under 80%
    }

    [Fact]
    public async Task GetSubCategoryProgressAsync_NotAllQuestionsAttempted_NotCompleted()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var calculator = new ProgressCalculator(context);

        var subCategory = new SubCategory { Id = 1, Name = "Test", CategoryId = 1, OrderIndex = 1 };
        context.SubCategories.Add(subCategory);

        // 10 frågor, men user har bara svarat på 5
        for (int i = 1; i <= 10; i++)
        {
            var question = new Question
            {
                Id = i,
                SubCategoryId = 1,
                Text = $"Question {i}",
                OrderIndex = i
            };
            context.Questions.Add(question);
        }

        // Endast 5 svar (alla rätt = 100%)
        for (int i = 1; i <= 5; i++)
        {
            var result = new UserResult
            {
                UserId = "user1",
                QuestionId = i,
                SubCategoryId = 1,
                SelectedAnswerOptionId = 1,
                IsCorrect = true,
                AnsweredAtUtc = DateTime.UtcNow
            };
            context.UserResults.Add(result);
        }

        await context.SaveChangesAsync();

        // Act
        var progress = await calculator.GetSubCategoryProgressAsync(1, "user1");

        // Assert
        Assert.Equal(1.00m, progress.PercentCorrect); // 100% på de frågor som besvarats
        Assert.False(progress.HasAttemptedAllQuestions); // Bara 5 av 10
        Assert.False(progress.IsCompleted); // Inte alla frågor besvarade
    }
}