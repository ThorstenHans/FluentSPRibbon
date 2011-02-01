using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Layout_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            // Arrange
            var sut = Create<Layout>.Instance("MyLayout");
            // Assert
            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<Layout>(sut);
            Assert.AreEqual("MyLayout", sut.Id);
        }

        [Test]
        public void If_Default_Constructor_Is_Called_Default_Value_Should_Be_Stored_In_OriginalId()
        {
            // Arrange
            var sut = new Layout();
            // Assert
            Assert.AreEqual("NotSet", sut.OriginalId);
        }

        [Test]
        public void IsIdProvider_Should_Be_False()
        {
            // Arrange
            var sut = new Layout("MyLayout");
            // Assert
            Assert.IsFalse(sut.IsIdProvider);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            var sut = new Layout("MyLayout");
            sut.Set(LayoutProperty.Title, "My LayoutName");

            Assert.AreEqual("My LayoutName", sut.Get(LayoutProperty.Title));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            var sut = new Layout("MyLayout");
            sut.Set(new Dictionary<LayoutProperty, string>()
                                  {
                                      {LayoutProperty.Title, "My LayoutName"}
                                  });
            Assert.AreEqual("My LayoutName", sut.Get(LayoutProperty.Title));
        }

        [Test]
        public void With_Should_Add_New_OverflowSection()
        {
            // Arrange
            var sut = new Layout("MyLayout");
            var expected = Create<OverflowSection>.Instance("OverflowSection");
            // Act
            sut.With(() => expected);

            // Assert
            Assert.IsNotNull(sut._overflowSections);
            Assert.AreEqual(1, sut._overflowSections.Count);
         
        } 
    }
}