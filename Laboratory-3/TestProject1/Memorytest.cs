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
        public void Test_ClearMemoryItem()
        {
            Memory memory = new Memory();
            memory.Store(5);
            memory.Store(10);
            memory.clearItem(0);
            Assert.AreEqual(1, memory._memoryItems.Count);
            Assert.AreEqual(10, memory._memoryItems[0].value);
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
        public void Test_SubtractMemoryItem()
        {
            Memory memory = new Memory();
            memory.Store(15);
            memory._memoryItems[0].Substract(5);
            Assert.AreEqual(10, memory._memoryItems[0].value);
        }
    }
}
