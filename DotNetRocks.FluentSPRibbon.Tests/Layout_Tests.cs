using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Layout_Tests
    {
        private Layout _sut;

        [SetUp]
        public void Setup()
        {
            _sut = Layout.Create("MyLayout", "Title");
        }

        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<Layout>(_sut);
            Assert.AreEqual("MyLayout", _sut.Id);
        }

        [Test]
        public void IsIdProvider_Should_Be_False()
        {
            Assert.IsFalse(_sut.IsIdProvider);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            _sut.Set(LayoutProperty.Title, "My LayoutName");
            Assert.AreEqual("My LayoutName", _sut.Get(LayoutProperty.Title));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            _sut.Set(new Dictionary<LayoutProperty, string>()
                                  {
                                      {LayoutProperty.Title, "My LayoutName"}
                                  });
            Assert.AreEqual("My LayoutName", _sut.Get(LayoutProperty.Title));
        }

        [Test]
        public void With_Should_Add_New_OverflowSection()
        {
            var expected = OverflowSection.Create("OverflowSection");
            _sut.With(() => expected);
            Assert.IsNotNull(_sut._overflowSections);
            Assert.AreEqual(1, _sut._overflowSections.Count);
        } 
    }
}