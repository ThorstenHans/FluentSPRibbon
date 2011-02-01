using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class SplitButton_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            var sut = Create<SplitButton>.Instance("MySplitButton");

            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<SplitButton>(sut);
            Assert.AreEqual("MySplitButton", sut.Id);
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            var sut = new SplitButton("MySplitButton");
            Assert.AreEqual("MySplitButton", sut.OriginalId);
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            var sut = new SplitButton("MySplitButton");
            Assert.IsTrue(sut.IsIdProvider);
        }

        [Test]
        public void Id_Should_Be_Compsited_If_Parent_Is_Present()
        {
            var sut = new SplitButton("SplitButton1");
            var group = new Group("ActionGroup1");
            var tab = new Tab("CommonTab");
            var ribbon = new Ribbon("MyRibbon");
            ribbon.With(() => tab
                                  .With(() => group
                                                  .With(() => sut)));

            Assert.AreEqual("MyRibbon.CommonTab.ActionGroup1.SplitButton1", sut.Id);
        }

        [Test]
        public void Id_Should_Not_Be_Composited_If_Parent_Is_Not_Present()
        {
            var sut = new SplitButton("MySplitButton");
            Assert.AreEqual("MySplitButton", sut.Id);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            var sut = new SplitButton("MySplitButton");
            sut.Set(SplitButtonProperty.LabelText, "My SplitButton");

            Assert.AreEqual("My SplitButton", sut.Get(SplitButtonProperty.LabelText));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            var sut = new SplitButton("MySplitButton");
            sut.Set(new Dictionary<SplitButtonProperty, string>()
                                  {
                                      {SplitButtonProperty.LabelText, "My SplitButton ToolTip"},
                                      {SplitButtonProperty.TemplateAlias, "My SplitButton"}
                                  });
            Assert.AreEqual("My SplitButton ToolTip", sut.Get(SplitButtonProperty.LabelText));
            Assert.AreEqual("My SplitButton", sut.Get(SplitButtonProperty.TemplateAlias));
        }

        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode_For_Current_Instance()
        {
            // Arrange
            var sut = new SplitButton("SplitButton");
            var actual = SplitButtonDisplayMode.Medium;
            // Act
            sut.SetDisplayMode(actual);
            // Assert
            Assert.AreEqual(actual.ToString(), sut.GetDisplayMode());
        }
    }
}