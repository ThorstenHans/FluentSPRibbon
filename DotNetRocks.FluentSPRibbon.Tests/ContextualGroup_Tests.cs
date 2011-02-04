using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class ContextualGroup_Tests
    {
        [Test]
        public void Create_Should_Be_Able_To_Create_A_New_Instance()
        {
            // Arrange
            var sut = Create<ContextualGroup>.Instance("MyContextualTab");
            // Assert
            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<ContextualGroup>(sut);
        }

        [Test]
        public void If_Default_Constructor_Is_Called_The_DefaultId_Should_Be_Passed()
        {
            // Arrange
            var sut = new ContextualGroup();
            // Assert
            Assert.AreEqual("NotSet", sut.Id);
        }


        [Test]
        public void Set_Should_Store_Property_On_Current_Instance()
        {
            // Arrange
            var sut = new ContextualGroup();
            // Act
            sut.Set(ContextualGroupProperty.Color, "DarkBlue");
            // Assert
            Assert.AreEqual("DarkBlue", sut.Get(ContextualGroupProperty.Color));
        }

        [Test]
        public void Get_Should_Return_String_Empty_If_Property_Doesnt_Exist()
        {
            // Arrange
            var sut = new ContextualGroup();
            // Act
            var actual = sut.Get(ContextualGroupProperty.Color);
            // Assert
            Assert.IsEmpty(actual);
        }

        [Test]
        public void Set_Should_Store_Multiple_Properties_On_Current_Instance()
        {
            // Arrange
            var sut = new ContextualGroup();
            var expectedColor = "DarkBlue";
            var expectedCommand = "myCommand();";
            // Act
            sut.Set(new Dictionary<ContextualGroupProperty, string>()
                        {
                            {ContextualGroupProperty.Color, expectedColor},
                            {ContextualGroupProperty.Command, expectedCommand}
                        });
            
        // Assert
            Assert.AreEqual(expectedColor,sut.Get(ContextualGroupProperty.Color));
            Assert.AreEqual(expectedCommand,sut.Get(ContextualGroupProperty.Command));
        }


        [Test]
        public void Set_Overwrite_Existing_Property_Value_On_Current_Instance()
        {
        // Arrange
        var sut = new ContextualGroup();
        // Act
        sut.Set(ContextualGroupProperty.Color, "DarkBlue");
        sut.Set(ContextualGroupProperty.Color, "DarkRed");
        // Assert
        Assert.AreEqual("DarkRed", sut.Get(ContextualGroupProperty.Color));
    }

        [Test]
        public void Ribbon_Should_Be_Able_To_Store_Multiple_Contextual_Groups()
        {
            // Arrange
            var ribbon = new Ribbon("MyRibbon");
            // Act
            for (int i = 0; i < 20; i++)
            {
                ribbon.With(() => Create<ContextualGroup>.Instance("ContextualGroup" + i.ToString()));
            }

            // Assert
            Assert.AreEqual(20,ribbon._contextualGroups.Count);
        }

        [Test]
        public void ContextualGroup_Should_Be_Able_To_Store_Multiple_Tabs()
        {
            // Arrange
            var sut = new ContextualGroup();
            // Act
            for (int i = 0; i < 20; i++)
            {
                sut.With(() => Create<Tab>.Instance("Tab" + i.ToString()));
            }
            Assert.AreEqual(20,sut._tabs.Count);
            for (int i = 0; i<20; i++)
            {
                Assert.AreEqual(sut,sut._tabs[i].Parent);
            }
            // Assert
        }

    }


}