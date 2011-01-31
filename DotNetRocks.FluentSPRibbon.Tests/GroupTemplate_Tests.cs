using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class GroupTemplate_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            // Arrange
            var sut = Create<GroupTemplate>.Instance("MyGroupTemplate");
            // Assert
            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<GroupTemplate>(sut);
            Assert.AreEqual("MyGroupTemplate",sut.Id);
        }
    }
}