namespace ServiceInjectionAIO.Models
{
    public interface ICalculatorService
    {
        public int Add(int x, int y);
        public int Data {  get; set; }
    }
    public class CalculatorService : ICalculatorService
    {
        public int Add(int x, int y) =>  x + y;
        public int Data { get; set; } = 0;
    }
}
