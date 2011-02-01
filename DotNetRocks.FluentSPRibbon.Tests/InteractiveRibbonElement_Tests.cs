using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class InteractiveRibbonElement_Tests
    {
        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode()
        {
            // Arrange
            var sut = new Button();
            // Act
            sut.SetDisplayMode(ButtonDisplayMode.Large);
            // Assert
            Assert.AreEqual(ButtonDisplayMode.Large.ToString(),sut.GetDisplayMode());
        }

        [Test]
        public void SetDisplayMode_Should_Update_Existing_DisplayMode()
        {
            // Arrange
            var sut = new ToggleButton();
            var actual = ToggleButtonDisplayMode.Large;
            // Act
            sut.SetDisplayMode(ToggleButtonDisplayMode.Medium);
            sut.SetDisplayMode(actual);
            // Assert
            Assert.AreEqual(actual.ToString(), sut.GetDisplayMode());
        }
    }
}