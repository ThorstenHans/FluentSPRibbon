using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class RibbonElement_Tests
    {
        [Test]
        public void Default_Constructor_Should_Store_Default_Value_In_OriginalId()
        {
            // Arrange
            var sut = new RibbonElement();
            // Assert
            Assert.AreEqual("NotSet",sut.OriginalId);
        }

        [Test]
        public void GetSchema_Should_Return_Null()
        {
            // Arrange
            var sut = new RibbonElement();
            // Assert
            Assert.IsNull(sut.GetSchema());
        }

        [Test]
        public void AddOrUpdateProperty_Should_Update_ExistingProperty()
        {
            // Arrange
            var sut = new RibbonElement("MyRibbonElement");
            // Act
            sut.AddOrUpdateProperty(RibbonProperty.ToolTipHelpCommand,"MyHelpCommand();");
            sut.AddOrUpdateProperty(RibbonProperty.ToolTipHelpCommand, "showHelpCommand();");

            // Assert
            Assert.AreEqual("showHelpCommand();",sut.GetPropertyValue(RibbonProperty.ToolTipHelpCommand));
        }

        [Test]
        public void GetPropertyValue_Should_Return_String_Empty_If_Property_Is_Not_Present()
        {
            // Arrange
            var sut = new RibbonElement("MyRibbonElement");
            // Act
            var actual = sut.GetPropertyValue(RibbonProperty.ToolTipFooterText);
            // Assert
            Assert.IsEmpty(actual);
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
