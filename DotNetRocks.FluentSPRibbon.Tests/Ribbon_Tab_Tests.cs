using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Ribbon_Tab_Tests
    {

        [Test]
        public void Tab_Should_Store_Multiple_Groups()
        {
            // Act
            var tab = Create<Tab>.Instance("MyTab")
                .With(() => Create<Group>.Instance("Grp1")
                                .SetPropertyTo("Name", "Group 1"))
                .With(()=>Create<Group>.Instance("Grp2"));
            // Assert
            Assert.AreEqual(2,tab.ChildItemCount);
        }
    }
}