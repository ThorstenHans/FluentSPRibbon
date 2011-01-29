using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Button_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            var sut = Create<Button>.Instance("MyButton");
            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<Button>(sut);
            Assert.AreEqual("MyButton",sut.Id);
        }

         
    }
}