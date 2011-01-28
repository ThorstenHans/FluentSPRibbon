using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Id_Tests
    {
        [Test]
        public void Ribbon_Id_Should_Not_Be_Delimited_Automaticaly()
        {
            // Arrange
            var expected = "MyRibbonID";
            // Act
            var ribbon = Create<Ribbon>.Instance(expected);

            // Assert
            Assert.AreEqual(expected,ribbon.Id);
        }

        [Test]
        public void Original_Id_Should_Always_Return_Id_Which_Was_Specified_By_the_User()
        {
            // Arrange
            var expected = "MyTab1";

            // Act
            var ribbon = Create<Ribbon>.Instance("Ribbon1")
                .With(() => Create<Tab>.Instance("MyTab1"));

            // Assert
            Assert.IsNotNull(ribbon);
            Assert.AreEqual(expected, ribbon["MyTab1"].OriginalId);
        }

        [Test]
        public void Tab_Id_Should_Be_Concated_By_Ribbon_And_Tab_Id()
        {
            // Arrange
            var expected = "MyRibbon.MyTab1";
            var sut = Create<Ribbon>.Instance("MyRibbon")
                .With(() => Create<Tab>.Instance("MyTab1"));

            // Assert
            Assert.AreEqual(expected, sut["MyTab1"].Id);
        }

        [Test]
        public void Group_Id_Should_Be_Concated_By_Ribbon_Tab_And_Group_Id()
        {
            // Arrange
            var ribbon = Create<Ribbon>.Instance("MyRibbon")
                .With(() => Create<Tab>.Instance("Tab1")
                                .With(() => Create<Group>.Instance("Grp1").SetProperty(GroupProperty.Title, "Group1"))
                                .With(() => Create<Group>.Instance("Grp2").SetProperty(GroupProperty.Title, "Group2")));

            // Act

            // Assert
            Assert.AreEqual("MyRibbon.Tab1.Grp2",ribbon["Tab1"][1].Id);
            Assert.AreEqual("MyRibbon.Tab1.Grp1", ribbon["Tab1"][0].Id);
        }
    }
}