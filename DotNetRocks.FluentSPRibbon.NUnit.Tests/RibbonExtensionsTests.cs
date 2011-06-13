using System;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.NUnit.Tests
{
    [TestFixture]
    public class RibbonExtensionsTests
    {
        [Test]
        public void RibbonExtensions_Should_Be_An_Attribute()
        {
            var sut = new RibbonExtensions();
            Assert.That(sut, Is.InstanceOf<System.Attribute>());
        }

        [Test]
        [Category("TestCategory")]
        public void RibbonExtensions_Should_Inherit_From_NUnit_TestFixture()
        {
            var sut = new RibbonExtensions();
            Assert.That(sut, Is.InstanceOf<TestFixtureAttribute>());
        }

        [Test]
        public void RibbonExtensions_Should_Only_Be_Valid_On_Classes()
        {
            var attributes = typeof(RibbonExtensions).GetCustomAttributes(typeof(AttributeUsageAttribute), false);

            Assert.That(attributes, Is.Not.Null);
            Assert.That(attributes.Length, Is.GreaterThan(0));
            Assert.That(attributes[0], Is.InstanceOf<System.AttributeUsageAttribute>());
            var usageAttrib = attributes[0] as AttributeUsageAttribute;
            Assert.That(usageAttrib, Is.Not.Null);
            Assert.That(usageAttrib.ValidOn, Is.EqualTo(AttributeTargets.Class));
        }
    }
}