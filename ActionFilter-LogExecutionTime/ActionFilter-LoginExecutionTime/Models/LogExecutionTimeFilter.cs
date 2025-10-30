using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace ActionFilter_LoginExecutionTime.Models
{
    public class LogExecutionTimeFilter : ActionFilterAttribute
    {
        private Stopwatch _stopwatch;

        ,public override void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew();
           // _stopwatch.Start();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();
            var elapsed = _stopwatch.ElapsedMilliseconds;
            Debug.WriteLine($"Action {context.ActionDescriptor.DisplayName} took {elapsed} ms");
        }
    }
}

