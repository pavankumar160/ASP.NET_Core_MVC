using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace ResultFilter.Models
{
    public class RenderTimeFilter : ResultFilterAttribute
    {
        private Stopwatch _stopwatch;

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew();
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            _stopwatch.Stop();
            var timeTaken = _stopwatch.ElapsedMilliseconds;
            Debug.WriteLine($" View rendered in {timeTaken} ms");
        }
    }
}
