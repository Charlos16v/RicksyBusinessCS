using System;
using System.Collections.Generic;
using NUnit.Framework;
using RicksyBusinessCS.domain;

namespace RicksyBusinessCS.test
{
    [TestFixture]
    public class UfosParkTest
    {
        private UfosPark _ufosPark = null;

        [SetUp]
        public void setupUfosPark()
        {
            _ufosPark = new UfosPark();
            String[] ufosID = {"unx", "dox"};
            foreach (var ufo in ufosID)
            {
                _ufosPark.add(ufo);
            }
        }
        
        [Test]
        public void constructorTest()
        {
            Assert.NotNull(_ufosPark);
        }

        [Test]
        public void addTest()
        {
            var expected = new List<string>() {"unx", "dox"};
            Assert.AreEqual(expected, _ufosPark.getUfos());
            Console.WriteLine(_ufosPark.getUfos());
        }

        [Test]
        public void dispatchTest()
        {
            CreditCard firstCard = new CreditCard("Master", "0000");
            CreditCard secondCard = new CreditCard("Aguila", "8888");
            
            _ufosPark.dispatch(firstCard);
            _ufosPark.dispatch(secondCard);

            Assert.AreEqual("unx", _ufosPark.getUfoOf(firstCard.getNumber()));
            Assert.AreEqual("dox", _ufosPark.getUfoOf(secondCard.getNumber()));
        }

        [Test]
        public void dispatchNoCreditTest()
        {
            CreditCard noCreditCard = new CreditCard("NoMoney", "8888");

            noCreditCard.pay(3000);
            
            _ufosPark.dispatch(noCreditCard);
            
            Assert.AreEqual("null",_ufosPark.getUfoOf(noCreditCard.getNumber()));
        }

        [Test]
        public void dispatchUfoAlreadyReservedTest()
        {
            CreditCard card = new CreditCard("Maquina", "8888");
            
            _ufosPark.dispatch(card);
            Assert.AreEqual("unx", _ufosPark.getUfoOf(card.getNumber()));
            
            _ufosPark.dispatch(card);
            Assert.AreEqual("unx", _ufosPark.getUfoOf(card.getNumber()));
        }

        [Test]
        public void dispatchUfoNoAvaiableTest()
        {
            CreditCard firstCard = new CreditCard("Master", "0000");
            CreditCard secondCard = new CreditCard("Aguila", "8888");
            CreditCard thirdCard = new CreditCard("Ninja", "1234");
            
            _ufosPark.dispatch(firstCard);
            _ufosPark.dispatch(secondCard);
            _ufosPark.dispatch(thirdCard); // Only 2 ufos on the fleet, its going to be null.
            
            Assert.AreEqual("null", _ufosPark.getUfoOf(thirdCard.getNumber()));
        }
    }
}