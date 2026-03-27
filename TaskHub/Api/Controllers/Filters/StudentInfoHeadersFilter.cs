using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Controllers.Filters;

/// <summary>
/// Фильтр, добавляющий информацию о студенте в заголовки ответа
/// </summary>
public sealed class StudentInfoHeadersFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        // ничего не делаем до выполнения
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        var headers = context.HttpContext.Response.Headers;

        headers["X-Student-Name"] = "Dmitry"; // замени на своё имя
        headers["X-Student-Group"] = "PI-240944";   // замени на свою группу
    }
}