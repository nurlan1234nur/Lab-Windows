using CalculatorApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class TooniiMashinTests
    {
        [TestMethod]
        public void Test_InitialResult_ShouldBeZero()
        {
            Toonii_mashin tooniiMashin = new Toonii_mashin();
            Assert.AreEqual(0, tooniiMashin.result);
        }

        [TestMethod]
        public void Test_Addition()
        {
            Toonii_mashin tooniiMashin = new Toonii_mashin();
            tooniiMashin.Add(10);
            Assert.AreEqual(10, tooniiMashin.result);
        }

        [TestMethod]
        public void Test_Subtraction()
        {
            Toonii_mashin tooniiMashin = new Toonii_mashin();
            tooniiMashin.Add(10);
            tooniiMashin.Substract(5);
            Assert.AreEqual(5, tooniiMashin.result);
        }

        [TestMethod]
        public void Test_Operations()
        {
            Toonii_mashin tooniiMashin = new Toonii_mashin();
            tooniiMashin.Add(20);
            tooniiMashin.Substract(5);
            tooniiMashin.Add(10);
            Assert.AreEqual(25, tooniiMashin.result);
        }

        [TestMethod]
        public void Test_ResetResult()
        {
            Toonii_mashin tooniiMashin = new Toonii_mashin();
            tooniiMashin.Add(15);
            tooniiMashin.resetResult();
            Assert.AreEqual(0, tooniiMashin.result);
        }

        [TestMethod]

        public void Test_memorystore()
        {
            Toonii_mashin toonii_Mashin = new Toonii_mashin();
            toonii_Mashin.Add(20);
            toonii_Mashin.memory.Store(toonii_Mashin.result);
            Assert.AreEqual(20, toonii_Mashin.memory._memoryItems[0].value);
        }


        [TestMethod]
        public void Test_memoryClear()
        {
            Toonii_mashin toonii_Mashin = new Toonii_mashin();
            toonii_Mashin.Add(20);
            toonii_Mashin.memory.Store(toonii_Mashin.result);
            toonii_Mashin.memory.Store(toonii_Mashin.result);
            toonii_Mashin.memory.Store(toonii_Mashin.result);
            toonii_Mashin.memory.Clear();
            Assert.AreEqual(0, toonii_Mashin.memory._memoryItems.Count);
        }

        [TestMethod]

        public void Test_memoryClearItem()
        {
            Toonii_mashin toonii_Mashin = new Toonii_mashin();
            toonii_Mashin.memory.Store(toonii_Mashin.result);
            toonii_Mashin.memory.clearItem(0);
            Assert.AreEqual(0, toonii_Mashin.memory._memoryItems.Count);
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
