using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class SplitButton_Tests
    {
        private SplitButton _sut;

        [SetUp]
        public void Setup()
        {
            _sut = SplitButton.Create("MySplitButton");
        }
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<SplitButton>(_sut);
            Assert.AreEqual("MySplitButton", _sut.Id);
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            Assert.AreEqual("MySplitButton", _sut.OriginalId);
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
            Assert.AreEqual("MyRibbon.CommonTab.ActionGroup1.MySplitButton", _sut.Id);
        }

        [Test]
        public void Id_Should_Not_Be_Composited_If_Parent_Is_Not_Present()
        {
            Assert.AreEqual("MySplitButton", _sut.Id);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            _sut.Set(SplitButtonProperty.LabelText, "My SplitButton");
            Assert.AreEqual("My SplitButton", _sut.Get(SplitButtonProperty.LabelText));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            _sut.Set(new Dictionary<SplitButtonProperty, string>()
                                  {
                                      {SplitButtonProperty.LabelText, "My SplitButton ToolTip"},
                                      {SplitButtonProperty.TemplateAlias, "My SplitButton"}
                                  });
            Assert.AreEqual("My SplitButton ToolTip", _sut.Get(SplitButtonProperty.LabelText));
            Assert.AreEqual("My SplitButton", _sut.Get(SplitButtonProperty.TemplateAlias));
        }

        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode_For_Current_Instance()
        {
            var actual = SplitButtonDisplayMode.Medium;
            _sut.SetDisplayMode(actual);
            Assert.AreEqual(actual.ToString(), _sut.GetDisplayMode());
        }
    }
}