using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace ExceptionFilter.Models
{
    public class MyExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
           
            Debug.WriteLine("Exception Occurred: " + context.Exception.Message);

            
            context.ExceptionHandled = true;

           
            context.Result = new ViewResult
            {
                ViewName = "Error" 
            };
        }
    }
}
