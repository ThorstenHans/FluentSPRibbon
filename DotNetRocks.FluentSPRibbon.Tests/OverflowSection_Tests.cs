using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class OverflowSection_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            // Arrange
            var sut = Create<OverflowSection>.Instance("Sample");
            // Assert
            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<OverflowSection>(sut);
        }

        [Test]
        public void If_Default_Constructor_Is_Called_DefaultValue_Should_Be_Stored_In_OriginalId()
        {
            // Arrange
            var sut = new OverflowSection();
            // Assert
            Assert.AreEqual("NotSet", sut.Id);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            var sut = new OverflowSection("MyOverflowSection");
            sut.Set(OverflowSectionProperty.TemplateAlias, "My OverflowSection");

            Assert.AreEqual("My OverflowSection", 
                sut.GetProperty(OverflowSectionProperty.TemplateAlias));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            var sut = new OverflowSection("MyOverflowSection");
            sut.Set(new Dictionary<OverflowSectionProperty, string>()
                                  {
                                      {OverflowSectionProperty.Type, "My OverflowSection Type"},
                                      {OverflowSectionProperty.TemplateAlias, "My OverflowSection"}
                                  });
            Assert.AreEqual("My OverflowSection Type", sut.GetProperty(OverflowSectionProperty.Type));
            Assert.AreEqual("My OverflowSection", sut.GetProperty(OverflowSectionProperty.TemplateAlias));
        }

        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode_For_Current_Instance()
        {
            // Arrange
            var sut = new OverflowSection("OverflowSection");
            var actual = OverflowSectionDisplayMode.Medium;
            // Act
            sut.SetDisplayMode(actual);
            // Assert
            Assert.AreEqual(actual, sut.GetDisplayMode());
        }
    }
}