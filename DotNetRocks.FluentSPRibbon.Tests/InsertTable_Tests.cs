using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class InsertTable_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            var sut = Create<InsertTable>.Instance("MyInsertTable");

            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<InsertTable>(sut);
            Assert.AreEqual("MyInsertTable", sut.Id);
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            var sut = new InsertTable("MyInsertTable");
            Assert.AreEqual("MyInsertTable", sut.OriginalId);
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            var sut = new InsertTable("MyInsertTable");
            Assert.IsTrue(sut.IsIdProvider);
        }

        [Test]
        public void Id_Should_Be_Compsited_If_Parent_Is_Present()
        {
            var sut = new InsertTable("InsertTable1");
            var menuSection = new MenuSection("MyMenuSection");
            var menu = new Menu("MyMenu");
            var comboBox = new ComboBox("MyComboBox");
            var group = new Group("MyGroup");
            var tab = new Tab("MyTab");
            var ribbon = new Ribbon("MyRibbon");
            ribbon.With(() => tab
                                  .With(() => group
                                                  .With(() => comboBox.With(()=>menu.With(()=>menuSection.With(()=>sut))))));

            Assert.AreEqual("MyRibbon.MyTab.MyGroup.MyComboBox.MyMenu.MyMenuSection.InsertTable1", sut.Id);
        }

        [Test]
        public void Id_Should_Not_Be_Composited_If_Parent_Is_Not_Present()
        {
            var sut = new InsertTable("MyInsertTable");
            Assert.AreEqual("MyInsertTable", sut.Id);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            var sut = new InsertTable("MyInsertTable");
            sut.Set(InsertTableProperty.Alt, "My InsertTable");

            Assert.AreEqual("My InsertTable", sut.Get(InsertTableProperty.Alt));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            var sut = new InsertTable("MyInsertTable");
            sut.Set(new Dictionary<InsertTableProperty, string>()
                                  {
                                      {InsertTableProperty.Alt, "My InsertTable Alt"},
                                      {InsertTableProperty.MenuSectionTitle, "My InsertTable"}
                                  });
            Assert.AreEqual("My InsertTable Alt", sut.Get(InsertTableProperty.Alt));
            Assert.AreEqual("My InsertTable", sut.Get(InsertTableProperty.MenuSectionTitle));
        }
    }
}