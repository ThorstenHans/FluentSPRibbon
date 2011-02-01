using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Label_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            var sut = Create<Label>.Instance("MyLabel");

            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<Label>(sut);
            Assert.AreEqual("MyLabel", sut.Id);
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            var sut = new Label("MyLabel");
            Assert.AreEqual("MyLabel", sut.OriginalId);
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            var sut = new Label("MyLabel");
            Assert.IsTrue(sut.IsIdProvider);
        }

        [Test]
        public void Id_Should_Be_Compsited_If_Parent_Is_Present()
        {
            var sut = new Label("Label1");
            var group = new Group("ActionGroup1");
            var tab = new Tab("CommonTab");
            var ribbon = new Ribbon("MyRibbon");
            ribbon.With(() => tab
                                  .With(() => group
                                                  .With(() => sut)));

            Assert.AreEqual("MyRibbon.CommonTab.ActionGroup1.Label1", sut.Id);
        }

        [Test]
        public void Id_Should_Not_Be_Composited_If_Parent_Is_Not_Present()
        {
            var sut = new Label("MyLabel");
            Assert.AreEqual("MyLabel", sut.Id);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            var sut = new Label("MyLabel");
            sut.Set(LabelProperty.LabelText, "My Label");

            Assert.AreEqual("My Label", sut.Get(LabelProperty.LabelText));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            var sut = new Label("MyLabel");
            sut.Set(new Dictionary<LabelProperty, string>()
                                  {
                                      {LabelProperty.LabelText, "My Label ToolTip"},
                                      {LabelProperty.TemplateAlias, "My Label"}
                                  });
            Assert.AreEqual("My Label ToolTip", sut.Get(LabelProperty.LabelText));
            Assert.AreEqual("My Label", sut.Get(LabelProperty.TemplateAlias));
        }

        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode_For_Current_Instance()
        {
            // Arrange
            var sut = new Label("Label");
            var actual = LabelDisplayMode.Medium;
            // Act
            sut.SetDisplayMode(actual);
            // Assert
            Assert.AreEqual(actual.ToString(), sut.GetDisplayMode());
        }
    }
}