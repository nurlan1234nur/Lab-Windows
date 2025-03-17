using CalculatorApp;
using CalculatorApp.MemoryName;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class MemoryItemTest
    {
        [TestMethod]
        public void Test_AddToMemoryItem()
        {
            MemoryItem memoryItem = new MemoryItem(0);
            memoryItem.Add(10);
            Assert.AreEqual(15, memoryItem.value);
        }

        [TestMethod]
        public void Test_SubtractMemoryItem()
        {
            MemoryItem memoryItem = new MemoryItem(0);
            memoryItem.Substract(5);
            Assert.AreEqual(0, memoryItem.value);
        }

        [TestMethod]
        public void Test_AddNegativeNumber()
        {
            MemoryItem memoryItem = new MemoryItem(0);
            memoryItem.Add(-3);
            Assert.AreEqual(2, memoryItem.value);
        }

        [TestMethod]
        public void Test_SubtractNegativeNumber()
        {
            MemoryItem memoryItem = new MemoryItem(0);
            memoryItem.Substract(-3);
            Assert.AreEqual(8, memoryItem.value);
        }

        [TestMethod]
        public void Test_MultipleOperations()
        {
            MemoryItem memoryItem = new MemoryItem(0);
            memoryItem.Add(10);
            memoryItem.Substract(5);
            memoryItem.Add(2);
            Assert.AreEqual(12, memoryItem.value);
        }
    }
}
