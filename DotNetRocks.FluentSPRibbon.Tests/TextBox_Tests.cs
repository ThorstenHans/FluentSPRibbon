using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class TextBox_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            var sut = Create<TextBox>.Instance("MyTextBox");

            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<TextBox>(sut);
            Assert.AreEqual("MyTextBox", sut.Id);
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            var sut = new TextBox("MyTextBox");
            Assert.AreEqual("MyTextBox", sut.OriginalId);
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            var sut = new TextBox("MyTextBox");
            Assert.IsTrue(sut.IsIdProvider);
        }

        [Test]
        public void Id_Should_Be_Compsited_If_Parent_Is_Present()
        {
            var sut = new TextBox("TextBox1");
            var group = new Group("ActionGroup1");
            var tab = new Tab("CommonTab");
            var ribbon = new Ribbon("MyRibbon");
            ribbon.With(() => tab
                                  .With(() => group
                                                  .With(() => sut)));

            Assert.AreEqual("MyRibbon.CommonTab.ActionGroup1.TextBox1", sut.Id);
        }

        [Test]
        public void Id_Should_Not_Be_Composited_If_Parent_Is_Not_Present()
        {
            var sut = new TextBox("MyTextBox");
            Assert.AreEqual("MyTextBox", sut.Id);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            var sut = new TextBox("MyTextBox");
            sut.Set(TextBoxProperty.ToolTipTitle, "My TextBox");

            Assert.AreEqual("My TextBox", sut.Get(TextBoxProperty.ToolTipTitle));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            var sut = new TextBox("MyTextBox");
            sut.Set(new Dictionary<TextBoxProperty, string>()
                                  {
                                      {TextBoxProperty.ToolTipTitle, "My TextBox ToolTip"},
                                      {TextBoxProperty.TemplateAlias, "My TextBox"}
                                  });
            Assert.AreEqual("My TextBox ToolTip", sut.Get(TextBoxProperty.ToolTipTitle));
            Assert.AreEqual("My TextBox", sut.Get(TextBoxProperty.TemplateAlias));
        }
    }
}