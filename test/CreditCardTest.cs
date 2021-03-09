using NUnit.Framework;
using RicksyBusinessCS.domain;

namespace RicksyBusinessCS.test
{
    [TestFixture]
    public class CreditCardTest
    {
        private CreditCard _creditCard = null;

        [SetUp]
        public void setupCreditCard()
        {
            _creditCard = new CreditCard("Master", "8888");
        }

        [Test]
        public void constructorTest()
        {
            Assert.NotNull(_creditCard);
        }

        [Test]
        public void payTest()
        {
            Assert.True(_creditCard.pay(1000));
            Assert.False(_creditCard.pay(3000));
        }

    }
}