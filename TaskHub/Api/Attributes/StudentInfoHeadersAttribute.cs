using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Attributes;

public class StudentInfoHeadersAttribute : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        var response = context.HttpContext.Response;

        if (!response.HasStarted)
        {
            response.Headers.Add("X-Student-Name", "Esman Dmitry Olegovich");
            response.Headers.Add("X-Student-Group", "PI-240944");
        }
    }
}