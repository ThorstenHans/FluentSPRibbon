using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Scaling_Tests
    {
        private Scaling _sut;

        [SetUp]
        public void Setup()
        {
            _sut = Scaling.Create("MyScaling");
        }
        [Test]
        public void If_DefaultConstructor_Is_Called_A_DefaultValue_Should_Be_Passed()
        {
            _sut  = new Scaling();
            Assert.AreEqual("NotSet",_sut.Id);
        }
        [Test]
        public void Create_Should_Create_A_New_Scaling_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<Scaling>(_sut);
            Assert.AreEqual("MyScaling",_sut.Id);
        }

        [Test]
        public void GetMaxSize_Should_Find_And_Return_The_Correxct_MaxSize()
        {
            var fake = new MaxSize("MyMaxSize1");
            var actual = new MaxSize("MyMaxSize");
            _sut._maxSizes.Add(fake);
            _sut._maxSizes.Add(actual);
            Assert.AreEqual(actual,_sut.GetMaxSize("MyMaxSize"));
        }

        [Test]
        public void GetScale_Should_Find_And_Return_The_Correct_Scale()
        {
            var fake = new Scale("MyScale1");
            var actual = new Scale("MyScale");

            _sut._scales.Add(fake);
            _sut._scales.Add(actual);

            Assert.AreEqual(actual,_sut.GetScale("MyScale"));
        }

        [Test]
        public void WithScale_Should_Add_Scale_And_Set_Parent()
        {
            var actual = new Scale("MyScale");

            _sut.With(() => actual);

            Assert.AreEqual(1, _sut._scales.Count);
            Assert.AreEqual(actual, _sut.GetScale("MyScale"));
            Assert.AreEqual(_sut, actual.Parent);
        }

        [Test]
        public void WithMaxSize_Should_Add_MaxSize_And_Set_Parent()
        {
            var actual = new MaxSize("MyMaxSize");

            _sut.With(() => actual);

            Assert.AreEqual(1, _sut._maxSizes.Count);
            Assert.AreEqual(actual, _sut.GetMaxSize("MyMaxSize"));
            Assert.AreEqual(_sut, actual.Parent);
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            Assert.IsTrue(_sut.IsIdProvider);
        }

    }
}
