using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces1;
using Abstract_class;
using Memorys;

namespace TooniiMashins1
{
    public class Toonii_mashin : TooniiMashin, Interface1
    {
        public Toonii_mashin(int result = 0) {
            this.result = result; }

        public Memory memory;
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
            Console.WriteLine("Result: " +result);
        }
    }
}
