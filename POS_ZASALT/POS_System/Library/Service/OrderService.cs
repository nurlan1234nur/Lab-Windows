using System;
using Library.model;
using System.Linq;

namespace Library.Service
{
    public class OrderService
    {
        private Order _currentOrder;
        public event EventHandler OrderUpdated;

        public OrderService()
        {
            _currentOrder = new Order();
        }

        /// <summary>
        /// Одоогийн захиалгын мэдээлэл авах
        /// </summary>
        public Order GetCurrentOrder()
        {
            return _currentOrder;
        }

        /// <summary>
        /// Захиалгад бараа нэмэх
        /// </summary>
        public void AddOrderItem(string productName, double unitPrice, int quantity, double discount)
        {
            _currentOrder.AddItem(productName, unitPrice, quantity, discount);
            OnOrderUpdated();
        }

        /// <summary>
        /// Захиалгын барааны тоо хэмжээг засах
        /// </summary>
        public void UpdateOrderItem(OrderItem item)
        {
            var existingItem = _currentOrder.OrderItems.FirstOrDefault(i => i.ProductName == item.ProductName);
            if (existingItem != null)
            {
                existingItem.Quantity = item.Quantity;
                existingItem.TotalPrice = existingItem.Quantity * existingItem.UnitPrice * (1 - existingItem.Discount / 100);
                _currentOrder.CalculateTotalAmount();
                OnOrderUpdated();
            }
        }

        /// <summary>
        /// Захиалгаас бараа хасах
        /// </summary>
        public void RemoveOrderItem(string productName)
        {
            var item = _currentOrder.OrderItems.FirstOrDefault(i => i.ProductName == productName);
            if (item != null)
            {
                _currentOrder.OrderItems.Remove(item);
                _currentOrder.CalculateTotalAmount();
                OnOrderUpdated();
            }
        }

        /// <summary>
        /// Захиалга өөрчлөгдөхөд дуудагдах
        /// </summary>
        protected virtual void OnOrderUpdated()
        {
            if (OrderUpdated != null)
            {
                OrderUpdated(this, EventArgs.Empty);
            }
        }
    }
}