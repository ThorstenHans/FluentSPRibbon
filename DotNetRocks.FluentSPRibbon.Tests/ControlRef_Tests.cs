using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class ControlRef_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            // Arrange
            var sut = Create<ControlRef>.Instance("MyControlRef");
            // Assert
            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<ControlRef>(sut);
        }


        [Test]
        public void If_Default_Constructor_Is_Called_DefaultValue_Should_Be_Stored_In_OriginalId()
        {
            // Arrange
            var sut = new ControlRef();
            // Assert
            Assert.AreEqual("NotSet", sut.Id);
        }

        [Test]
        public void PassedParameter_Is_Applied_To_OriginalId_When_Constructor_Is_Called()
        {
            // Arrange
            var sut = new ControlRef("MyControlRef");
            // Assert
            Assert.AreEqual("MyControlRef", sut.Id);
        }

        [Test]
        public void Set_Should_Add_Property_To_Current_Instance()
        {
            var sut = new ControlRef("MyControlRef");
            sut.Set(ControlRefProperty.TemplateAlias, "TA");

            Assert.AreEqual("TA", sut.GetProperty(ControlRefProperty.TemplateAlias));
        }

        [Test]
        public void Set_Should_Set_Multiple_Properties_To_Current_Instance()
        {
            var sut = new ControlRef("MyControlRef");
            sut.Set(new Dictionary<ControlRefProperty, string>() { { ControlRefProperty.TemplateAlias, "TemplateAlias" } });

            Assert.AreEqual("TemplateAlias", sut.GetProperty(ControlRefProperty.TemplateAlias));
        }

        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode()
        {
            // Arrange
            var sut = new ControlRef("MyControlRef");
            // Act
            sut.SetDisplayMode(ControlRefDisplayMode.Menu32);
            // Assert
            Assert.AreEqual(ControlRefDisplayMode.Menu32,sut.GetDisplayMode());
        }

        [Test]
        public void SetDisplayMode_Should_Update_Existing_DisplayMode()
        {
            // Arrange
            var sut = new ControlRef("MyControlRef");
            // Act
            sut.SetDisplayMode(ControlRefDisplayMode.Large);
            sut.SetDisplayMode(ControlRefDisplayMode.Menu32);
            // Assert
            Assert.AreEqual(ControlRefDisplayMode.Menu32, sut.GetDisplayMode());
        }
    }
}