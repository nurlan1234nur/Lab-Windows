using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_1
{
    public class Toonii_mashin : TooniiMashin, Interface1
    {
        public Toonii_mashin(int result = 0) {
            this.result = result; }
        
        public Memory memory;
        public void Add(int x)
        {
            result += x;
        }
        public void Substract(int x)
        {
            result -= x;
        }

    }
}
