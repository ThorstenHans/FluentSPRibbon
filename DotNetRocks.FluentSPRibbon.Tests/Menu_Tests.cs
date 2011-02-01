using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Menu_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Menu_Instance()
        {
            // Arrange
            var sut = Create<Menu>.Instance("MyMenu");
            // Assert
            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<Menu>(sut);
        }

        [Test]
        public void If_Default_Constructor_Is_Called_DefaultValue_Should_Be_Stored_In_OriginalId()
        {
            // Arrange
            var sut = new Menu();
            // Assert
            Assert.AreEqual("NotSet",sut.OriginalId);
        }

        [Test]
        public void PassedParameter_Is_Applied_To_OriginalId_When_Constructor_Is_Called()
        {
            // Arrange
            var sut = new Menu("MyMenu");
            // Assert
            Assert.AreEqual("MyMenu",sut.OriginalId);
        }
        [Test]
        public void Indexer_Should_Return_MenuSection()
        {
            var sut = new Menu("MyMenu");
            var actual = new MenuSection("MyMenuSection");
            sut._menuSections.Add(actual);

            Assert.AreEqual(actual, sut["MyMenuSection"]);
        }

        [Test]
        public void With_Should_Add_Current_MenuSection_And_Set_Parent()
        {
            var sut = new Menu("MyMenu");
            var actual = new MenuSection("MyMenuSection");
            sut.With(() => actual);

            Assert.IsTrue(sut._menuSections.Contains(actual));
            Assert.AreEqual(actual.Parent,sut);
        }

        [Test]
        public void Set_Should_Add_Property_To_Current_Instance()
        {
            var sut = new Menu("MyMenu");
            sut.Set(MenuProperty.MaxWidth,"200");

            Assert.AreEqual("200",sut.Get(MenuProperty.MaxWidth));
        }

        [Test]
        public void Set_Should_Set_Multiple_Properties_To_Current_Instance()
        {
            var sut = new Menu("MyMenu");
            sut.Set(new Dictionary<MenuProperty, string>(){{MenuProperty.MaxWidth, "200"}});

            Assert.AreEqual("200", sut.Get(MenuProperty.MaxWidth));
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            // Arrange
            var sut = new Menu("MyMenu");
            // Assert
            Assert.IsTrue(sut.IsIdProvider);
        }


    }
}
