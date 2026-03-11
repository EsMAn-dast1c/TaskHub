using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Api.Attributes;

public class ResponseTimeHeaderAttribute : ActionFilterAttribute
{
    private Stopwatch? _stopwatch;

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        _stopwatch = Stopwatch.StartNew();
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (_stopwatch == null)
            return;

        _stopwatch.Stop();

        var response = context.HttpContext.Response;

        if (!response.HasStarted)
        {
            response.Headers.Add("X-Response-Time-Ms", _stopwatch.ElapsedMilliseconds.ToString());
        }
    }
}