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


    }
}
