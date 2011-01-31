using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Scale_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            var sut = Create<Scale>.Instance("MyScale");

            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<Scale>(sut);
            Assert.AreEqual("MyScale", sut.Id);
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            var sut = new Scale("MyScale");
            Assert.IsTrue(sut.IsIdProvider);
        }

        [Test]
        public void PassedParameter_Is_Stored_In_OriginalId()
        {
            var sut = new Scale("MyScale");
            Assert.AreEqual("MyScale", sut.OriginalId);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            var sut = new Scale("MyScale");
            sut.Set(ScaleProperty.PopupSize, "111");

            Assert.AreEqual("111", sut.Get(ScaleProperty.PopupSize));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            var sut = new Scale("MyScale");
            sut.Set(new Dictionary<ScaleProperty, string>()
                                  {
                                      {ScaleProperty.PopupSize, "111"},
                                      {ScaleProperty.Sequence, "100"}
                                  });
            Assert.AreEqual("111", sut.Get(ScaleProperty.PopupSize));
            Assert.AreEqual("100", sut.Get(ScaleProperty.Sequence));
        }
    }
}