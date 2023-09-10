using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class RequestLoggingMiddleware
{
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(ILogger<RequestLoggingMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, Func<Task> next)
    {
        LogRequest(context.Request);

        try
        {
            await next();
        }
        catch (Exception ex)
        {
            LogError(ex);
            throw; 
        }

        LogResponse(context.Response);
    }

    private void LogRequest(HttpRequest request)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Incoming Request:");
        sb.AppendLine($"Method: {request.Method}");
        sb.AppendLine($"Path: {request.Path}");
        sb.AppendLine($"Query: {request.QueryString}");
        sb.AppendLine($"Headers: {string.Join(", ", request.Headers)}");

        _logger.LogInformation(sb.ToString());
    }

    private void LogResponse(HttpResponse response)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Outgoing Response:");
        sb.AppendLine($"Status Code: {response.StatusCode}");
        sb.AppendLine($"Headers: {string.Join(", ", response.Headers)}");

        _logger.LogInformation(sb.ToString());
    }

    private void LogError(Exception exception)
    {
        _logger.LogError(exception, "An unhandled exception occurred.");
    }
}
