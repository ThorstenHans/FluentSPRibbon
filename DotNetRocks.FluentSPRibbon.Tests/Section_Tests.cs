using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Section_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            // Arrange
            var sut = Create<Section>.Instance("MySection");
            // Assert
            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<Section>(sut);
        }

        [Test]
        public void IsIdProvider_Should_Be_False()
        {
            // Arrange
            var sut = new Section();
            // Assert
            Assert.IsFalse(sut.IsIdProvider);
        }

        [Test]
        public void With_Should_Add_Row_To_Current_Instance()
        {
            // Arrange
            var sut = new Section();
            var row = new Row();
            // Act
            sut.With(() => row);
            // Assert
            Assert.AreEqual(1, sut._rows.Count);
            Assert.AreEqual(row, sut._rows[0]);
        }
    }
}