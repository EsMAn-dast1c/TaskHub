using Api.Controllers.Tasks.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Controllers.Filters;

/// <summary>
/// Фильтр валидации запроса на создание задачи
/// </summary>
public sealed class ValidateCreateTaskRequestFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ActionArguments.TryGetValue("request", out var requestValue))
        {
            context.Result = new BadRequestObjectResult("Тело запроса отсутствует");
            return;
        }

        if (requestValue is not CreateTaskRequest request)
        {
            context.Result = new BadRequestObjectResult("Тело запроса отсутствует");
            return;
        }

        if (string.IsNullOrWhiteSpace(request.Title))
        {
            context.Result = new BadRequestObjectResult("Название задачи не задано");
            return;
        }

        if (request.CreatedByUserId == Guid.Empty)
        {
            context.Result = new BadRequestObjectResult("Идентификатор пользователя не задан");
            return;
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}