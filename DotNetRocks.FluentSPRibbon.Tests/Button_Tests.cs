using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Button_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            var sut = Create<Button>.Instance("MyButton");
            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<Button>(sut);
            Assert.AreEqual("MyButton",sut.Id);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            var sut = new Button("MyButton");
            sut.Set(ButtonProperty.LabelText, "My Button");

            Assert.AreEqual("My Button",sut.Get(ButtonProperty.LabelText));
        }

        [Test] 
        public void Set_Should_Store_MultipleValues()
        {
            var sut = new Button("MyButton");
            sut.Set(new Dictionary<ButtonProperty, string>()
                                  {
                                      {ButtonProperty.ToolTipTitle, "My Button ToolTip"},
                                      {ButtonProperty.LabelText, "My Button"}
                                  });
            Assert.AreEqual("My Button ToolTip", sut.Get(ButtonProperty.ToolTipTitle));
            Assert.AreEqual("My Button",sut.Get(ButtonProperty.LabelText));
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            var sut = new Button("My Button");
            Assert.IsTrue(sut.IsIdProvider);
        }


        [Test]
        public void Id_Should_Be_Compsited_If_Parent_Is_Present()
        {
            var sut = new Button("Button1");
            var group = new Group("ActionGroup1");
            var tab = new Tab("CommonTab");
            var ribbon = new Ribbon("MyRibbon");
            ribbon.With(() => tab
                                  .With(() => group
                                                  .With(() => sut)));

            Assert.AreEqual("MyRibbon.CommonTab.ActionGroup1.Button1", sut.Id);
        }

        [Test]
        public void Id_Should_Not_Be_Composited_If_Parent_Is_Not_Present()
        {
            var sut = new Button("MyButton");
            Assert.AreEqual("MyButton", sut.Id);
        }

        [Test]
        public void SetDisplayMode_Should_Store_Passed_DisplayMode_For_Current_Instance()
        {
            // Arrange
            var sut = new Button();

            // Act
            sut.SetDisplayMode(DisplayMode.Medium);

            // Assert
            Assert.AreEqual("Medium",sut._templateProperties["DisplayMode"]);
        }

       



    }
}