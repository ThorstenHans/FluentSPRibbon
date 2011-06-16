using System;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{

    [TestFixture]
    public class CommandUIDefinition_Tests
    {

        [Test]
        public void Create_Should_Create_A_New_Instance_Of_CommandUIDefition()
        {
            var sut = CommandUIDefinition.Create();

            Assert.That(sut, Is.Not.Null);
            Assert.That(sut, Is.InstanceOf<CommandUIDefinition>());
        }

        [Test]
        public void IsIdProvider_Should_Be_False()
        {
            var sut = CommandUIDefinition.Create();

            Assert.That(sut.IsIdProvider, Is.False);
        }


    }
}