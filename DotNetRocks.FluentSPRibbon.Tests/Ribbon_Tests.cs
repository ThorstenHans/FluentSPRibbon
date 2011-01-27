using System;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Ribbon_Tests
    {
        [Test]
        public void A_New_Ribbon_Should_Always_Be_Empty()
        {
            var newRibbon = Create<Ribbon>.Instance("MyRibbon");

            Assert.AreEqual(0, newRibbon.ChildItemCount);
        }


        
    }
}