using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class MaxSize_Tests
    {
        private MaxSize _sut;

        [SetUp]
        public void Setup()
        {
            _sut = MaxSize.Create("MyMaxSize", "Group1", "100px");
        }

        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<MaxSize>(_sut);
            Assert.AreEqual("MyMaxSize", _sut.Id);
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            Assert.IsTrue(_sut.IsIdProvider);
        }

        [Test]
        public void PassedParameter_Is_Stored_In_OriginalId()
        {
            Assert.AreEqual("MyMaxSize", _sut.OriginalId);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            _sut.Set(MaxSizeProperty.Sequence, "111");
            Assert.AreEqual("111", _sut.Get(MaxSizeProperty.Sequence));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            _sut.Set(new Dictionary<MaxSizeProperty, string>()
                                  {
                                      {MaxSizeProperty.Size, "111"},
                                      {MaxSizeProperty.Sequence, "100"}
                                  });
            Assert.AreEqual("111", _sut.Get(MaxSizeProperty.Size));
            Assert.AreEqual("100", _sut.Get(MaxSizeProperty.Sequence));
        }
    }
}