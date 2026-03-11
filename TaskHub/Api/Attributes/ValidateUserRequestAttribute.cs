using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace Api.Attributes;

public class ValidateUserRequestAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ActionArguments.Count == 0)
        {
            context.Result = new BadRequestObjectResult("Тело запроса отсутствует");
            return;
        }

        var request = context.ActionArguments.First().Value;

        if (request == null)
        {
            context.Result = new BadRequestObjectResult("Тело запроса отсутствует");
            return;
        }

        var property = request.GetType().GetProperty("Name", BindingFlags.Public | BindingFlags.Instance);

        if (property == null)
            return;

        var value = property.GetValue(request) as string;

        if (string.IsNullOrWhiteSpace(value))
        {
            context.Result = new BadRequestObjectResult("Имя пользователя не задано");
        }
    }
}