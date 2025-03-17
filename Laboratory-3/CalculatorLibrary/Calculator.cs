using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.IOperation;
using CalculatorApp.Abstract;
using CalculatorApp.MemoryName;
using System.Security.Cryptography.X509Certificates;



namespace CalculatorApp

{
    public class Toonii_mashin : TooniiMashin, Operations
    {
        public Memory memory {  get; private set; }
        public Toonii_mashin(int result = 0)
        {
            this.result = result;
            this.memory = new Memory();   
        }

        public void Add(int x)
        {
            result += x;
        }
        public void Substract(int x)
        {
            result -= x;
        }

        public void resetResult()
        {
            result = 0;
        }

     
        
    }
}