using System.Text.Json;
using Domain.primitives;
using Domain.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Presentation.Middlewares
{
    public class ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger = logger;

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation($"Request: {context.Request.Path}");
            try
            {
                await _next.Invoke(context);
            }
            catch (ApexException exception)
            {
                await ErrorHandler(context, exception.StatusCode, exception.Message, exception.Errors);
            }

        }


        private async Task ErrorHandler(HttpContext context, int statusCode = 500, string message = "Error", IEnumerable<string>? errors = null)
        {
            _logger.LogError(message);

            context.Response.ContentType = "application/json";

            context.Response.StatusCode = statusCode;

            Result<string> Result;

            Result = Result<string>.Failure(message,errors);

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var jsonResponse = JsonSerializer.Serialize(Result, options);

            await context.Response.WriteAsync(jsonResponse);
        }

    }

    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
