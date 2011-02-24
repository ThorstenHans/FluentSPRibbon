using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class MRUSplitButton_Tests
    {
        private MRUSplitButton _sut;

        [SetUp]
        public void Setup()
        {
            _sut = MRUSplitButton.Create("MyMRUSplitButton");
        }
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<MRUSplitButton>(_sut);
            Assert.AreEqual("MyMRUSplitButton", _sut.Id);
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            Assert.AreEqual("MyMRUSplitButton", _sut.OriginalId);
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
            Assert.AreEqual("MyRibbon.CommonTab.ActionGroup1.MyMRUSplitButton", _sut.Id);
        }

        [Test]
        public void Id_Should_Not_Be_Composited_If_Parent_Is_Not_Present()
        {
            Assert.AreEqual("MyMRUSplitButton", _sut.Id);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            _sut.Set(MRUProperty.ToolTipTitle, "My MRUSplitButton");
            Assert.AreEqual("My MRUSplitButton", _sut.Get(MRUProperty.ToolTipTitle));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            _sut.Set(new Dictionary<MRUProperty, string>()
                                  {
                                      {MRUProperty.ToolTipTitle, "My MRUSplitButton ToolTip"},
                                      {MRUProperty.Alt, "My MRUSplitButton"}
                                  });
            Assert.AreEqual("My MRUSplitButton ToolTip", _sut.Get(MRUProperty.ToolTipTitle));
            Assert.AreEqual("My MRUSplitButton", _sut.Get(MRUProperty.Alt));
        }

        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode_For_Current_Instance()
        {
            var actual = MRUDisplayMode.Large;
            _sut.SetDisplayMode(actual);
            Assert.AreEqual(actual.ToString(), _sut.GetDisplayMode());
        }


        [Test]
        public void MRuSplitButton_Should_Be_Able_To_Store_A_Menu()
        {
            var menu = Menu.Create("MyMenu");
            _sut.With(() => menu);
            Assert.AreEqual(menu,_sut.GetMenu());
        }
    }
}