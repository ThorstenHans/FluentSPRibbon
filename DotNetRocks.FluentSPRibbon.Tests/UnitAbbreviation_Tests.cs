using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class UnitAbbreviation_Tests
    {
        private UnitAbbreviation _sut;

        [SetUp]
        public void Setup()
        {
            _sut = UnitAbbreviation.Create("MyUnitAbbreviation");
        }

        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<UnitAbbreviation>(_sut);
            Assert.AreEqual("MyUnitAbbreviation", _sut.Id);
        }

        [Test]
        public void IsIdProvider_Should_Be_False()
        {
            Assert.IsFalse(_sut.IsIdProvider);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            _sut.Set(UnitAbbreviationProperty.Value, "My TextBox");
            Assert.AreEqual("My TextBox", _sut.Get(UnitAbbreviationProperty.Value));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            _sut.Set(new Dictionary<UnitAbbreviationProperty, string>()
                                  {
                                      {UnitAbbreviationProperty.Value, "My UnitAbbreviation Value"},
                                      {UnitAbbreviationProperty.Sequence, "100"}
                                  });
            Assert.AreEqual("My UnitAbbreviation Value", _sut.Get(UnitAbbreviationProperty.Value));
            Assert.AreEqual("100", _sut.Get(UnitAbbreviationProperty.Sequence));
        }
    }
}