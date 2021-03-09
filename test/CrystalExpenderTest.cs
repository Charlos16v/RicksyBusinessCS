using NUnit.Framework;
using RicksyBusinessCS.domain;

namespace RicksyBusinessCS.test
{
    [TestFixture]
    public class CrystalExpenderTest
    {
        private CrystalExpender _crystalExpender = null;
        private CreditCard _creditCard = null;

        [SetUp]
        public void setupCrystal()
        {
            _crystalExpender = new CrystalExpender(50, 10);
            _creditCard = new CreditCard("Master", "8888");
        }

        [Test]
        public void constructorTest()
        {
            Assert.NotNull(_crystalExpender);
        }

        [Test]
        public void dispatchTest()
        {
            _crystalExpender.dispatch(_creditCard);
            
            Assert.AreEqual(49, _crystalExpender.getStock());
            Assert.AreEqual(10, _crystalExpender.getItemCost());
        }
    }
}