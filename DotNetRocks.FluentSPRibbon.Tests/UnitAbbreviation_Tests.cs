using System.Collections.Generic;
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

        [Test]
        public void Set_Should_Store_Value()
        {
            var sut = new UnitAbbreviation("MyTextBox");
            sut.Set(UnitAbbreviationProperty.Value, "My TextBox");

            Assert.AreEqual("My TextBox", sut.Get(UnitAbbreviationProperty.Value));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            var sut = new UnitAbbreviation("UnitAbbreviation");
            sut.Set(new Dictionary<UnitAbbreviationProperty, string>()
                                  {
                                      {UnitAbbreviationProperty.Value, "My UnitAbbreviation Value"},
                                      {UnitAbbreviationProperty.Sequence, "100"}
                                  });
            Assert.AreEqual("My UnitAbbreviation Value", sut.Get(UnitAbbreviationProperty.Value));
            Assert.AreEqual("100", sut.Get(UnitAbbreviationProperty.Sequence));
        }
        
    }
}