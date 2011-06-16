using System;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{

    [TestFixture]
    public class CommandUIHandler_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance_Of_CommandUIHandler()
        {
            var sut = CommandUIHandler.Create();

            Assert.That(sut, Is.Not.Null);
            Assert.That(sut,Is.InstanceOf<CommandUIHandler>());
        }

        [Test]
        public void CommandUIHandler_IsIdProvider_Should_Be_False()
        {
            var sut = CommandUIHandler.Create();

            Assert.That(sut.IsIdProvider,Is.False);
        }
    }
}