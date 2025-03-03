using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.IOperation;
using CalculatorApp.Abstract;


namespace CalculatorApp

{
    public class Toonii_mashin : TooniiMashin, Operations
    {
        public Toonii_mashin(int result = 0)
        {
            this.result = result;
        }

        public void Add(int x)
        {
            result += x;
            Console.WriteLine("Result: " + result);
        }
        public void Substract(int x)
        {
            result -= x;
            Console.WriteLine("Result: " + result);
        }

        public void resetResult()
        {
            result = 0;
            Console.WriteLine("Result: " + result);
        }
    }
}