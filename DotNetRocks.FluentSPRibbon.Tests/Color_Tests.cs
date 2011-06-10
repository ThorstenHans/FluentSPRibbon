using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Color_Tests
    {
        private Color _sut;

        [SetUp]
        public void Setup()
        {
            _sut = Color.Create("MyColor");
        }

        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<Color>(_sut);
        }

        [Test]
        public void IsIdProvider_Should_Be_False()
        {
            Assert.IsFalse(_sut.IsIdProvider);
        }

        [Test]
        public void Id_Should_Not_Be_Exported_To_Xml()
        {
            _sut.Set(ColorProperty.Title, "Red");
            var actual = _sut.ToXml();
            Assert.IsFalse(actual.Contains("Id"));
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            _sut.Set(ColorProperty.Title, "My Color");
            Assert.AreEqual("My Color", _sut.Get(ColorProperty.Title));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            _sut.Set(new Dictionary<ColorProperty, string>()
                                  {
                                      {ColorProperty.Title, "My Color"},
                                      {ColorProperty.DisplayColor, "Red"}
                                  });
            Assert.AreEqual("My Color", _sut.Get(ColorProperty.Title));
            Assert.AreEqual("Red", _sut.Get(ColorProperty.DisplayColor));
        }
    }
}
