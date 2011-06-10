using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Scale_Tests
    {
        private Scale sut;

        [SetUp]
        public void SetUp()
        {
            sut = Scale.Create("MyScale", "MyGroup", "100px");
        }

        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<Scale>(sut);
            Assert.AreEqual("MyScale", sut.Id);
            Assert.That(sut.Get(ScaleProperty.Size),Is.EqualTo("100px"));
            Assert.That(sut.Get(ScaleProperty.GroupId), Is.EqualTo("MyGroup"));
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
             
            Assert.IsTrue(sut.IsIdProvider);
        }

        [Test]
        public void PassedParameter_Is_Stored_In_OriginalId()
        {
           
            Assert.AreEqual("MyScale", sut.OriginalId);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            
            sut.Set(ScaleProperty.PopupSize, "111");

            Assert.AreEqual("111", sut.Get(ScaleProperty.PopupSize));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
           
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