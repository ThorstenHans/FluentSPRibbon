using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class RibbonElement_Tests
    {
        [Test]
        public void SetProperties_Should_Store_Multiple_Properties_On_Current_Instance()
        {
            // Arrange
            var sut = new RibbonElement();

            // Act
            sut.SetProperties(new Dictionary<String,String>{{"Name","Testbutton"},{"DisplayText","My Test Button"}});

            // Assert
            Assert.AreEqual("Testbutton", sut.GetProperty("Name"));
            Assert.AreEqual("My Test Button", sut.GetProperty("DisplayText"));
        }

        [Test]
        public void XmlElementName_Should_Return_Correct_XmlElementName()
        {
            // Arrange
            var sut = Create<Button>.Instance("MyButton");
            var sutLabel = Create<Label>.Instance("MyLabel");
            var sutCheckBox = Create<CheckBox>.Instance("MyCheckBox");
            var sutComboBox = Create<ComboBox>.Instance("MyComboBox");

            // Act
            var actualButton = sut.XmlElementName;
            var actualLabel = sutLabel.XmlElementName;
            var actualCheckBox = sutCheckBox.XmlElementName;
            var actualComboBox = sutComboBox.XmlElementName;
            // Assert

            Assert.AreEqual("Button", actualButton);
            Assert.AreEqual("Label", actualLabel);
            Assert.AreEqual("CheckBox",actualCheckBox);
            Assert.AreEqual("ComboBox",actualComboBox);
        }
    }
}
