using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class UnitAbbreviation_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            // Arrange
            var sut = Create<UnitAbbreviation>.Instance("MyUnitAbbreviation");
            // Assert
            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<UnitAbbreviation>(sut);
            Assert.AreEqual("MyUnitAbbreviation", sut.Id);
        }

        [Test]
        public void If_Default_Constructor_Is_Called_Default_Value_Should_Be_Stored_In_OriginalId()
        {
            // Arrange
            var sut = new UnitAbbreviation();
            // Assert
            Assert.AreEqual("NotSet", sut.OriginalId);
        }

        [Test]
        public void IsIdProvider_Should_Be_False()
        {
            // Arrange
            var sut = new UnitAbbreviation("MyUnitAbbreviation");
            // Assert
            Assert.IsFalse(sut.IsIdProvider);
        }
        
    }
}