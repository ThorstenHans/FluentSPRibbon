using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Group_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            var sut = Create<Group>.Instance("MyGroup");

            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<Group>(sut);
            Assert.AreEqual("MyGroup",sut.Id);
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            var sut = new Group("MyGroup");
            Assert.IsTrue(sut.IsIdProvider);
        }

        [Test]
        public void PassedParameter_Is_Stored_In_OriginalId()
        {
            var sut = new Group("MyGroup");
            Assert.AreEqual("MyGroup",sut.OriginalId);
        }

        [Test]
        public void Id_Should_Return_Passed_Parameter_If_No_Parent_Is_Present()
        {
            var sut = new Group("MyGroup1");
            Assert.AreEqual("MyGroup1",sut.Id);
        }

        [Test]
        public void Id_Should_Be_Composed_If_Parent_Is_Present()
        {
            var sut = new Group("Group1");
            var tab = new Tab("Tab2").With(() => sut);
            var ribbon = new Ribbon("Ribbon3")
                .With(()=>tab);
            
            Assert.AreEqual("Ribbon3.Tab2.Group1",sut.Id);
        }
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