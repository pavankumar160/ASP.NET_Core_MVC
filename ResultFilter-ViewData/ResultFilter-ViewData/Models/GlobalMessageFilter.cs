using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ResultFilter_ViewData.Models
{
    public class GlobalMessageFilter : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ViewResult view)
            {
                view.ViewData["GlobalMessage"] = "Welcome to our site!";
            }
        }
    }

}
