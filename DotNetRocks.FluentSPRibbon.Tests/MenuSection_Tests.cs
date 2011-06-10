using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class MenuSection_Tests
    {
        private MenuSection _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new MenuSection("MyMenuSection");
        }

        [Test]
        public void It_Should_Be_Possible_To_Add_Multiple_Buttons()
        {
            var first = new Button("MyButton");
            var second = new Button("SecondButton");
            var third = new Button("ThirdButton");
            _sut.With(() => first).With(() => second).With(() => third);
            Assert.AreEqual(3,_sut._buttons.Count);
        }

        [Test]
        public void It_Should_Be_Possible_To_Add_Multiple_ToggleButtons()
        {
            var first = new ToggleButton("MyToggleButton1");
            var second = new ToggleButton("MyToggleButton2");
            var third = new ToggleButton("MyToggleButton3");
            _sut.With(() => first).With(() => second).With(() => third);
            Assert.AreEqual(3, _sut._toggleButtons.Count);
        }

        [Test]
        public void It_Should_Be_Possible_To_Add_Multiple_ColorPickers()
        {
            var first = new ColorPicker("MyColorPicker1");
            var second = new ColorPicker("MyColorPicker2");
            var third = new ColorPicker("MyColorPicker3");
            _sut.With(() => first).With(() => second).With(() => third);
            Assert.AreEqual(3, _sut._colorPickers.Count);
        }

        [Test]
        public void It_Should_Be_Possible_To_Add_Multiple_FlyoutAnchors()
        {
            var first = new FlyoutAnchor("MyFlyoutAnchor");
            var second = new FlyoutAnchor("SecondFlyoutAnchor");
            var third = new FlyoutAnchor("ThirdFlyoutAnchor");
            _sut.With(() => first).With(() => second).With(() => third);
            Assert.AreEqual(3, _sut._flyoutAnchors.Count);
        }

        [Test]
        public void It_Should_Be_Possible_To_Store_An_InsertTable()
        {
            var first = new InsertTable("MyInsertTable");
            _sut.With(() => first);
            Assert.AreEqual(first,_sut._insertTable);
        }

        [Test]
        public void It_Should_OverWrite_An_Existing_InsertTable_Instance()
        {
            var first = new InsertTable("MyInsertTable");
            var second = new InsertTable("MySecondInsertTable");
            _sut.With(() => first).With(()=>second);
            Assert.AreEqual(second, _sut._insertTable);
        }

        [Test]
        public void GetButton_Should_Find_And_Return_Correct_Button()
        {
            var actual = new Button("MyButton");
            var fake = new Button("MyBUtton");
            _sut._buttons.Add(actual);
            _sut._buttons.Add(fake);
            Assert.AreEqual(actual,_sut.GetButton("MyButton"));
        }

        [Test]
        public void GetToggleButton_Should_Find_And_Return_Correct_ToggleButton()
        {
            var actual = new ToggleButton("MyToggleButton");
            var fake = new ToggleButton("MyToggleBUtton");
            _sut._toggleButtons.Add(fake);
            _sut._toggleButtons.Add(actual);
            Assert.AreEqual(actual, _sut.GetToggleButton("MyToggleButton"));
        }

        [Test]
        public void GetColorPicker_Should_Find_And_Return_Correct_ColorPicker()
        {
            var actual = new ColorPicker("MyColorPicker");
            var fake = new ColorPicker("MyMenuSection.MyColorPicker");
            _sut._colorPickers.Add(actual);
            _sut._colorPickers.Add(fake);
            Assert.AreEqual(actual,_sut.GetColorPicker("MyColorPicker"));
        }

        [Test]
        public void GetFlyoutAnchor_Should_Find_And_Return_Correct_FlyoutAnchor()
        {
            var actual = new FlyoutAnchor("MyFlyoutAnchor");
            var fake = new FlyoutAnchor("MYFlyoutANchor");
            _sut._flyoutAnchors.Add(actual);
            _sut._flyoutAnchors.Add(fake);
            Assert.AreEqual(actual,_sut.GetFlyoutAnchor("MyFlyoutAnchor"));
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            _sut.Set(MenuSectionProperty.Title, "My MenuSection");
            Assert.AreEqual("My MenuSection", _sut.Get(MenuSectionProperty.Title));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            _sut.Set(new Dictionary<MenuSectionProperty, string>()
                                  {
                                      {MenuSectionProperty.DisplayMode, "Float"},
                                      {MenuSectionProperty.Title, "My MenuSection"}
                                  });
            Assert.AreEqual("Float", _sut.Get(MenuSectionProperty.DisplayMode));
            Assert.AreEqual("My MenuSection", _sut.Get(MenuSectionProperty.Title));
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            Assert.IsTrue(_sut.IsIdProvider);
        }

        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode_For_Current_Instance()
        {
            var actual = MenuSectionDisplayMode.Menu16;
            _sut.SetDisplayMode(actual);
            Assert.AreEqual(actual.ToString(), _sut.GetDisplayMode());
        }
    }
}
