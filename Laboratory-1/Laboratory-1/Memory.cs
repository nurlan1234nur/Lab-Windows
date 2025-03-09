using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoryItems1;

namespace Memorys
{
    public class Memory
    {
        public List<MemoryItem> _memoryItems {  get; private set; }

        public Memory() {
            _memoryItems = new List<MemoryItem>();
        }
        public void Store(int value)
        {
            _memoryItems.Add(new MemoryItem(value));
        }

        public void Clear()
        {
            _memoryItems.Clear();
        }

        public void clearItem(int x)
        {
            if (x >= 0 && _memoryItems.Count >= x)
            {
                _memoryItems.RemoveAt(x);
            }
        }
        public void print()
        {
            int count = 0;
            foreach (var item in _memoryItems)
            {
                Console.Write(item.value+" ");
                count++;
            }
            Console.WriteLine();    

        }


    }
}
