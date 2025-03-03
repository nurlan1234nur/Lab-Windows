using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.IOperation;


namespace CalculatorApp.Memory
{
    public class MemoryItem : Operations
    {
        public int value;
        public MemoryItem(int value)
        {
            this.value = value;
        }

        public void Add(int Value)
        {
            this.value += Value;

        }

        public void Substract(int Value)
        {
            this.value -= Value;
        }
    }
}