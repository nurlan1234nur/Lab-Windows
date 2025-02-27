using CalculatorApp.Memory;

namespace TestProject1
{
    [TestClass]
    public class MemoryTests
    {
        [TestMethod]
        public void Test_StoreMemoryItem()
        {
            Memory memory = new Memory();
            memory.Store(5);
            Assert.AreEqual(1, memory._memoryItems.Count);
            Assert.AreEqual(5, memory._memoryItems[0].value);
        }

        [TestMethod]
        public void Test_ClearMemory()
        {
            Memory memory = new Memory();
            memory.Store(5);
            memory.Clear();
            Assert.AreEqual(0, memory._memoryItems.Count);
        }

        [TestMethod]
        public void Test_ClearSpecificMemoryItem()
        {
            Memory memory = new Memory();
            memory.Store(5);
            memory.Store(10);
            memory.clearItem(0);
            Assert.AreEqual(1, memory._memoryItems.Count);
            Assert.AreEqual(10, memory._memoryItems[0].value);
        }

        [TestMethod]
        public void Test_ClearSpecificMemoryItem_OutOfBounds()
        {
            Memory memory = new Memory();
            memory.Store(5);
            memory.clearItem(5);
            Assert.AreEqual(1, memory._memoryItems.Count);
        }

        [TestMethod]
        public void Test_AddToMemoryItem()
        {
            Memory memory = new Memory();
            memory.Store(5);
            memory._memoryItems[0].Add(10);
            Assert.AreEqual(15, memory._memoryItems[0].value);
        }

        [TestMethod]
        public void Test_AddToMemoryItem_Negative()
        {
            Memory memory = new Memory();
            memory.Store(10);
            memory._memoryItems[0].Add(-5);
            Assert.AreEqual(5, memory._memoryItems[0].value);
        }

        [TestMethod]
        public void Test_SubtractFromMemoryItem()
        {
            Memory memory = new Memory();
            memory.Store(15);
            memory._memoryItems[0].Substract(5);
            Assert.AreEqual(10, memory._memoryItems[0].value);
        }

        [TestMethod]
        public void Test_SubtractFromMemoryItem_BelowZero()
        {
            Memory memory = new Memory();
            memory.Store(5);
            memory._memoryItems[0].Substract(10);
            Assert.AreEqual(-5, memory._memoryItems[0].value);
        }

        [TestMethod]
        public void Test_Memory_Clear_EmptyList()
        {
            Memory memory = new Memory();
            memory.Clear();
            Assert.AreEqual(0, memory._memoryItems.Count);
        }
    }
}
