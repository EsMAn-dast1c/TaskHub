using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Controllers.Filters;

/// <summary>
/// Фильтр логирования запросов к задачам
/// </summary>
public sealed class RequestLoggingFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine($"[Tasks] Начало запроса: {context.HttpContext.Request.Method} {context.HttpContext.Request.Path}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine($"[Tasks] Конец запроса: {context.HttpContext.Request.Method} {context.HttpContext.Request.Path}, StatusCode: {context.HttpContext.Response.StatusCode}");
    }
}