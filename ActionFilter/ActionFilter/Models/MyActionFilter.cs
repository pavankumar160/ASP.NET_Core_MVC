using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace ActionFilter.Models
{
    public class MyActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Runs BEFORE the action method executes
            Debug.WriteLine(" Action is about to execute: " + context.ActionDescriptor.DisplayName);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // Runs AFTER the action method executes
            Debug.WriteLine(" Action executed: " + context.ActionDescriptor.DisplayName);
        }
    }
}
