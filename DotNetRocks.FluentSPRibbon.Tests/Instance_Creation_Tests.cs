using System.Linq;
using System.Text;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Instance_Creation_Tests
    {
        [Test]
        public void Should_Create_An_Instance_Of_A_RibbonElement_With_Id_As_Parameter()
        {
            
            // Act
            var actual = Button.Create("MyRibbon");
            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf<Button>(actual);
            
        }

        [Test]
        public void Should_Provide_A_Fluent_Way_To_Set_Properties_On_RibbonElements()
        {
            // Act
            var actual = Button.Create("MyRibbon")
                .Set(ButtonProperty.Description,"Value")
                .Set(ButtonProperty.LabelText,"Caption");

            // Assert
            Assert.AreEqual("Value", actual.Get(ButtonProperty.Description));
            Assert.AreEqual("Caption",actual.Get(ButtonProperty.LabelText));
        }

      

    }
}
