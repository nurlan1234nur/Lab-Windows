using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.MemoryName
{
    public class Memory
    {
        public List<MemoryItem> _memoryItems {  get; private set; }
        public Memory(){         
        _memoryItems = new List<MemoryItem>();

        }
        /// <summary>
        /// Memory дотор memoryItem нэмнэ.
        /// </summary>
        /// <param name="value"></param>
        public void Store(int value)
        {
            _memoryItems.Add(new MemoryItem(value));
        }
        /// <summary>
        /// Memory - г цэвэрлэнэ.
        /// </summary>
        public void Clear()
        {
            _memoryItems.Clear();
        }

        /// <summary>
        /// MemoryItem хасна.
        /// </summary>
        /// <param name="x"></param>
        public void ClearItem(int x)
        {
            if (x >= 0 && _memoryItems.Count > x)
            {
                _memoryItems.RemoveAt(x);
            }
        }

        /// <summary>
        /// Memory д хадгалагдсан memoryItem жагсаалтыг хэвлэнэ.
        /// </summary>
        public void print()
        {
            int count = 0;
            foreach (var item in _memoryItems)
            {
                Console.Write(item.value + " ");
                count++;
            }
            Console.WriteLine();

        }


    }
}