using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Group_Tests
    {
        [Test]
        public void ApplyControlsProperty_Should_Store_Property_On_Controls_PropertyCollection()
        {
            // Arrange
            var sut = new Group("MyGroup");

            // Act
            sut.ApplyControlsProperty("Name", "Controls");

            // Assert
            Assert.AreEqual(1, sut.ControlsPropertyCount);
        }


        [Test]
        public void ApplyControlsProperties_Should_Store_Multiple_Properties_On_Controls_PropertyCollection()
        {
            // Arrange
            var sut = new Group("MyGroup");

            // Act
            sut.ApplyControlsProperties(new Dictionary<string, string>{{"Name","My Controls"},{"Visible","True"}});

            // Assert
            Assert.AreEqual(2,sut.ControlsPropertyCount);
            Assert.AreEqual("My Controls",sut.GetControlsProperty("Name"));
            Assert.AreEqual("True",sut.GetControlsProperty("Visible"));
        }

        [Test]
        public void ApplyControlsProperties_Should_Override_Existing_Properties_On_Controls_PropertyCollection()
        {   // Arrange
            var sut = new Group("MyGroup");

            // Act
            sut.ApplyControlsProperties(new Dictionary<string, string> { { "Name", "My Controls" }, { "Visible", "True" } });
            sut.ApplyControlsProperties(new Dictionary<string, string> { { "Name", "My new Controls" }});
            //Assert
            Assert.AreEqual(2, sut.ControlsPropertyCount);
            Assert.AreEqual("My new Controls", sut.GetControlsProperty("Name"));
        }

        [Test]
        public void GetControlsProperty_Should_Return_Controls_PropertyValue()
        {
            // Arrange
            var sut = new Group("MyGroup");
            sut.ApplyControlsProperty("Name", "Controls");

            // Assert
            Assert.AreEqual("Controls", sut.GetControlsProperty("Name"));
        }
    }
}