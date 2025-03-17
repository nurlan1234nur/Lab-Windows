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
        /// хадгалсан утган дээр нэмнэ.
        /// </summary>
        /// <param name="value"></param>
        public void Add(int Value)
        {
            this.value += Value;

        }

        /// <summary>
        /// хадгалсан memoryItem - ийн утгаас хасна.
        /// </summary>
        /// <param name="Value"></param>
        public void Substract(int Value)
        {
            this.value -= Value;
        }
    }
}