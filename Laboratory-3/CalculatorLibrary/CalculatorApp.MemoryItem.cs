using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.IOperation;


namespace CalculatorApp.MemoryName
{
    public class MemoryItem : Operations
    {
        public int value;
        public MemoryItem(int value)
        {
            this.value = value;
        }
        /// <summary>
        /// memoryitem iig nemegduulne
        /// </summary>
        /// <param name="Value"></param>
        public void Add(int Value)
        {
            this.value += Value;

        }
        /// <summary>
        /// memoryItem iig horogduulna
        /// </summary>
        /// <param name="Value"></param>
        public void Substract(int Value)
        {
            this.value -= Value;
        }
    }
}