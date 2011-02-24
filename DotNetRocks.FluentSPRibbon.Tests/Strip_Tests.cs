using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Strip_Tests
    {
        private Strip _sut;

        [SetUp]
        public void Setup()
        {
            _sut = Strip.Create("MyStrip");
        }
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<Strip>(_sut);
        }

        [Test]
        public void XmlElementName_Should_Be_Strip()
        {
            Assert.AreEqual("Strip",_sut.XmlElementName);
        }

        [Test]
        public void IsIdProvider_Should_Be_False()
        {
            Assert.IsFalse(_sut.IsIdProvider);
        }

        [Test]
        public void With_Should_Add_ControlRef_To_Current_Instance()
        {
            var controlRef = new ControlRef();
            _sut.With(() => controlRef);
            Assert.AreEqual(1,_sut._controlRefs.Count);
            Assert.AreEqual(controlRef, _sut._controlRefs[0]);
        }
    }
}