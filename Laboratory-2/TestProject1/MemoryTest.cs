using CalculatorApp;
using CalculatorApp.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class MemoryTest
    {
        [TestMethod]
        public void Test_StoreMemory()
        {
            Toonii_mashin tooniiMashin = new Toonii_mashin();
            tooniiMashin.Add(20);
            tooniiMashin.memory.Store(tooniiMashin.result);
            Assert.AreEqual(20, tooniiMashin.memory._memoryItems[0].value);
        }

        [TestMethod]
        public void Test_MemoryClear()
        {
            Toonii_mashin tooniiMashin = new Toonii_mashin();
            tooniiMashin.Add(20);
            tooniiMashin.memory.Store(tooniiMashin.result);
            tooniiMashin.memory.Store(30);
            tooniiMashin.memory.Store(40);

            tooniiMashin.memory.Clear();
            Assert.AreEqual(0, tooniiMashin.memory._memoryItems.Count);
        }

        [TestMethod]
        public void Test_ClearItem()
        {
            Toonii_mashin tooniiMashin = new Toonii_mashin();
            tooniiMashin.memory.Store(10);
            tooniiMashin.memory.Store(20);
            tooniiMashin.memory.Store(30);

            tooniiMashin.memory.ClearItem(1);

            Assert.AreEqual(2, tooniiMashin.memory._memoryItems.Count);
            Assert.AreEqual(30, tooniiMashin.memory._memoryItems[1].value);
        }

        [TestMethod]
        public void Test_ClearItems()
        {
            Toonii_mashin tooniiMashin = new Toonii_mashin();
            tooniiMashin.memory.Store(10);
            tooniiMashin.memory.Store(20);
            tooniiMashin.memory.Store(30);

            tooniiMashin.memory.ClearItem(0);
            tooniiMashin.memory.ClearItem(1); 

            Assert.AreEqual(1, tooniiMashin.memory._memoryItems.Count);
            Assert.AreEqual(20, tooniiMashin.memory._memoryItems[0].value);
        }
    }
}
