using CalculatorApp;

namespace TestProject1
{
    [TestClass]
    public class MemoryTests
    {
        [TestMethod]
        public void Test_StoreMemoryItem()
        {
            Toonii_mashin toonii_Mashin = new Toonii_mashin();
            toonii_Mashin.memory.Store(5);
            Assert.AreEqual(1, toonii_Mashin.memory._memoryItems.Count);
            Assert.AreEqual(5, toonii_Mashin.memory._memoryItems[0].value);
        }

        [TestMethod]
        public void Test_ClearMemory()
        {
            Toonii_mashin toonii_Mashin = new Toonii_mashin(); 
            toonii_Mashin.memory.Store(5);
            toonii_Mashin.memory.Clear();
            Assert.AreEqual(0, toonii_Mashin.memory._memoryItems.Count);
        }

        [TestMethod]
        public void Test_ClearMemoryItem()
        {
            Toonii_mashin toonii_Mashin = new Toonii_mashin();
            toonii_Mashin.memory.Store(5);
            toonii_Mashin.memory.Store(10);
            toonii_Mashin.memory.clearItem(0);
            Assert.AreEqual(1, toonii_Mashin.memory._memoryItems.Count);
            Assert.AreEqual(10, toonii_Mashin.memory._memoryItems[0].value);
        }

        [TestMethod]
        public void Test_AddToMemoryItem()
        {
            Toonii_mashin toonii_Mashin = new Toonii_mashin(); 
            toonii_Mashin.memory.Store(5);
            toonii_Mashin.memory._memoryItems[0].Add(10);
            Assert.AreEqual(15, toonii_Mashin.memory._memoryItems[0].value);
        }

        [TestMethod]
        public void Test_SubtractMemoryItem()
        {
            Toonii_mashin toonii_Mashin = new Toonii_mashin();
            toonii_Mashin.memory.Store(15);
            toonii_Mashin.memory._memoryItems[0].Substract(5);
            Assert.AreEqual(10, toonii_Mashin.memory._memoryItems[0].value);
        }
    }
}
