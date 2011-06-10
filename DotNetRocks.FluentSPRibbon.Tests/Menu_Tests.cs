using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Menu_Tests
    {
        private Menu _sut;

        [SetUp]
        public void Setup()
        {
            _sut = Menu.Create("MyMenu");
        }
        [Test]
        public void Create_Should_Create_A_New_Menu_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<Menu>(_sut);
        }

        [Test]
        public void PassedParameter_Is_Applied_To_OriginalId_When_Constructor_Is_Called()
        {
            Assert.AreEqual("MyMenu",_sut.OriginalId);
        }
        [Test]
        public void Indexer_Should_Return_MenuSection()
        {
            var actual = new MenuSection("MyMenuSection");
            _sut._menuSections.Add(actual);
            Assert.AreEqual(actual, _sut["MyMenuSection"]);
        }

        [Test]
        public void With_Should_Add_Current_MenuSection_And_Set_Parent()
        {
            var actual = new MenuSection("MyMenuSection");
            _sut.With(() => actual);
            Assert.IsTrue(_sut._menuSections.Contains(actual));
            Assert.AreEqual(actual.Parent,_sut);
        }

        [Test]
        public void Set_Should_Add_Property_To_Current_Instance()
        {
            _sut.Set(MenuProperty.MaxWidth,"200");
            Assert.AreEqual("200",_sut.Get(MenuProperty.MaxWidth));
        }

        [Test]
        public void Set_Should_Set_Multiple_Properties_To_Current_Instance()
        {
            _sut.Set(new Dictionary<MenuProperty, string>(){{MenuProperty.MaxWidth, "200"}});
            Assert.AreEqual("200", _sut.Get(MenuProperty.MaxWidth));
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            Assert.IsTrue(_sut.IsIdProvider);
        }
    }
}
