using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Menu_Tests
    {
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
        public void SetWidthTo_Should_Add_Property_To_Current_Instance()
        {
            var sut = new Menu("MyMenu");
            sut.Set(MenuProperty.MaxWidth,"200");

            Assert.AreEqual("200",sut.Get(MenuProperty.MaxWidth));
        }

    }
}
