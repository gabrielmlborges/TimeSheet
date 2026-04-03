using TimeSheet.Domain.Exceptions;

namespace TimeSheet.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        context.Response.StatusCode = exception switch
        {
            NotFoundException => 404,
            InvalidCredentialsException => 401,
            ConflictException => 409,
            _ => 500
        };

        return context.Response.WriteAsJsonAsync(new
        {
            error = exception.Message,
            status = context.Response.StatusCode
        });
    }
}
