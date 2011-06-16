using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{

    [TestFixture]
    public class Tabs_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance_Of_Tabs()
        {
            var sut = Tabs.Create("Id");

            Assert.That(sut, Is.Not.Null);
            Assert.That(sut, Is.InstanceOf<Tabs>());
        }

        [Test]
        public void Create_Should_Persist_Id()
        {
            var sut = Tabs.Create("Id");

            Assert.That(sut.Id, Is.EqualTo("Id"));
        }

        [Test]
        public void IsIdProvider_Should_BeTrue()
        {
            var sut = Tabs.Create("Id");

            Assert.That(sut.IsIdProvider, Is.True);
        }
    }
}