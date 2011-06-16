using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{

    [TestFixture]
    public class Groups_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance_Of_Groups()
        {
            var sut = Groups.Create("Id");

            Assert.That(sut, Is.Not.Null);
            Assert.That(sut, Is.InstanceOf<Groups>());
        }

        [Test]
        public void Create_Should_Persist_Id()
        {
            var sut = Groups.Create("Id");

            Assert.That(sut.Id, Is.EqualTo("Id"));
        }

        [Test]
        public void IsIdProvider_Should_BeTrue()
        {
            var sut = Groups.Create("Id");

            Assert.That(sut.IsIdProvider, Is.True);
        }
    }
}