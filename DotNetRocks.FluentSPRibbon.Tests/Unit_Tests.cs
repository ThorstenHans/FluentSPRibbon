using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Unit_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            // Arrange
            var sut = Create<Unit>.Instance("MyUnit");
            // Assert
            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<Unit>(sut);
            Assert.AreEqual("MyUnit",sut.Id);
        }

        [Test]
        public void If_Default_Constructor_Is_Called_Default_Value_Should_Be_Stored_In_OriginalId()
        {
            // Arrange
            var sut = new Unit();
            // Assert
            Assert.AreEqual("NotSet",sut.OriginalId);
        }

        [Test]
        public void IsIdProvider_Should_Be_False()
        {
            // Arrange
            var sut = new Unit("MyUnit");
            // Assert
            Assert.IsFalse(sut.IsIdProvider);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            var sut = new Unit("MyUnit");
            sut.Set(UnitProperty.Name, "My UnitName");

            Assert.AreEqual("My UnitName", sut.Get(UnitProperty.Name));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            var sut = new Unit("MyUnit");
            sut.Set(new Dictionary<UnitProperty, string>()
                                  {
                                      {UnitProperty.Name, "My UnitName"}
                                  });
            Assert.AreEqual("My UnitName", sut.Get(UnitProperty.Name));
        }

        [Test]
        public void With_Should_Add_New_Layout_And_Set_Parent_Reference()
        {
            // Arrange
            var sut = new Unit("MyUnit");
            var expected = Create<UnitAbbreviation>.Instance("UnitAbbreviation");
            // Act
            sut.With(() => expected);

            // Assert
            Assert.IsNotNull(sut._unitAbbreviations);
            Assert.AreEqual(1, sut._unitAbbreviations.Count);
            Assert.AreEqual(sut, expected.Parent);
        }

    }
}