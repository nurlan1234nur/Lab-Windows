using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.IOperation;
using CalculatorApp.Abstract;
using CalculatorApp.MemoryName;


namespace CalculatorApp

{
    public class Toonii_mashin : TooniiMashin, Operations
    {
        public Memory memory {  get; private set; }
        public Toonii_mashin(int result = 0)
        {
            this.result = result;
            memory = new Memory();
        }

        /// <summary>
        /// Result - д  нэмнэ.
        /// </summary>
        /// <param name="x"></param>
        public void Add(int x)
        {
            result += x;
            Console.WriteLine("Result: " + result);
        }

        /// <summary>
        /// Result - аас хасна.
        /// </summary>
        /// <param name="x"></param>
        public void Substract(int x)
        {
            result -= x;
            Console.WriteLine("Result: " + result);
        }

        /// <summary>
        /// Result ийг 0 болгож шинэчилнэ. 
        /// </summary>
        public void resetResult()
        {
            result = 0;
            Console.WriteLine("Result: " + result);
        }
    }
}