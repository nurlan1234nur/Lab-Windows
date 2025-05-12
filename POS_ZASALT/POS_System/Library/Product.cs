using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Product
    {
        public string Name { get; set; }
        public int Barcode { get; set; }
        public decimal Price { get; set; } 
        public int CategoryId { get; set; }
        public string ImagePath { get; set; }
        public int Discount { get; set; } = 0;


    }
}
