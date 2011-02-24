using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Section_Tests
    {
        private Section _sut;

        [SetUp]
        public void Setup()
        {
            _sut = Section.Create("MySection");
        }
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<Section>(_sut);
        }

        [Test]
        public void IsIdProvider_Should_Be_False()
        {
            Assert.IsFalse(_sut.IsIdProvider);
        }

        [Test]
        public void With_Should_Add_Row_To_Current_Instance()
        {
            var row = new Row();
            _sut.With(() => row);
            Assert.AreEqual(1, _sut._rows.Count);
            Assert.AreEqual(row, _sut._rows[0]);
        }
    }
}