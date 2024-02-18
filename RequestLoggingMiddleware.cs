using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        // Log the request path
        _logger.LogInformation($"Handling request: {context.Request.Method} {context.Request.Path}");

        // Call the next delegate/middleware in the pipeline
        await _next(context);

        // Log the response status code
        _logger.LogInformation($"Finished handling request. Response Status Code: {context.Response.StatusCode}");
    }
}
