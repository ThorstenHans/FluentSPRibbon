using System;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{

    [TestFixture]
    public class ContextualTabs_Tests
    {
        [Test]
        
        public void Create_Should_Create_A_New_Instance_Of_ContextualTabs()
        {
            var sut = ContextualTabs.Create("myId");

            Assert.That(sut, Is.Not.Null);
            Assert.That(sut, Is.InstanceOf<ContextualTabs>());
        }

        [Test]
        public void Create_Should_Persist_Id()
        {
            var sut = ContextualTabs.Create("myContextualTabs");

            Assert.That(sut.Id, Is.EqualTo("myContextualTabs"));
        }

        [Test]
        public void IsIdProvider_Should_BeTrue()
        {
            var sut = ContextualTabs.Create("myContextualTabs");

            Assert.That(sut.IsIdProvider, Is.True);
        }
    }
}