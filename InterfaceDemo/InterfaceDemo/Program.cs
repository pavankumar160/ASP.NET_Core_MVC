using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    public interface ICalculatorService
    {
        int Add(int a, int b);
    }
    public class CalculatorService : ICalculatorService
    {
        public int Add(int a, int b) { return a + b; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            ICalculatorService calculator = new CalculatorService();

            Console.WriteLine(calculator.Add(10, 20));
        }
    }
}
