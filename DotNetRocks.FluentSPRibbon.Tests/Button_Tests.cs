using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Button_Tests
    {
        private Button _sut;

        [SetUp]
        public void Setup()
        {
            _sut = Button.Create("MyButton");
        }

        [Test]
        public void GetControlRef_Should_Return_A_Correct_ControlRef_Instance()
        {
            _sut.SetDisplayMode(ButtonDisplayMode.Large);
            var actual = _sut.GetControlRef();
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf<ControlRef>(actual);
            Assert.AreEqual(ControlRefDisplayMode.Large, actual.GetDisplayMode());
        }

        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<Button>(_sut);
            Assert.AreEqual("MyButton", _sut.Id);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            _sut.Set(ButtonProperty.LabelText, "My Button");
            Assert.AreEqual("My Button", _sut.Get(ButtonProperty.LabelText));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            _sut.Set(new Dictionary<ButtonProperty, string>()
                                  {
                                      {ButtonProperty.ToolTipTitle, "My Button ToolTip"},
                                      {ButtonProperty.LabelText, "My Button"}
                                  });
            Assert.AreEqual("My Button ToolTip", _sut.Get(ButtonProperty.ToolTipTitle));
            Assert.AreEqual("My Button", _sut.Get(ButtonProperty.LabelText));
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

            Assert.AreEqual("MyRibbon.CommonTab.ActionGroup1.MyButton", _sut.Id);
        }

        [Test]
        public void Id_Should_Not_Be_Composited_If_Parent_Is_Not_Present()
        {
            Assert.AreEqual("MyButton", _sut.Id);
        }

        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode_For_Current_Instance()
        {
            var actual = ButtonDisplayMode.Medium;
            _sut.SetDisplayMode(actual);
            Assert.AreEqual(actual.ToString(), _sut.GetDisplayMode());
        }
    }
}