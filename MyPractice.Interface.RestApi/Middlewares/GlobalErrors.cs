using System.Net;
using MyPractice.Application.Contract.Command;
using MyPractice.Application.Contract.Interfaces;

namespace MyPractice.Interface.RestApi.Middlewares;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, ILocalizer localizer)
    {
        try
        {
            await _next(context);
        }
        catch (BaseException ex)
        {
            var message = localizer.GetLocalized(ex.ResourceType, ex.ResourceKey);
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsJsonAsync(new { error = message });
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new { error = "خطای ناشناخته" });
        }
    }
}
