using System.Net;
using CPTM.GRD.Application.Exceptions;
using Newtonsoft.Json;

namespace CPTM.GRD.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(httpContext, e);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var statusCode = HttpStatusCode.InternalServerError;
        var result = JsonConvert.SerializeObject(new ErrorDetails
        {
            ErrorMessage = exception.Message,
            ErrorType = "Failure"
        });

        switch (exception)
        {
            case BadRequestException:
                statusCode = HttpStatusCode.BadRequest;
                break;
            case ValidationException validationException:
                statusCode = HttpStatusCode.BadRequest;
                result = JsonConvert.SerializeObject(validationException.Errors);
                break;
            case NotFoundException:
                statusCode = HttpStatusCode.NotFound;
                break;
        }

        context.Response.StatusCode = (int)statusCode;
        return context.Response.WriteAsync(result);
    }

    private class ErrorDetails
    {
        public string ErrorType { get; init; } = string.Empty;
        public string ErrorMessage { get; init; } = string.Empty;
    }
}