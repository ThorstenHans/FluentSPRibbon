using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class RibbonElement_Tests
    {

        [Test]
        public void XmlElementName_Should_Return_Correct_XmlElementName()
        {
            var sut = Button.Create("MyButton");
            var sutLabel = Label.Create("MyLabel");
            var sutCheckBox = CheckBox.Create("MyCheckBox");
            var sutComboBox = ComboBox.Create("MyComboBox");

            var actualButton = sut.XmlElementName;
            var actualLabel = sutLabel.XmlElementName;
            var actualCheckBox = sutCheckBox.XmlElementName;
            var actualComboBox = sutComboBox.XmlElementName;

            Assert.AreEqual("Button", actualButton);
            Assert.AreEqual("Label", actualLabel);
            Assert.AreEqual("CheckBox",actualCheckBox);
            Assert.AreEqual("ComboBox",actualComboBox);
        }

        [Test]
        public void Property_Should_Be_Updated_If_It_Is_Allready_Existing()
        {
            var sut = new Button();
            var actual = "NewTitle";
            sut.Set(ButtonProperty.LabelText, "Title");
            sut.Set(ButtonProperty.LabelText,actual);
            Assert.AreEqual(actual, sut.Get(ButtonProperty.LabelText));
        }

        [Test]
        public void GetSchema_Should_Return_Null()
        {
            var sut = new Button();
            Assert.IsNull(sut.GetSchema());
        }

        [Test]
        public void Get_Should_Return_String_Empty_If_Property_Is_Not_Present()
        {
            var sut = new Button();
            var actual = sut.Get(ButtonProperty.Sequence);
            Assert.IsEmpty(actual);
        }
    }
}
