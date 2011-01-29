using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class RibbonElement_Tests
    {
       
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
