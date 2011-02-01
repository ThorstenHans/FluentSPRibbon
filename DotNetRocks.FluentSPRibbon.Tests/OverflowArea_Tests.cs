using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class OverflowArea_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            // Arrange
            var sut = Create<OverflowArea>.Instance("Sample");
            // Assert
            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<OverflowArea>(sut);
        }

        [Test]
        public void If_Default_Constructor_Is_Called_DefaultValue_Should_Be_Stored_In_OriginalId()
        {
            // Arrange
            var sut = new OverflowArea();
            // Assert
            Assert.AreEqual("NotSet", sut.Id);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            var sut = new OverflowArea("MyOverflowArea");
            sut.Set(OverflowAreaProperty.TemplateAlias, "My OverflowArea");

            Assert.AreEqual("My OverflowArea",
                sut.GetProperty(OverflowAreaProperty.TemplateAlias));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            var sut = new OverflowArea("MyOverflowArea");
            sut.Set(new Dictionary<OverflowAreaProperty, string>()
                                  {
                                      {OverflowAreaProperty.TemplateAlias, "My OverflowArea"}
                                  });
            
            Assert.AreEqual("My OverflowArea", sut.GetProperty(OverflowAreaProperty.TemplateAlias));
        }

        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode_For_Current_Instance()
        {
            // Arrange
            var sut = new OverflowArea("OverflowArea");
            var actual = OverflowAreaDisplayMode.Medium;
            // Act
            sut.SetDisplayMode(actual);
            // Assert
            Assert.AreEqual(actual, sut.GetDisplayMode());
        } 
    }
}