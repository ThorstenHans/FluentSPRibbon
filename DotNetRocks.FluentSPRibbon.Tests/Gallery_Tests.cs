using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Gallery_Tests
    {

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            // Arrange
            var sut = new Gallery("Sample");
            // Assert
            Assert.IsTrue(sut.IsIdProvider);
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            // Arrange
            var sut = new Gallery("Gallery1");
            // Assert
            Assert.AreEqual("Gallery1",sut.OriginalId);
        }

        [Test]
        public void If_Default_Constructor_Is_Called_DefaultValue_Should_Be_Stored_In_OriginalId()
        {
            // Arrange
            var sut = new Gallery();
            // Assert
            Assert.AreEqual("NotSet", sut.OriginalId);
        }

        [Test]
        public void Indexer_Should_Return_GalleryButton()
        {
            var sut = new Gallery("MyGallery");
            var actual = new GalleryButton("MyGalleryButton");
            sut._galleryButtons.Add(actual);

            Assert.AreEqual(actual, sut["MyGalleryButton"]);
        }

        [Test]
        public void With_Should_Add_Current_GalleryButton_And_Set_Parent()
        {
            var sut = new Gallery("MyGallery");
            var actual = new GalleryButton("MyGalleryButton");
            sut.With(() => actual);

            Assert.IsTrue(sut._galleryButtons.Contains(actual));
            Assert.AreEqual(actual.Parent,sut);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            var sut = new Gallery("MyGallery");
            sut.Set(GalleryProperty.Command, "My Gallery");

            Assert.AreEqual("My Gallery", sut.Get(GalleryProperty.Command));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            var sut = new Gallery("MyGallery");
            sut.Set(new Dictionary<GalleryProperty, string>()
                                  {
                                      {GalleryProperty.QueryCommand, "My Gallery!"},
                                      {GalleryProperty.Command, "My Gallery"}
                                  });
            Assert.AreEqual("My Gallery!", sut.Get(GalleryProperty.QueryCommand));
            Assert.AreEqual("My Gallery", sut.Get(GalleryProperty.Command));
        }

    }
}
