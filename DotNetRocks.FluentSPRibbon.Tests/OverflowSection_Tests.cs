using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class OverflowSection_Tests
    {
        private OverflowSection _sut;

        [SetUp]
        public void Setup()
        {
            _sut = OverflowSection.Create("Sample");
        }

        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<OverflowSection>(_sut);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            _sut.Set(OverflowSectionProperty.TemplateAlias, "My OverflowSection");
            Assert.AreEqual("My OverflowSection", 
                _sut.GetProperty(OverflowSectionProperty.TemplateAlias));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            _sut.Set(new Dictionary<OverflowSectionProperty, string>()
                                  {
                                      {OverflowSectionProperty.Type, "My OverflowSection Type"},
                                      {OverflowSectionProperty.TemplateAlias, "My OverflowSection"}
                                  });
            Assert.AreEqual("My OverflowSection Type", _sut.GetProperty(OverflowSectionProperty.Type));
            Assert.AreEqual("My OverflowSection", _sut.GetProperty(OverflowSectionProperty.TemplateAlias));
        }

        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode_For_Current_Instance()
        {
            var actual = OverflowSectionDisplayMode.Medium;
            _sut.SetDisplayMode(actual);
            Assert.AreEqual(actual, _sut.GetDisplayMode());
        }
    }
}