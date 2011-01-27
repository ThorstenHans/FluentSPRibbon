using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Continous_Fluent_API_Tests
    {

        [Test]
        public void Create_Ribbon_With_Tab_Should_Be_Fluent()
        {
            // Act

            var ribbon = Create<Ribbon>.Instance("MyRibbon")
                .ApplyProperty("Name", "MyRibbon")
                .With(() => Create<Tab>.Instance("Tab1").ApplyProperty("Name", "MyTab"))
                .With(() => Create<Tab>.Instance("Tab2").ApplyProperty("Name", "My 2ndTab"));

            // Assert
            Assert.AreEqual(2,ribbon.ChildItemCount);
            
        }

        [Test]
        public void Create_Ribbon_With_Tabs_And_Groups_Should_Be_Fluent()
        {

            // Act
            var ribbon = Create<Ribbon>.Instance("MyRibbon")
                .With(() => Create<Tab>.Instance("Tab1")
                                .With(() => Create<Group>.Instance("Grp1").ApplyProperty("Name", "Group1"))
                                .With(() => Create<Group>.Instance("Grp2").ApplyProperty("Name", "Group2")));
            Assert.AreEqual(1, ribbon.ChildItemCount);
            // Assert
        }


        [Test]
        public void It_Should_Be_Possible_To_Create_Single_Button_And_Pass_It_Into_A_New_Ribbon()
        {
            var button = Create<Button>
                .Instance("MyButton")
                .ApplyProperty("LabelText", "Click me!")
                .ApplyProperty("Sequence", "100")
                .ApplyProperty("Description", "a new button");

            var ribbon = Create<Ribbon>.Instance("CustomRibbon")
                .With(() => Create<Tab>.Instance("1stTab")
                                .With(() => Create<Group>.Instance("1stGroup")
                                                .ApplyProperty("Name", "Group 1")
                                                .With(() => button)));
            Assert.IsNotNull(button);
            Assert.IsNotNull(ribbon);
            Assert.IsNotNull(ribbon["1stTab"]["1stGroup"]["MyButton"]);
            Assert.IsInstanceOf(typeof(Button), ribbon["1stTab"]["1stGroup"]["MyButton"]);

        }
        
    }
}