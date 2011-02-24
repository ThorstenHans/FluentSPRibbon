using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Unit_Tests
    {
        private Unit _sut;

        [SetUp]
        public void Setup()
        {
            _sut = Unit.Create("MyUnit");
        }
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<Unit>(_sut);
            Assert.AreEqual("MyUnit",_sut.Id);
        }

        [Test]
        public void IsIdProvider_Should_Be_False()
        {
            Assert.IsFalse(_sut.IsIdProvider);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            _sut.Set(UnitProperty.Name, "My UnitName");
            Assert.AreEqual("My UnitName", _sut.Get(UnitProperty.Name));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            _sut.Set(new Dictionary<UnitProperty, string>()
                                  {
                                      {UnitProperty.Name, "My UnitName"}
                                  });
            Assert.AreEqual("My UnitName", _sut.Get(UnitProperty.Name));
        }

        [Test]
        public void With_Should_Add_New_Layout_And_Set_Parent_Reference()
        {
            var expected = UnitAbbreviation.Create("UnitAbbreviation");
            _sut.With(() => expected);
            Assert.IsNotNull(_sut._unitAbbreviations);
            Assert.AreEqual(1, _sut._unitAbbreviations.Count);
            Assert.AreEqual(_sut, expected.Parent);
        }
    }
}