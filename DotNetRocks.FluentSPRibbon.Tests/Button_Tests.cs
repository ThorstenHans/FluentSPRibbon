using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Button_Tests
    {
        [Test]
        public void Verify_That_Base_Constructor_Will_Be_Called()
        {
            var sut = Create<Button>.Instance("MyButton");
            Assert.AreEqual("MyButton",sut.Id);
        }

         
    }
}