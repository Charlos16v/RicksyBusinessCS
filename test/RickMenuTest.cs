using NUnit.Framework;
using RicksyBusinessCS.domain;

namespace RicksyBusinessCS.test
{
    [TestFixture]
    public class RickMenuTest
    {
        private RickMenu _rickMenu = null;
        private CreditCard _creditCard = null;

        [SetUp]
        public void setupRickMenu()
        {
            _rickMenu = new RickMenu(50, 10);
            _creditCard = new CreditCard("Master", "8888");
        }

        [Test]
        public void constructorTest()
        {
            Assert.NotNull(_rickMenu);
        }

        [Test]
        public void dispatchTest()
        {
            _rickMenu.dispatch(_creditCard);
            
            Assert.AreEqual(49, _rickMenu.getStock());
            Assert.AreEqual(10, _rickMenu.getItemCost());
        }
    }
}