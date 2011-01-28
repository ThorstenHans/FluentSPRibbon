using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Color_Tests
    {
        [Test]
        public void Id_Should_Not_Be_Exported_To_Xml()
        {
            var sut = new Color("MyColor");
            sut.ApplyProperty(ColorProperty.Title, "Red");
            var actual = sut.ToXml();
            Assert.IsFalse(actual.Contains("Id"));
        }
    }
}
