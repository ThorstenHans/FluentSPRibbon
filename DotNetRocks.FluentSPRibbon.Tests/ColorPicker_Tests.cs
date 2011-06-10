using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class ColorPicker_Tests
    {
        private ColorPicker _sut;

        [SetUp]
        public void Setup()
        {
            _sut = ColorPicker.Create("MyColorPicker");
        }

        [Test]
        public void Should_Be_Able_To_Store_Multiple_Colors()
        {
            var first = new Color("Red");
            var second = new Color("Blue");
            var third = new Color("Green");
            _sut.With(() => first).With(() => second).With(() => third);
            Assert.AreEqual(3,_sut._colors.Count);
        }

        [Test]
        public void Indexer_Should_Return_Correct_Color_Instance()
        {
            var first = new Color("Red");
            var second = new Color("Blue");
            var third = new Color("Green");
            _sut.With(() => first).With(() => second).With(() => third);
            var actual = _sut["Blue"];
            Assert.AreEqual(second,actual);
        }
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<ColorPicker>(_sut);
            Assert.AreEqual("MyColorPicker", _sut.Id);
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            Assert.IsTrue(_sut.IsIdProvider);
        }

        [Test]
        public void PassedParameter_Is_Stored_In_OriginalId()
        {
            Assert.AreEqual("MyColorPicker", _sut.OriginalId);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            _sut.Set(ColorPickerProperty.Sequence, "111");
            Assert.AreEqual("111", _sut.Get(ColorPickerProperty.Sequence));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            _sut.Set(new Dictionary<ColorPickerProperty, string>()
                                  {
                                      {ColorPickerProperty.CommandPreview, "111"},
                                      {ColorPickerProperty.Sequence, "100"}
                                  });
            Assert.AreEqual("111", _sut.Get(ColorPickerProperty.CommandPreview));
            Assert.AreEqual("100", _sut.Get(ColorPickerProperty.Sequence));
        }

        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode_For_Current_Instance()
        {
            var actual = ColorPickerDisplayMode.Menu;
            _sut.SetDisplayMode(actual);
            Assert.AreEqual(actual.ToString(), _sut.GetDisplayMode());
        }
    }
}