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
                .ApplyProperty(RibbonProperty.ToolTipFooterText, "MyRibbon")
                .With(() => Create<Tab>.Instance("Tab1").ApplyProperty(TabProperty.Title, "MyTab"))
                .With(() => Create<Tab>.Instance("Tab2").ApplyProperty(TabProperty.Title, "My 2ndTab"));

            // Assert
            Assert.AreEqual(2,ribbon.ChildItemCount);
            
        }

        [Test]
        public void Create_Ribbon_With_Tabs_And_Groups_Should_Be_Fluent()
        {

            // Act
            var ribbon = Create<Ribbon>.Instance("MyRibbon")
                .With(() => Create<Tab>.Instance("Tab1")
                                .With(() => Create<Group>.Instance("Grp1").ApplyProperty(GroupProperty.Title, "Group1"))
                                .With(() => Create<Group>.Instance("Grp2").ApplyProperty(GroupProperty.Title, "Group2")));
            Assert.AreEqual(1, ribbon.ChildItemCount);
            // Assert
        }


        [Test]
        public void It_Should_Be_Possible_To_Create_Single_Button_And_Pass_It_Into_A_New_Ribbon()
        {
            var button = Create<Button>
                .Instance("MyButton")
                .ApplyProperty(ButtonProperty.LabelText, "Click me!")
                .ApplyProperty(ButtonProperty.Sequence, "100")
                .ApplyProperty(ButtonProperty.Description, "a new button");

            var ribbon = Create<Ribbon>.Instance("CustomRibbon")
                .With(() => Create<Tab>.Instance("1stTab")
                                .With(() => Create<Group>.Instance("1stGroup")
                                                .ApplyProperty(GroupProperty.Title, "Group 1")
                                                .With(() => button)));
            Assert.IsNotNull(button);
            Assert.IsNotNull(ribbon);
            Assert.IsNotNull(ribbon["1stTab"]["1stGroup"]["MyButton"]);
            Assert.IsInstanceOf(typeof(Button), ribbon["1stTab"]["1stGroup"]["MyButton"]);

        }
        
    }
}