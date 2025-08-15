using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.model
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public int Barcode { get; set; }
        public string ImagePath { get; set; }
        public int Discount { get; set; } = 0;


        public Product(string name, double price, int categoryId, int barcode, string imagePath)
        {
            Name = name;
            Price = price;
            CategoryId = categoryId;
            Barcode = barcode;
            ImagePath = imagePath;
        }

        public Product() { }
    }

}
