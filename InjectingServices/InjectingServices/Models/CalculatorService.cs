namespace InjectingServices.Models
{

    public interface ICalculatorService
    {
        public int data {  get; set; }
        int Add(int a, int b);
        
    }
    public class CalculatorService : ICalculatorService
    {
        public int data { get; set; } = 0;
        public int Add(int a, int b) { return a + b; }
    }
}
