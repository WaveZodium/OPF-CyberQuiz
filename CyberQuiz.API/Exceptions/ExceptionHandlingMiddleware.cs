using CyberQuiz.Shared.Exceptions;
using System.Net;
using System.Text.Json;

namespace CyberQuiz.API.Middleware
{
    /// Global exception handling middleware.
    /// 
    /// This middleware sits early in the ASP.NET Core request pipeline and 
    /// catches ALL unhandled exceptions thrown anywhere in the application 
    /// (controllers, services, repositories, etc.).
    /// 
    /// The purpose is to:
    /// 1. Prevent raw exceptions from leaking to the client.
    /// 2. Convert known exception types into clean, consistent HTTP responses.
    /// 3. Ensure all errors are logged in one central place.
    /// 4. Keep controllers and services clean by removing try/catch duplication.
    /// 
    /// This is considered best practice in modern API design.
    /// 
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Pass the request to the next middleware or controller.
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                // A resource was not found (e.g., question, category, answer).
                await HandleExceptionAsync(context, HttpStatusCode.NotFound, ex.Message);
            }
            catch (ValidationException ex)
            {
                // The client sent invalid data (bad input, wrong IDs, etc.).
                await HandleExceptionAsync(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (ForbiddenException ex)
            {
                // The user is authenticated but not allowed to perform this action.
                await HandleExceptionAsync(context, HttpStatusCode.Forbidden, ex.Message);
            }
            catch (DomainException ex)
            {
                // A business rule was violated (e.g., quiz logic constraints).
                await HandleExceptionAsync(context, HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                // Any unexpected error that we did not explicitly handle.
                _logger.LogError(ex, "Unhandled exception occurred.");

                await HandleExceptionAsync(
                    context,
                    HttpStatusCode.InternalServerError,
                    "An unexpected error occurred."
                );
            }
        }


        /// Writes a consistent JSON error response to the client.

        private static Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var result = JsonSerializer.Serialize(new
            {
                status = (int)statusCode,
                error = statusCode.ToString(),
                message
            });

            return context.Response.WriteAsync(result);
        }
    }
}