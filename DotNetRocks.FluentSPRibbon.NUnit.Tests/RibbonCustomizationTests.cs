using System;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.NUnit.Tests
{
    [TestFixture]
    public class RibbonCustomizationTests
    {
        [Test]
        public void RibbonCustomization_Should_Be_An_Attribute()
        {
            var sut = new RibbonCustomization();

            Assert.That(sut, Is.InstanceOf<System.Attribute>());
        }

        [Test]
        public void RibbonCustomization_Should_Inherit_From_NUnit_TestAttribute()
        {
            var sut = new RibbonCustomization();
            Assert.That(sut, Is.InstanceOf<TestAttribute>());
        }

        [Test]
        public void RibbonCustomizations_Should_Only_Be_Valid_On_Methods()
        {
            var attributes = typeof(RibbonCustomization).GetCustomAttributes(typeof(AttributeUsageAttribute), false);

            Assert.That(attributes, Is.Not.Null);
            Assert.That(attributes.Length, Is.GreaterThan(0));
            Assert.That(attributes[0], Is.InstanceOf<System.AttributeUsageAttribute>());
            var usageAttrib = attributes[0] as AttributeUsageAttribute;
            Assert.That(usageAttrib, Is.Not.Null);
            Assert.That(usageAttrib.ValidOn, Is.EqualTo(AttributeTargets.Method));
        }
    }
}