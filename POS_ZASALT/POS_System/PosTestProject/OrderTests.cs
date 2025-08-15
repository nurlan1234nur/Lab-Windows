using System;
using System.Collections.Generic;
using System.Linq;
using Library.Service;
using Library.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class OrderTests
    {
        private OrderService _orderService;
        private Order _originalOrder;

        [TestInitialize]
        public void Setup()
        {
            _orderService = new OrderService();
            _originalOrder = _orderService.GetCurrentOrder();
        }

        [TestCleanup]
        public void TearDown()
        {
            // Reset the current order to its original state
            _orderService = new OrderService();
        }

        [TestMethod]
        public void GetCurrentOrder_ShouldReturnOrder()
        {
            // Act
            var order = _orderService.GetCurrentOrder();

            // Assert
            Assert.IsNotNull(order);
            Assert.IsInstanceOfType(order, typeof(Order));
            Assert.AreEqual(0, order.OrderItems.Count);
            Assert.AreEqual(0, order.TotalAmount);
        }

        [TestMethod]
        public void AddOrderItem_WithValidData_ShouldAddItem()
        {
            // 
            string productName = "Test Product";
            double unitPrice = 100;
            int quantity = 2;
            double discount = 0;

            // Act
            _orderService.AddOrderItem(productName, unitPrice, quantity, discount);

            // Assert
            var order = _orderService.GetCurrentOrder();
            Assert.AreEqual(1, order.OrderItems.Count);
            var item = order.OrderItems.First();
            Assert.AreEqual(productName, item.ProductName);
            Assert.AreEqual(unitPrice, item.UnitPrice);
            Assert.AreEqual(quantity, item.Quantity);
            Assert.AreEqual(discount, item.Discount);
            Assert.AreEqual(200, order.TotalAmount); // 100 * 2 = 200
        }

        [TestMethod]
        public void AddOrderItem_WithDiscount_ShouldCalculateCorrectTotal()
        {
            // Arrange
            string productName = "Test Product";
            double unitPrice = 100;
            int quantity = 2;
            double discount = 10; // 10% discount

            // Act
            _orderService.AddOrderItem(productName, unitPrice, quantity, discount);

            // Assert
            var order = _orderService.GetCurrentOrder();
            Assert.AreEqual(1, order.OrderItems.Count);
            var item = order.OrderItems.First();
            double expectedTotal = (unitPrice - (unitPrice * discount / 100)) * quantity;
            Assert.AreEqual(expectedTotal, order.TotalAmount);
        }

        [TestMethod]
        public void UpdateOrderItem_WithValidData_ShouldUpdateItem()
        {
            // Arrange
            string productName = "Test Product";
            double unitPrice = 100;
            int quantity = 2;
            double discount = 0;
            _orderService.AddOrderItem(productName, unitPrice, quantity, discount);

            var order = _orderService.GetCurrentOrder();
            var item = order.OrderItems.First();
            item.Quantity = 3;

            // Act
            _orderService.UpdateOrderItem(item);

            // Assert
            var updatedOrder = _orderService.GetCurrentOrder();
            Assert.AreEqual(1, updatedOrder.OrderItems.Count);
            var updatedItem = updatedOrder.OrderItems.First();
            Assert.AreEqual(3, updatedItem.Quantity);
            double expectedTotal = (unitPrice - (unitPrice * discount / 100)) * 3;
            Assert.AreEqual(expectedTotal, updatedOrder.TotalAmount);
        }

        [TestMethod]
        public void UpdateOrderItem_WithNonExistentItem_ShouldNotUpdate()
        {
            // Arrange
            var nonExistentItem = new OrderItem("Non Existent", 1, 100, 0);

            // Act
            _orderService.UpdateOrderItem(nonExistentItem);

            // Assert
            var order = _orderService.GetCurrentOrder();
            Assert.AreEqual(0, order.OrderItems.Count);
            Assert.AreEqual(0, order.TotalAmount);
        }

        [TestMethod]
        public void OrderUpdated_Event_ShouldBeRaised()
        {
            // Arrange
            bool eventRaised = false;
            _orderService.OrderUpdated += (sender, args) => eventRaised = true;

            // Act
            _orderService.AddOrderItem("Test Product", 100, 1, 0);

            // Assert
            Assert.IsTrue(eventRaised);
        }
    }
} 