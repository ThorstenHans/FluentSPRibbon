using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Strip_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            // Arrange
            var sut = Create<Strip>.Instance("MyStrip");
            // Assert
            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<Strip>(sut);
        }

        [Test]
        public void XmlElementName_Should_Be_Strip()
        {
            // Arrange
            var sut = new Strip();
            // Assert
            Assert.AreEqual("Strip",sut.XmlElementName);
        }

        [Test]
        public void IsIdProvider_Should_Be_False()
        {
            // Arrange
            var sut = new Strip();
            // Assert
            Assert.IsFalse(sut.IsIdProvider);
        }

        [Test]
        public void With_Should_Add_ControlRef_To_Current_Instance()
        {
            // Arrange
            var sut = new Strip();
            var controlRef = new ControlRef();

            // Act
            sut.With(() => controlRef);
            // Assert
            Assert.AreEqual(1,sut._controlRefs.Count);
            Assert.AreEqual(controlRef, sut._controlRefs[0]);
        }

        [Test]
        public void If_Default_Constructor_Is_Called_DefaultValue_Should_Be_Stored_In_OriginalId()
        {
            // Arrange
            var sut = new Strip();
            // Assert
            Assert.AreEqual("NotSet", sut.Id);
        }
    
    }
}