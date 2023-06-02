using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MiddlewareLibrary.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomMiddleware> _logger;

        public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Add custom header to the response
            context.Response.Headers.Add("X-Custom-Header", "Hello from custom middleware!");

            // Log a message
            _logger.LogInformation("Custom middleware is executing.");

            if (DateTime.Now.Second > 30) context.Response.Headers.Add("Functionalities", "Functionalities OK");


            // Call the next middleware in the pipeline
            await _next(context);
        }
    }
}
