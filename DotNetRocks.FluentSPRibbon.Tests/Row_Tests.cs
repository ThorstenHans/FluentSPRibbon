using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Row_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            // Arrange
            var sut = Create<Row>.Instance("MyRow");
            // Assert
            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<Row>(sut);
        }

        [Test]
        public void IsIdProvider_Should_Be_False()
        {
            // Arrange
            var sut = new Row();
            // Assert
            Assert.IsFalse(sut.IsIdProvider);
        }

        [Test]
        public void With_Should_Add_ControlRef_To_Current_Instance()
        {
            // Arrange
            var sut = new Row();
            var controlRef = new ControlRef();
            // Act
            sut.With(() => controlRef);
            // Assert
            Assert.AreEqual(1,sut._controlRefs.Count);
            Assert.AreEqual(controlRef,sut._controlRefs[0]);
        }

        [Test]
        public void With_Should_Add_OverflowArea_To_Current_Instance()
        {
            // Arrange
            var sut = new Row();
            var overflowArea = new OverflowArea();
            // Act
            sut.With(() => overflowArea);
            // Assert
            Assert.AreEqual(1, sut._overflowAreas.Count);
            Assert.AreEqual(overflowArea, sut._overflowAreas[0]);
        }

        [Test]
        public void With_Should_Add_Strip_To_Current_Instance()
        {
            // Arrange
            var sut = new Row();
            var strip = new Strip();
            // Act
            sut.With(() => strip);
            // Assert
            Assert.AreEqual(1, sut._strips.Count);
            Assert.AreEqual(strip, sut._strips[0]);
        }
    }
}