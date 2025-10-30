using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;


namespace ActionFilter_UseCases.Models
{
    public class ActionFilter_UseCases : ActionFilterAttribute
    {
        private Stopwatch _stopwatch;


        // Debugging + Monitoring → Before Action executes
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew();
            Debug.WriteLine(" Action is about to execute: " + context.ActionDescriptor.DisplayName);
            Debug.WriteLine(" Method Parameters: " + context.ActionArguments);

        }

        // Error Tracking + Performance → After Action executes
        public override void OnActionExecuted(ActionExecutedContext context)
        {
             

            _stopwatch.Stop();

            if(context.Exception != null)
            {
                Debug.WriteLine("Error Caught" + context.Exception);
            }
            else
            {
                Debug.WriteLine(" Action executed: " + context.ActionDescriptor.DisplayName);
                var elapsed = _stopwatch.ElapsedMilliseconds;
                Debug.WriteLine($"Action {context.ActionDescriptor.DisplayName} took {elapsed} ms");
            }






        }
    }
}
