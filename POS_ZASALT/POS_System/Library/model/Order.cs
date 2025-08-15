using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public Order()
        {
            TotalAmount = 0;
            OrderDate = DateTime.Now;
            OrderItems = new List<OrderItem>();
        }

        public void AddItem(string productName, double unitPrice, int quantity, double discount)
        {
            var existingItem = OrderItems.FirstOrDefault(i => i.ProductName == productName);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                existingItem.TotalPrice = existingItem.Quantity * existingItem.UnitPrice * (1 - existingItem.Discount / 100);
            }
            else
            {
                OrderItems.Add(new OrderItem(productName, quantity, (double)unitPrice, discount));
            }
            CalculateTotalAmount();
        }

        public void CalculateTotalAmount()
        {
            TotalAmount = OrderItems.Sum(item => item.TotalPrice);
        }

        public void Clear()
        {
            OrderItems.Clear();
            TotalAmount = 0;
            OrderDate = DateTime.Now;
        }
    }

    public class OrderItem
    {
        public String ProductName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Discount { get; set; }
        public double TotalPrice { get; set; }

        public OrderItem(string productName, int quantity, double unitPrice, double discount)
        {
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Discount = discount;
            TotalPrice = (unitPrice * (1 - discount / 100)) * quantity;
        }


    }
}