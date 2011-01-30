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
            Assert.AreEqual("Controls", sut.GetControlsProperty("Name"));
        }

        [Test]
        public void With_Should_Add_InterActiveRibbonElement_And_Set_Parent()
        {
            var sut = new Group("MyGroup");
            var actual = new Button("MyButton");
            sut.With(() => actual);

            Assert.AreEqual(sut,actual.Parent);
            Assert.AreEqual(1,sut._interactiveRibbonElements.Count);
            
        }

        [Test]
        public void Indexer_Should_Return_Correct_InterActiveRibbonElement()
        {
            var sut = new Group("MyGroup");
            var button1 = new Button("Button1");
            var textBox1 = new TextBox("Textbox1");
            var comboBox1 = new ComboBox("Combobox1");

            sut.With(() => button1)
                .With(() => textBox1)
                .With(() => comboBox1);

            Assert.AreEqual(button1,sut["Button1"]);
            Assert.IsNull(sut["MyGroup.Button1"]);
            Assert.AreEqual(textBox1, sut["Textbox1"]);
            Assert.AreEqual(comboBox1, sut["Combobox1"]);
        }

        [Test]
        public void ApplyControlsProperties_Should_Store_Multiple_Properties_On_Controls_PropertyCollection()
        {
            // Arrange
            var sut = new Group("MyGroup");

            // Act
            sut.ApplyControlsProperties(new Dictionary<string, string>{{"Name","My Controls"},{"Visible","True"}});

            // Assert
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