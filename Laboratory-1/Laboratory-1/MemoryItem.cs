using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_1
{
    public class MemoryItem: Interface1
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
