using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Row_Tests
    {
        private Row _sut;

        [SetUp]
        public void Setup()
        {
            _sut = Row.Create("MyRow");
        }
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<Row>(_sut);
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
            Assert.AreEqual(controlRef,_sut._controlRefs[0]);
        }

        [Test]
        public void With_Should_Add_OverflowArea_To_Current_Instance()
        {
            var overflowArea = new OverflowArea();
            _sut.With(() => overflowArea);
            Assert.AreEqual(1, _sut._overflowAreas.Count);
            Assert.AreEqual(overflowArea, _sut._overflowAreas[0]);
        }

        [Test]
        public void With_Should_Add_Strip_To_Current_Instance()
        {
            var strip = new Strip();
            _sut.With(() => strip);
            Assert.AreEqual(1, _sut._strips.Count);
            Assert.AreEqual(strip, _sut._strips[0]);
        }
    }
}