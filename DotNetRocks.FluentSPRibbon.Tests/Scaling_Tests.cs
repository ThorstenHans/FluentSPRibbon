using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Scaling_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Scaling_Instance()
        {
            var sut = Create<Scaling>.Instance("MyScaling");

            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<Scaling>(sut);
            Assert.AreEqual("MyScaling",sut.Id);
        }

        [Test]
        public void GetMaxSize_Should_Find_And_Return_The_Correxct_MaxSize()
        {
            var sut = new Scaling("MyScaling");
            var fake = new MaxSize("MyMaxSize1");
            var actual = new MaxSize("MyMaxSize");
            sut._maxSizes.Add(fake);
            sut._maxSizes.Add(actual);
            Assert.AreEqual(actual,sut.GetMaxSize("MyMaxSize"));
        }

        [Test]
        public void GetScale_Should_Find_And_Return_The_Correct_Scale()
        {
            var sut = new Scaling("MyScaling");
            var fake = new Scale("MyScale1");
            var actual = new Scale("MyScale");

            sut._scales.Add(fake);
            sut._scales.Add(actual);

            Assert.AreEqual(actual,sut.GetScale("MyScale"));
        }

        [Test]
        public void WithScale_Should_Add_Scale_And_Set_Parent()
        {
            var sut = new Scaling("MyScaling");
            var actual = new Scale("MyScale");

            sut.With(() => actual);

            Assert.AreEqual(1, sut._scales.Count);
            Assert.AreEqual(actual, sut.GetScale("MyScale"));
            Assert.AreEqual(sut, actual.Parent);
        }

        [Test]
        public void WithMaxSize_Should_Add_MaxSize_And_Set_Parent()
        {
            var sut = new Scaling("MyScaling");
            var actual = new MaxSize("MyMaxSize");

            sut.With(() => actual);

            Assert.AreEqual(1, sut._maxSizes.Count);
            Assert.AreEqual(actual, sut.GetMaxSize("MyMaxSize"));
            Assert.AreEqual(sut, actual.Parent);
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            // Arrange
            var sut = new Scaling("MyScaling");
            // Assert
            Assert.IsTrue(sut.IsIdProvider);
        }

        
    }
}
