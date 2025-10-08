namespace DiViews.Models
{
    public interface IDateTimeService
    {
        public string GetCurrentTime();
        public int Data {  get; set; } 
    }
    public class DateTimeService : IDateTimeService
    {
        public int Data { get; set; } = 0;
        public string GetCurrentTime()
        {
            return DateTime.Now.ToString("hh:mm:ss tt");
        }
    }
}
