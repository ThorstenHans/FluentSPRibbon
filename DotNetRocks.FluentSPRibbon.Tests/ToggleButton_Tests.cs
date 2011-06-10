using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class ToggleButton_Tests
    {
        private ToggleButton _sut;

        [SetUp]
        public void Setup()
        {
            _sut = ToggleButton.Create("MyToggleButton");
        }
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<ToggleButton>(_sut);
            Assert.AreEqual("MyToggleButton", _sut.Id);
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            Assert.AreEqual("MyToggleButton", _sut.OriginalId);
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
            Assert.AreEqual("MyRibbon.CommonTab.ActionGroup1.MyToggleButton", _sut.Id);
        }

        [Test]
        public void Id_Should_Not_Be_Composited_If_Parent_Is_Not_Present()
        {
            Assert.AreEqual("MyToggleButton", _sut.Id);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            _sut.Set(ToggleButtonProperty.ToolTipTitle, "My ToggleButton");
            Assert.AreEqual("My ToggleButton", _sut.Get(ToggleButtonProperty.ToolTipTitle));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            _sut.Set(new Dictionary<ToggleButtonProperty, string>()
                                  {
                                      {ToggleButtonProperty.ToolTipTitle, "My ToggleButton ToolTip"},
                                      {ToggleButtonProperty.TemplateAlias, "My ToggleButton"}
                                  });
            Assert.AreEqual("My ToggleButton ToolTip", _sut.Get(ToggleButtonProperty.ToolTipTitle));
            Assert.AreEqual("My ToggleButton", _sut.Get(ToggleButtonProperty.TemplateAlias));
        }

        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode_For_Current_Instance()
        {
            var actual = ToggleButtonDisplayMode.Medium;
            _sut.SetDisplayMode(actual);
            Assert.AreEqual(actual.ToString(), _sut.GetDisplayMode());
        }
    }
}