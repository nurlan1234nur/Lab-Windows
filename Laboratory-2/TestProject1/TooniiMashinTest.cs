using CalculatorApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class TooniiMashinTests
    {
        private Toonii_mashin tooniiMashin;

        [TestMethod]
        public void Test_Constructor()
        {
            tooniiMashin = new Toonii_mashin();
            tooniiMashin = new Toonii_mashin();
            Assert.AreEqual(0, tooniiMashin.result);
        }

        [TestMethod]
        public void Test_Addition()
        {
            tooniiMashin = new Toonii_mashin();
            tooniiMashin.Add(10);
            Assert.AreEqual(10, tooniiMashin.result );
        }

        [TestMethod]
        public void Test_Subtraction()
        {
            tooniiMashin = new Toonii_mashin();
            tooniiMashin.Add(10);
            tooniiMashin.Substract(5);
            Assert.AreEqual(5, tooniiMashin.result);
        }

        [TestMethod]
        public void Test_MultipleOperations()
        {
            tooniiMashin = new Toonii_mashin();
            tooniiMashin.Add(20);
            tooniiMashin.Substract(5);
            tooniiMashin.Add(10);
            Assert.AreEqual(25, tooniiMashin.result);
        }

        [TestMethod]
        public void Test_ResetResult()
        {
            tooniiMashin = new Toonii_mashin();
            tooniiMashin.Add(15);
            tooniiMashin.resetResult();
            Assert.AreEqual(0, tooniiMashin.result);
        }

        [TestMethod]
        public void Test_AddNegative()
        {
            tooniiMashin = new Toonii_mashin();
            tooniiMashin.Add(-10);
            Assert.AreEqual(-10, tooniiMashin.result);
        }

        [TestMethod]
        public void Test_SubtractNeg()
        {
            tooniiMashin = new Toonii_mashin();
            tooniiMashin.Add(20);
            tooniiMashin.Substract(-10);
            Assert.AreEqual(30, tooniiMashin.result);
        }

        [TestMethod]
        public void Test_ResetMultipleTimes()
        {
            tooniiMashin = new Toonii_mashin();
            tooniiMashin.Add(50);
            tooniiMashin.resetResult();
            tooniiMashin.Add(30);
            tooniiMashin.resetResult();
            Assert.AreEqual(0, tooniiMashin.result);
        }

    }
}
