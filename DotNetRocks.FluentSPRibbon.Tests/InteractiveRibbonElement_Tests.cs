using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class InteractiveRibbonElement_Tests
    {
        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode()
        {
            var sut = new Button();
            sut.SetDisplayMode(ButtonDisplayMode.Large);
            Assert.AreEqual(ButtonDisplayMode.Large.ToString(),sut.GetDisplayMode());
        }

        [Test]
        public void SetDisplayMode_Should_Update_Existing_DisplayMode()
        {
            var sut = new ToggleButton();
            var actual = ToggleButtonDisplayMode.Large;
            sut.SetDisplayMode(ToggleButtonDisplayMode.Medium);
            sut.SetDisplayMode(actual);
            Assert.AreEqual(actual.ToString(), sut.GetDisplayMode());
        }
    }
}