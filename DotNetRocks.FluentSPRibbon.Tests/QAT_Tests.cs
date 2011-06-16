using System;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{

    [TestFixture]
    public class QAT_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance_Of_QAT()
        {
            var sut = QAT.Create("Id");

            Assert.That(sut, Is.Not.Null);
            Assert.That(sut, Is.InstanceOf<QAT>());
        }

        [Test]
        public void Create_Should_Persist_Id()
        {
            var sut = QAT.Create("Id");

            Assert.That(sut.Id, Is.EqualTo("Id"));
        }

        [Test]
        public void IsIdProvider_Should_BeTrue()
        {
            var sut = QAT.Create("Id");

            Assert.That(sut.IsIdProvider, Is.True);
        }



    }
}