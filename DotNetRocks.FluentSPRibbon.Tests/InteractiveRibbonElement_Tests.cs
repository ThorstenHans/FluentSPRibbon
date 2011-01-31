using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class InteractiveRibbonElement_Tests
    {
        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            // Arrange
            var sut = new InteractiveRibbonElement("MyId");
            // Assert
            Assert.AreEqual("MyId", sut.OriginalId);

        }

        [Test]
        public void SetDisplayMode_Should_Store_Value_In_TemplateProperties()
        {
            // Arrange
            var sut = new InteractiveRibbonElement("MyId");
            // Act
            sut.SetDisplayModeTo(DisplayMode.Menu16);

            // Assert
            Assert.AreEqual(DisplayMode.Menu16.ToString(), sut._templateProperties["DisplayMode"]);
        }

        [Test]
        public void If_ParameterLess_Constructor_Is_Called_Default_Value_Should_Be_Stored_In_OriginalId()
        {
            // Arrange
            var sut = new InteractiveRibbonElement();
            // Assert
            Assert.AreEqual("NotSet",sut.OriginalId);

        }
    }
}