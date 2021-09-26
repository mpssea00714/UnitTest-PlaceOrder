using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlaceOrderDemo;

namespace PlaceOrderTest
{
    [TestClass]
    public class PlaceOrderUCOTest
    {
        private PlaceOrderUCO uco;


        [TestInitialize]
        public void Setup()
        {
            uco = new PlaceOrderUCO();
        }

        [TestMethod]
        public void TestPlaceOrderNoAnyDiscount()
        {
            int expected = 0;
            int actual;

            actual = uco.ProcOrder();

            Assert.AreEqual(actual, expected);
        }
    }
}
