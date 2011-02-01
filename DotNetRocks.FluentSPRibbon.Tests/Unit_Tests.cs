using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Unit_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            // Arrange
            var sut = Create<Unit>.Instance("MyUnit");
            // Assert
            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<Unit>(sut);
            Assert.AreEqual("MyUnit",sut.Id);
        }

        [Test]
        public void If_Default_Constructor_Is_Called_Default_Value_Should_Be_Stored_In_OriginalId()
        {
            // Arrange
            var sut = new Unit();
            // Assert
            Assert.AreEqual("NotSet",sut.OriginalId);
        }

        [Test]
        public void IsIdProvider_Should_Be_False()
        {
            // Arrange
            var sut = new Unit("MyUnit");
            // Assert
            Assert.IsFalse(sut.IsIdProvider);
        }


    }
}