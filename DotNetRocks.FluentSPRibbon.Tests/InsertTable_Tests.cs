using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class InsertTable_Tests
    {
        private InsertTable _sut;

        [SetUp]
        public void Setup()
        {
            _sut = InsertTable.Create("MyInsertTable");
        }

        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<InsertTable>(_sut);
            Assert.AreEqual("MyInsertTable", _sut.Id);
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            Assert.AreEqual("MyInsertTable", _sut.OriginalId);
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            Assert.IsTrue(_sut.IsIdProvider);
        }

        [Test]
        public void Id_Should_Be_Compsited_If_Parent_Is_Present()
        {
            var menuSection = new MenuSection("MyMenuSection");
            var menu = new Menu("MyMenu");
            var comboBox = new ComboBox("MyComboBox");
            var group = new Group("MyGroup");
            var tab = new Tab("MyTab");
            var ribbon = new Ribbon("MyRibbon");
            ribbon.With(() => tab
                                  .With(() => group
                                                  .With(() => comboBox.With(()=>menu.With(()=>menuSection.With(()=>_sut))))));

            Assert.AreEqual("MyRibbon.MyTab.MyGroup.MyComboBox.MyMenu.MyMenuSection.MyInsertTable", _sut.Id);
        }

        [Test]
        public void Id_Should_Not_Be_Composited_If_Parent_Is_Not_Present()
        {
            Assert.AreEqual("MyInsertTable", _sut.Id);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            _sut.Set(InsertTableProperty.Alt, "My InsertTable");
            Assert.AreEqual("My InsertTable", _sut.Get(InsertTableProperty.Alt));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            _sut.Set(new Dictionary<InsertTableProperty, string>()
                                  {
                                      {InsertTableProperty.Alt, "My InsertTable Alt"},
                                      {InsertTableProperty.MenuSectionTitle, "My InsertTable"}
                                  });
            Assert.AreEqual("My InsertTable Alt", _sut.Get(InsertTableProperty.Alt));
            Assert.AreEqual("My InsertTable", _sut.Get(InsertTableProperty.MenuSectionTitle));
        }

        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode_For_Current_Instance()
        {
            var actual = InsertTableDisplayMode.Menu;
            _sut.SetDisplayMode(actual);
            Assert.AreEqual(actual.ToString(), _sut.GetDisplayMode());
        }
    }
}