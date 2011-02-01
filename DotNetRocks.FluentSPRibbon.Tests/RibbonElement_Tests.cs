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

        [Test]
        public void Property_Should_Be_Updated_If_It_Is_Allready_Existing()
        {
            // Arrange
            var sut = new Button();
            var actual = "NewTitle";
            sut.Set(ButtonProperty.LabelText, "Title");
            // Act
            sut.Set(ButtonProperty.LabelText,actual);
            // Assert
            Assert.AreEqual(actual, sut.Get(ButtonProperty.LabelText));
        }

        [Test]
        public void GetSchema_Should_Return_Null()
        {
            // Arrange
            var sut = new Button();
            // Assert
            Assert.IsNull(sut.GetSchema());
        }

        [Test]
        public void Get_Should_Return_String_Empty_If_Property_Is_Not_Present()
        {
            // Arrange
            var sut = new Button();
            // Act
            var actual = sut.Get(ButtonProperty.Sequence);
            // Assert
            Assert.IsEmpty(actual);
        }
    }
}
