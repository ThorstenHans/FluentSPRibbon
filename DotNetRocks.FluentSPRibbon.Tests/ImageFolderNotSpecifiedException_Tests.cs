using System;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class ImageFolderNotSpecifiedException_Tests
    {
        [Test]
        public void Default_Constructor_Should_Create_Plain_Instance()
        {
            var sut = new ImageFolderNotSpecifiedException();
            Assert.IsNull(sut.InnerException);
        }

        [Test]
        public void If_Message_Is_Passed_To_Constructor_It_Should_Be_Stored_In_Message_Property()
        {
            String exceptionMessage = "ExceptionMessage";
            var sut = new ImageFolderNotSpecifiedException(exceptionMessage);
            Assert.AreEqual(exceptionMessage,sut.Message);
        }

        [Test]
        public void If_Message_And_Inner_Exception_Is_Passed_Them_Should_Be_Stored_In_Properties()
        {
            String exceptionMessage = "ExceptionMessage";
            var innerEx = new IndexOutOfRangeException();
            var sut = new ImageFolderNotSpecifiedException(exceptionMessage,innerEx);
            Assert.AreEqual(exceptionMessage, sut.Message);
            Assert.AreEqual(innerEx,sut.InnerException);
        }
    }
}