using NUnit.Framework;
using RicksyBusinessCS.domain;

namespace RicksyBusinessCS.test
{
    [TestFixture]
    public class ReceptivoTest
    {
        private Receptivo _receptivo = null;
        private UfosPark _ufosPark = null;
        private CrystalExpender _crystalExpender = null;

        [SetUp]
        public void setupReceptivo()
        {
            _receptivo = new Receptivo();
            _crystalExpender = new CrystalExpender(50, 10);
            _ufosPark = new UfosPark();
        }

        [Test]
        public void constructorTest()
        {
            Assert.NotNull(_receptivo);
        }

        [Test]
        public void registraTest()
        {
            _receptivo.registra(_crystalExpender);
            _receptivo.registra(_ufosPark);
            
            Assert.True( _receptivo.getObservers().Contains(_crystalExpender));
            Assert.True( _receptivo.getObservers().Contains(_ufosPark));
        }
    }
}