using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_1
{
    public class Memory
    {
        public List<MemoryItem> _memoryItems = new List<MemoryItem>();

        public void Store(int value)
        {
            _memoryItems.Add(new MemoryItem(value));
        }

        public void Clear()
        {
            _memoryItems.Clear();
        }

        public MemoryItem? GetMemoryItem(int x)
        {
            if(_memoryItems.Count == 0)
            {
                return null;
            }
            else if(x < 0 ||  x >= _memoryItems.Count) 
            {
                return null;
            }
            else
            {
                return _memoryItems[x];
            }
        }
        public void print()
        {
            int count = 0;
            
            foreach (var item in _memoryItems)
            {
                Console.WriteLine(item.value);
                count++;
            }
            if (count == 0)
            {
                Console.WriteLine("-----------------------");
            }
        }


    }
}
