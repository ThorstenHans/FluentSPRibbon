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

            var ribbon = Ribbon.Create("MyRibbon")
                .Set(RibbonProperty.ToolTipFooterText, "MyRibbon")
                .With(() => Tab.Create("Tab1").Set(TabProperty.Title, "MyTab"))
                .With(() => Tab.Create("Tab2").Set(TabProperty.Title, "My 2ndTab"));

            // Assert
            Assert.AreEqual(2,ribbon._tabs.Count);
            
        }

        [Test]
        public void Create_Ribbon_With_Tabs_And_Groups_Should_Be_Fluent()
        {

            // Act
            var ribbon = Ribbon.Create("MyRibbon")
                .With(() => Tab.Create("Tab1")
                                .With(() => Group.Create("Grp1").Set(GroupProperty.Title, "Group1"))
                                .With(() => Group.Create("Grp2").Set(GroupProperty.Title, "Group2")));
            Assert.AreEqual(1, ribbon._tabs.Count);
            // Assert
        }


        [Test]
        public void It_Should_Be_Possible_To_Create_Single_Button_And_Pass_It_Into_A_New_Ribbon()
        {
            var button = Button.Create("MyButton")
                .Set(ButtonProperty.LabelText, "Click me!")
                .Set(ButtonProperty.Sequence, "100")
                .Set(ButtonProperty.Description, "a new button");

            var ribbon = Ribbon.Create("CustomRibbon")
                .With(() => Tab.Create("1stTab")
                                .With(() => Group.Create("1stGroup")
                                                .Set(GroupProperty.Title, "Group 1")
                                                .With(() => button)));
            Assert.IsNotNull(button);
            Assert.IsNotNull(ribbon);
        

        }
        
    }
}