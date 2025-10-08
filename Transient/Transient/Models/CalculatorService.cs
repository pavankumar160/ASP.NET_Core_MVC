namespace Transient.Models
{
    public interface ICalculatorService
    {
        public int data {  get; set; }

        public int Add(int a, int b);
    }
    public class CalculatorService : ICalculatorService
    {
        public int data { get; set; } = 0;

        public int Add(int a, int b) => a + b;
    }
}
