using CyberQuiz.Application.Services;
using CyberQuiz.Infrastructure.Data;
using CyberQuiz.Infrastructure.Entities;
using CyberQuiz.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CyberQuiz.Tests;

public class ProgressCalculatorTests
{
    private ApplicationDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new ApplicationDbContext(options);
    }

    [Fact]
    public async Task GetSubCategoryProgressAsync_NoQuestions_ReturnsZeroProgress()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var questionRepo = new QuestionRepository(context);
        var userResultRepo = new UserResultRepository(context);
        var calculator = new ProgressCalculator(questionRepo, userResultRepo);

        // Act
        var result = await calculator.GetSubCategoryProgressAsync(999, "user1");

        // Assert
        Assert.Equal(0, result.TotalQuestions);
        Assert.Equal(0, result.TotalAttempts);
        Assert.Equal(0m, result.PercentCorrect);
        Assert.False(result.HasAttemptedAllQuestions);
        Assert.False(result.IsCompleted);
    }

    [Fact]
    public async Task GetSubCategoryProgressAsync_80PercentCorrect_AllQuestionsAttempted_ReturnsCompleted()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var questionRepo = new QuestionRepository(context);
        var userResultRepo = new UserResultRepository(context);
        var calculator = new ProgressCalculator(questionRepo, userResultRepo);

        // Seed data: Category och SubCategory
        var category = new Category { Id = 1, Name = "Test Category" };
        var subCategory = new SubCategory
        {
            Id = 1,
            Name = "Test SubCategory",
            CategoryId = 1,
            OrderIndex = 1,
            Category = category
        };
        context.Categories.Add(category);
        context.SubCategories.Add(subCategory);

        // Seed: 10 frågor i subkategori 1
        for (int i = 1; i <= 10; i++)
        {
            var question = new Question
            {
                Id = i,
                SubCategoryId = 1,
                Text = $"Question {i}",
                OrderIndex = i,
                SubCategory = subCategory
            };
            context.Questions.Add(question);

            // Användaren har svarat på varje fråga (8 rätt, 2 fel)
            var result = new UserResult
            {
                UserId = "user1",
                QuestionId = i,
                SubCategoryId = 1,
                SelectedAnswerOptionId = 1,
                IsCorrect = i <= 8, // Första 8 är rätt (80%)
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
        var questionRepo = new QuestionRepository(context);
        var userResultRepo = new UserResultRepository(context);
        var calculator = new ProgressCalculator(questionRepo, userResultRepo);

        var category = new Category { Id = 1, Name = "Test Category" };
        var subCategory = new SubCategory
        {
            Id = 1,
            Name = "Test",
            CategoryId = 1,
            OrderIndex = 1,
            Category = category
        };
        context.Categories.Add(category);
        context.SubCategories.Add(subCategory);

        // 10 frågor, 7 rätt (70%)
        for (int i = 1; i <= 10; i++)
        {
            var question = new Question
            {
                Id = i,
                SubCategoryId = 1,
                Text = $"Question {i}",
                OrderIndex = i,
                SubCategory = subCategory
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
        Assert.Equal(10, progress.TotalQuestions);
        Assert.Equal(7, progress.CorrectAttempts);
        Assert.Equal(0.70m, progress.PercentCorrect);
        Assert.True(progress.HasAttemptedAllQuestions);
        Assert.False(progress.IsCompleted); // Under 80%
    }

    [Fact]
    public async Task GetSubCategoryProgressAsync_100PercentButNotAllQuestionsAttempted_NotCompleted()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var questionRepo = new QuestionRepository(context);
        var userResultRepo = new UserResultRepository(context);
        var calculator = new ProgressCalculator(questionRepo, userResultRepo);

        var category = new Category { Id = 1, Name = "Test Category" };
        var subCategory = new SubCategory
        {
            Id = 1,
            Name = "Test",
            CategoryId = 1,
            OrderIndex = 1,
            Category = category
        };
        context.Categories.Add(category);
        context.SubCategories.Add(subCategory);

        // 10 frågor totalt
        for (int i = 1; i <= 10; i++)
        {
            var question = new Question
            {
                Id = i,
                SubCategoryId = 1,
                Text = $"Question {i}",
                OrderIndex = i,
                SubCategory = subCategory
            };
            context.Questions.Add(question);
        }

        // Användaren har bara svarat på 5 frågor (alla rätt = 100%)
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
        Assert.Equal(10, progress.TotalQuestions);
        Assert.Equal(5, progress.TotalAttempts);
        Assert.Equal(5, progress.CorrectAttempts);
        Assert.Equal(1.00m, progress.PercentCorrect); // 100% på de frågor som besvarats
        Assert.False(progress.HasAttemptedAllQuestions); // Bara 5 av 10
        Assert.False(progress.IsCompleted); // Inte alla frågor besvarade
    }

    [Theory]
    [InlineData(10, 8, true)]   // 80% = completed
    [InlineData(10, 7, false)]  // 70% = not completed
    [InlineData(10, 10, true)]  // 100% = completed
    [InlineData(10, 9, true)]   // 90% = completed
    [InlineData(5, 4, true)]    // 80% = completed
    [InlineData(5, 3, false)]   // 60% = not completed
    public async Task GetSubCategoryProgressAsync_VariousScores_ReturnsExpectedCompletion(
        int totalQuestions,
        int correctAnswers,
        bool expectedCompleted)
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var questionRepo = new QuestionRepository(context);
        var userResultRepo = new UserResultRepository(context);
        var calculator = new ProgressCalculator(questionRepo, userResultRepo);

        var category = new Category { Id = 1, Name = "Test Category" };
        var subCategory = new SubCategory
        {
            Id = 1,
            Name = "Test",
            CategoryId = 1,
            OrderIndex = 1,
            Category = category
        };
        context.Categories.Add(category);
        context.SubCategories.Add(subCategory);

        for (int i = 1; i <= totalQuestions; i++)
        {
            context.Questions.Add(new Question
            {
                Id = i,
                SubCategoryId = 1,
                Text = $"Q{i}",
                OrderIndex = i,
                SubCategory = subCategory
            });

            context.UserResults.Add(new UserResult
            {
                UserId = "user1",
                QuestionId = i,
                SubCategoryId = 1,
                SelectedAnswerOptionId = 1,
                IsCorrect = i <= correctAnswers,
                AnsweredAtUtc = DateTime.UtcNow
            });
        }

        await context.SaveChangesAsync();

        // Act
        var progress = await calculator.GetSubCategoryProgressAsync(1, "user1");

        // Assert
        Assert.Equal(expectedCompleted, progress.IsCompleted);
        Assert.Equal(totalQuestions, progress.TotalQuestions);
        Assert.Equal(correctAnswers, progress.CorrectAttempts);
    }

    [Fact]
    public async Task GetSubCategoryProgressAsync_MultipleAttemptsPerQuestion_CountsAllAttempts()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var questionRepo = new QuestionRepository(context);
        var userResultRepo = new UserResultRepository(context);
        var calculator = new ProgressCalculator(questionRepo, userResultRepo);

        var category = new Category { Id = 1, Name = "Test Category" };
        var subCategory = new SubCategory
        {
            Id = 1,
            Name = "Test",
            CategoryId = 1,
            OrderIndex = 1,
            Category = category
        };
        context.Categories.Add(category);
        context.SubCategories.Add(subCategory);

        // 5 frågor
        for (int i = 1; i <= 5; i++)
        {
            context.Questions.Add(new Question
            {
                Id = i,
                SubCategoryId = 1,
                Text = $"Q{i}",
                OrderIndex = i,
                SubCategory = subCategory
            });

            // Användaren försöker varje fråga 2 gånger
            // Första gången: fel
            context.UserResults.Add(new UserResult
            {
                UserId = "user1",
                QuestionId = i,
                SubCategoryId = 1,
                SelectedAnswerOptionId = 1,
                IsCorrect = false,
                AnsweredAtUtc = DateTime.UtcNow.AddMinutes(-10)
            });

            // Andra gången: rätt
            context.UserResults.Add(new UserResult
            {
                UserId = "user1",
                QuestionId = i,
                SubCategoryId = 1,
                SelectedAnswerOptionId = 2,
                IsCorrect = true,
                AnsweredAtUtc = DateTime.UtcNow
            });
        }

        await context.SaveChangesAsync();

        // Act
        var progress = await calculator.GetSubCategoryProgressAsync(1, "user1");

        // Assert
        Assert.Equal(5, progress.TotalQuestions);
        Assert.Equal(10, progress.TotalAttempts); // 5 frågor × 2 försök
        Assert.Equal(5, progress.CorrectAttempts);
        Assert.Equal(0.50m, progress.PercentCorrect); // 5 rätt av 10 försök = 50%
        Assert.True(progress.HasAttemptedAllQuestions);
        Assert.False(progress.IsCompleted); // Under 80%
    }
}