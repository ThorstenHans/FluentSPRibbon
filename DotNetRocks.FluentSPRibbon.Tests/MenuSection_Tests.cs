using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class MenuSection_Tests
    {
        [Test]
        public void It_Should_Be_Possible_To_Add_Multiple_Buttons()
        {
            // Arrange
            var sut = new MenuSection("MyMenuSection");
            var first = new Button("MyButton");
            var second = new Button("SecondButton");
            var third = new Button("ThirdButton");
            // Act
            sut.With(() => first).With(() => second).With(() => third);
            // Assert
            Assert.AreEqual(3,sut._buttons.Count);
        }

        [Test]
        public void It_Should_Be_Possible_To_Add_Multiple_ToggleButtons()
        {
            // Arrange
            var sut = new MenuSection("MyMenuSection");
            var first = new ToggleButton("MyToggleButton1");
            var second = new ToggleButton("MyToggleButton2");
            var third = new ToggleButton("MyToggleButton3");
            // Act
            sut.With(() => first).With(() => second).With(() => third);
            // Assert
            Assert.AreEqual(3, sut._toggleButtons.Count);
        }

        [Test]
        public void It_Should_Be_Possible_To_Add_Multiple_ColorPickers()
        {
            // Arrange
            var sut = new MenuSection("MyMenuSection");
            var first = new ColorPicker("MyColorPicker1");
            var second = new ColorPicker("MyColorPicker2");
            var third = new ColorPicker("MyColorPicker3");
            // Act
            sut.With(() => first).With(() => second).With(() => third);
            // Assert
            Assert.AreEqual(3, sut._colorPickers.Count);
        }

        [Test]
        public void It_Should_Be_Possible_To_Add_Multiple_FlyoutAnchors()
        {
            // Arrange
            var sut = new MenuSection("MyMenuSection");
            var first = new FlyoutAnchor("MyFlyoutAnchor");
            var second = new FlyoutAnchor("SecondFlyoutAnchor");
            var third = new FlyoutAnchor("ThirdFlyoutAnchor");
            // Act
            sut.With(() => first).With(() => second).With(() => third);
            // Assert
            Assert.AreEqual(3, sut._flyoutAnchors.Count);
        }

        [Test]
        public void It_Should_Be_Possible_To_Store_An_InsertTable()
        {
            // Arrange
            var sut = new MenuSection("MyMenuSection");
            var first = new InsertTable("MyInsertTable");
            // Act
            sut.With(() => first);
            // Assert
            Assert.AreEqual(first,sut._insertTable);
        }

        [Test]
        public void It_Should_OverWrite_An_Existing_InsertTable_Instance()
        {
            // Arrange
            var sut = new MenuSection("MyMenuSection");
            var first = new InsertTable("MyInsertTable");
            var second = new InsertTable("MySecondInsertTable");
            // Act
            sut.With(() => first).With(()=>second);
            // Assert
            Assert.AreEqual(second, sut._insertTable);
        }

        [Test]
        public void GetButton_Should_Find_And_Return_Correct_Button()
        {
            var sut = new MenuSection("MyMenuSection");
            var actual = new Button("MyButton");
            var fake = new Button("MyBUtton");
            sut._buttons.Add(actual);
            sut._buttons.Add(fake);

            Assert.AreEqual(actual,sut.GetButton("MyButton"));
        }

        [Test]
        public void GetToggleButton_Should_Find_And_Return_Correct_ToggleButton()
        {
            var sut = new MenuSection("MyMenuSection");
            var actual = new ToggleButton("MyToggleButton");
            var fake = new ToggleButton("MyToggleBUtton");
            sut._toggleButtons.Add(fake);
            sut._toggleButtons.Add(actual);

            Assert.AreEqual(actual, sut.GetToggleButton("MyToggleButton"));
        }

        [Test]
        public void GetColorPicker_Should_Find_And_Return_Correct_ColorPicker()
        {
            var sut = new MenuSection("MyMenuSection");
            var actual = new ColorPicker("MyColorPicker");
            var fake = new ColorPicker("MyMenuSection.MyColorPicker");

            sut._colorPickers.Add(actual);
            sut._colorPickers.Add(fake);
            

            Assert.AreEqual(actual,sut.GetColorPicker("MyColorPicker"));
        }

        [Test]
        public void GetFlyoutAnchor_Should_Find_And_Return_Correct_FlyoutAnchor()
        {
            var sut = new MenuSection("MyMenuSection");
            var actual = new FlyoutAnchor("MyFlyoutAnchor");
            var fake = new FlyoutAnchor("MYFlyoutANchor");

            sut._flyoutAnchors.Add(actual);
            sut._flyoutAnchors.Add(fake);

            Assert.AreEqual(actual,sut.GetFlyoutAnchor("MyFlyoutAnchor"));
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            var sut = new MenuSection("MyMenuSection");
            sut.Set(MenuSectionProperty.Title, "My MenuSection");

            Assert.AreEqual("My MenuSection", sut.Get(MenuSectionProperty.Title));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            var sut = new MenuSection("MyMenuSection");
            sut.Set(new Dictionary<MenuSectionProperty, string>()
                                  {
                                      {MenuSectionProperty.DisplayMode, "Float"},
                                      {MenuSectionProperty.Title, "My MenuSection"}
                                  });
            Assert.AreEqual("Float", sut.Get(MenuSectionProperty.DisplayMode));
            Assert.AreEqual("My MenuSection", sut.Get(MenuSectionProperty.Title));
        }


    }
}
