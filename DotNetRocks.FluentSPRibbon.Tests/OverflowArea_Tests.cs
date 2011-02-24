using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class OverflowArea_Tests
    {
        private OverflowArea _sut;

        [SetUp]
        public void Setup()
        {
            _sut = OverflowArea.Create("Sample");
        }

        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<OverflowArea>(_sut);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            _sut.Set(OverflowAreaProperty.TemplateAlias, "My OverflowArea");

            Assert.AreEqual("My OverflowArea",
                _sut.GetProperty(OverflowAreaProperty.TemplateAlias));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            _sut.Set(new Dictionary<OverflowAreaProperty, string>()
                                  {
                                      {OverflowAreaProperty.TemplateAlias, "My OverflowArea"}
                                  });
            
            Assert.AreEqual("My OverflowArea", _sut.GetProperty(OverflowAreaProperty.TemplateAlias));
        }

        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode_For_Current_Instance()
        {
            var actual = OverflowAreaDisplayMode.Medium;
            _sut.SetDisplayMode(actual);
            Assert.AreEqual(actual, _sut.GetDisplayMode());
        } 
    }
}