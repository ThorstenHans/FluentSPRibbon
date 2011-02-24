using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class ComboBox_Tests
    {
        private ComboBox _sut;

        [SetUp]
        public void Setup()
        {
            _sut = ComboBox.Create("MyComboBox");
        }

        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<ComboBox>(_sut);
            Assert.AreEqual("MyComboBox", _sut.Id);
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            Assert.AreEqual("MyComboBox", _sut.OriginalId);
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            Assert.IsTrue(_sut.IsIdProvider);
        }

        [Test]
        public void Id_Should_Be_Compsited_If_Parent_Is_Present()
        {
            var group = new Group("ActionGroup1");
            var tab = new Tab("CommonTab");
            var ribbon = new Ribbon("MyRibbon");
            ribbon.With(() => tab
                                  .With(() => group
                                                  .With(() => _sut)));

            Assert.AreEqual("MyRibbon.CommonTab.ActionGroup1.MyComboBox", _sut.Id);
        }

        [Test]
        public void Id_Should_Not_Be_Composited_If_Parent_Is_Not_Present()
        {
            Assert.AreEqual("MyComboBox", _sut.Id);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            _sut.Set(ComboBoxProperty.ToolTipTitle, "My ComboBox");
            Assert.AreEqual("My ComboBox", _sut.Get(ComboBoxProperty.ToolTipTitle));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            _sut.Set(new Dictionary<ComboBoxProperty, string>()
                                  {
                                      {ComboBoxProperty.ToolTipTitle, "My ComboBox ToolTip"},
                                      {ComboBoxProperty.Alt, "My ComboBox"}
                                  });
            Assert.AreEqual("My ComboBox ToolTip", _sut.Get(ComboBoxProperty.ToolTipTitle));
            Assert.AreEqual("My ComboBox", _sut.Get(ComboBoxProperty.Alt));
        }

        [Test]
        public void It_Should_Be_Possible_To_Set_Menu_On_ComboBox()
        {
            var menu = new Menu("MyMenu");
            _sut.With(() => menu);
            Assert.IsNotNull(_sut.Menu);
            Assert.AreEqual(menu,_sut.Menu);
            Assert.AreEqual(_sut,menu.Parent);
        }

        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode_For_Current_Instance()
        {
            var actual = ComboBoxDisplayMode.Medium;
            _sut.SetDisplayMode(actual);
            Assert.AreEqual(actual.ToString(), _sut.GetDisplayMode());
        }
    }
}