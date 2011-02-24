using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class ControlRef_Tests
    {
        private ControlRef _sut;

        [SetUp]
        public void Setup()
        {
            _sut = ControlRef.Create("MyControlRef");
        }

        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<ControlRef>(_sut);
        }

        [Test]
        public void PassedParameter_Is_Applied_To_OriginalId_When_Constructor_Is_Called()
        {
            Assert.AreEqual("MyControlRef", _sut.Id);
        }

        [Test]
        public void Set_Should_Add_Property_To_Current_Instance()
        {
            _sut.Set(ControlRefProperty.TemplateAlias, "TA");
            Assert.AreEqual("TA", _sut.GetProperty(ControlRefProperty.TemplateAlias));
        }

        [Test]
        public void Set_Should_Set_Multiple_Properties_To_Current_Instance()
        {
            _sut.Set(new Dictionary<ControlRefProperty, string>() { { ControlRefProperty.TemplateAlias, "TemplateAlias" } });
            Assert.AreEqual("TemplateAlias", _sut.GetProperty(ControlRefProperty.TemplateAlias));
        }

        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode()
        {
            _sut.SetDisplayMode(ControlRefDisplayMode.Menu32);
            Assert.AreEqual(ControlRefDisplayMode.Menu32,_sut.GetDisplayMode());
        }

        [Test]
        public void SetDisplayMode_Should_Update_Existing_DisplayMode()
        {
            _sut.SetDisplayMode(ControlRefDisplayMode.Large);
            _sut.SetDisplayMode(ControlRefDisplayMode.Menu32);
            Assert.AreEqual(ControlRefDisplayMode.Menu32, _sut.GetDisplayMode());
        }
    }
}