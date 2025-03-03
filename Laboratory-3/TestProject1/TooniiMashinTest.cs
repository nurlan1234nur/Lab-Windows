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
        public void Test_MultipleOperations()
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
    }
}
