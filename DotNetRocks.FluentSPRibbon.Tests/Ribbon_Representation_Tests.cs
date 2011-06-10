using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    class Ribbon_Representation_Tests
    {
        [Test]
        public void SharePoint_Ribbon_Should_Have_A_Managed_Wrapper()
        {
            var sut = Ribbon.Create("MyRibbon")
               
                .With(()=>Tab.Create("MyTab"));
 
            Assert.AreEqual(1, sut._tabs.Count);
 
        }
    }
}
