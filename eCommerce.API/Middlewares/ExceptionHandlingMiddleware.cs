using System;

namespace eCommerce.API.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Call the next middleware in the pipeline
            await next(context);
        }
        catch (Exception ex)
        {
            var message = new { Type = ex.GetType().ToString(),Message = ex.Message };
            
            // Log the Error
            logger.LogError("Error Detail - {message}", message);
            if (ex.InnerException is not null)
            {
                var innerException = new { Type = ex.InnerException.GetType().ToString(),Message = ex.InnerException.Message };
                logger.LogError("Error Detail - {innerException}", innerException);
            }

            // Handle exceptions globally here
            context.Response.StatusCode = 500;
            
            await context.Response.WriteAsJsonAsync(message!);
        }
    }

}

// Extension method to add middleware to Http Request pipeline
public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
