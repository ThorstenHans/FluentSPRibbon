using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class TextBox_Tests
    {
        private TextBox _sut;

        [SetUp]
        public void Setup()
        {
            _sut = TextBox.Create("MyTextBox");
        }
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<TextBox>(_sut);
            Assert.AreEqual("MyTextBox", _sut.Id);
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            Assert.AreEqual("MyTextBox", _sut.OriginalId);
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
            Assert.AreEqual("MyRibbon.CommonTab.ActionGroup1.MyTextBox", _sut.Id);
        }

        [Test]
        public void Id_Should_Not_Be_Composited_If_Parent_Is_Not_Present()
        {
            Assert.AreEqual("MyTextBox", _sut.Id);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            _sut.Set(TextBoxProperty.ToolTipTitle, "My TextBox");
            Assert.AreEqual("My TextBox", _sut.Get(TextBoxProperty.ToolTipTitle));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            _sut.Set(new Dictionary<TextBoxProperty, string>()
                                  {
                                      {TextBoxProperty.ToolTipTitle, "My TextBox ToolTip"},
                                      {TextBoxProperty.TemplateAlias, "My TextBox"}
                                  });
            Assert.AreEqual("My TextBox ToolTip", _sut.Get(TextBoxProperty.ToolTipTitle));
            Assert.AreEqual("My TextBox", _sut.Get(TextBoxProperty.TemplateAlias));
        }

        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode_For_Current_Instance()
        {
            var actual = TextBoxDisplayMode.Medium;
            _sut.SetDisplayMode(actual);
            Assert.AreEqual(actual.ToString(), _sut.GetDisplayMode());
        }
    }
}