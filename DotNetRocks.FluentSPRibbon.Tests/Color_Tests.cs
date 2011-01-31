using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    
    [TestFixture]
    public class Color_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            var sut = Create<Color>.Instance("MyColor");
            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<Color>(sut);
        }

        [Test]
        public void IsIdProvider_Should_Be_False()
        {
            var sut = new Color("MyColor");

            Assert.IsFalse(sut.IsIdProvider);
        }

        [Test]
        public void Id_Should_Not_Be_Exported_To_Xml()
        {
            var sut = new Color("MyColor");
            sut.Set(ColorProperty.Title, "Red");
            var actual = sut.ToXml();
            Assert.IsFalse(actual.Contains("Id"));
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            var sut = new Color("My Color");
            sut.Set(ColorProperty.Title, "My Color");

            Assert.AreEqual("My Color", sut.Get(ColorProperty.Title));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            var sut = new Color("MyColor");
            sut.Set(new Dictionary<ColorProperty, string>()
                                  {
                                      {ColorProperty.Title, "My Color"},
                                      {ColorProperty.DisplayColor, "Red"}
                                  });
            Assert.AreEqual("My Color", sut.Get(ColorProperty.Title));
            Assert.AreEqual("Red", sut.Get(ColorProperty.DisplayColor));
        }
    }
}
