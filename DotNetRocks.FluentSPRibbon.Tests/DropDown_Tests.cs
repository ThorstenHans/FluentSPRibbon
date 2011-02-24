using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class DropDown_Tests
    {
        private DropDown _sut;

        [SetUp]
        public void Setup()
        {
            _sut = DropDown.Create("MyDropDown");
        }
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<DropDown>(_sut);
            Assert.AreEqual("MyDropDown", _sut.Id);
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            Assert.AreEqual("MyDropDown", _sut.OriginalId);
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

            Assert.AreEqual("MyRibbon.CommonTab.ActionGroup1.MyDropDown", _sut.Id);
        }

        [Test]
        public void Id_Should_Not_Be_Composited_If_Parent_Is_Not_Present()
        {
            Assert.AreEqual("MyDropDown", _sut.Id);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            _sut.Set(DropDownProperty.ToolTipTitle, "My DropDown");
            Assert.AreEqual("My DropDown", _sut.Get(DropDownProperty.ToolTipTitle));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            _sut.Set(new Dictionary<DropDownProperty, string>()
                                  {
                                      {DropDownProperty.ToolTipTitle, "My DropDown ToolTip"},
                                      {DropDownProperty.Alt, "My DropDown"}
                                  });
            Assert.AreEqual("My DropDown ToolTip", _sut.Get(DropDownProperty.ToolTipTitle));
            Assert.AreEqual("My DropDown", _sut.Get(DropDownProperty.Alt));
        }

        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode_For_Current_Instance()
        {
            var actual = DropDownDisplayMode.Medium;
            _sut.SetDisplayMode(actual);
            Assert.AreEqual(actual.ToString(),_sut.GetDisplayMode());
        }
    }
}