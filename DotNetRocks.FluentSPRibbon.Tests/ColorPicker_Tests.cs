using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class ColorPicker_Tests
    {
        [Test]
        public void Should_Be_Able_To_Store_Multiple_Colors()
        {
            // Arrange
            var sut = new ColorPicker("MyColorPicker");
            var first = new Color("Red");
            var second = new Color("Blue");
            var third = new Color("Green");
            // Act
            sut.With(() => first).With(() => second).With(() => third);

            // Assert
            Assert.AreEqual(3,sut._colors.Count);
        }

        [Test]
        public void Indexer_Should_Return_Correct_Color_Instance()
        {
            // Arrange
            var sut = new ColorPicker("MyColorPicker");
            var first = new Color("Red");
            var second = new Color("Blue");
            var third = new Color("Green");
            sut.With(() => first).With(() => second).With(() => third);
            // Act
            var actual = sut["Blue"];
            // Assert
            Assert.AreEqual(second,actual);
        }
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            var sut = Create<ColorPicker>.Instance("MyColorPicker");

            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<ColorPicker>(sut);
            Assert.AreEqual("MyColorPicker", sut.Id);
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            var sut = new ColorPicker("MyColorPicker");
            Assert.IsTrue(sut.IsIdProvider);
        }

        [Test]
        public void ParameterLess_Constructor_Should_Store_DefaultValue_In_OriginalId_Property()
        {
            // Arrange
            var sut = new ColorPicker();
            // Assert
            Assert.AreEqual("NotSet",sut.OriginalId);
        }
        [Test]
        public void PassedParameter_Is_Stored_In_OriginalId()
        {
            var sut = new ColorPicker("MyColorPicker");
            Assert.AreEqual("MyColorPicker", sut.OriginalId);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            var sut = new ColorPicker("MyColorPicker");
            sut.Set(ColorPickerProperty.Sequence, "111");

            Assert.AreEqual("111", sut.Get(ColorPickerProperty.Sequence));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            var sut = new ColorPicker("MyColorPicker");
            sut.Set(new Dictionary<ColorPickerProperty, string>()
                                  {
                                      {ColorPickerProperty.CommandPreview, "111"},
                                      {ColorPickerProperty.Sequence, "100"}
                                  });
            Assert.AreEqual("111", sut.Get(ColorPickerProperty.CommandPreview));
            Assert.AreEqual("100", sut.Get(ColorPickerProperty.Sequence));
        }
    }
}