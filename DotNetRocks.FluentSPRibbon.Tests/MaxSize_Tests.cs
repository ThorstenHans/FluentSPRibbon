using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class MaxSize_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            var sut = Create<MaxSize>.Instance("MyMaxSize");

            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<MaxSize>(sut);
            Assert.AreEqual("MyMaxSize", sut.Id);
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            var sut = new MaxSize("MyMaxSize");
            Assert.IsTrue(sut.IsIdProvider);
        }

        [Test]
        public void PassedParameter_Is_Stored_In_OriginalId()
        {
            var sut = new MaxSize("MyMaxSize");
            Assert.AreEqual("MyMaxSize", sut.OriginalId);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            var sut = new MaxSize("MyMaxSize");
            sut.Set(MaxSizeProperty.Sequence, "111");

            Assert.AreEqual("111", sut.Get(MaxSizeProperty.Sequence));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            var sut = new MaxSize("MyMaxSize");
            sut.Set(new Dictionary<MaxSizeProperty, string>()
                                  {
                                      {MaxSizeProperty.Size, "111"},
                                      {MaxSizeProperty.Sequence, "100"}
                                  });
            Assert.AreEqual("111", sut.Get(MaxSizeProperty.Size));
            Assert.AreEqual("100", sut.Get(MaxSizeProperty.Sequence));
        }
    }
}