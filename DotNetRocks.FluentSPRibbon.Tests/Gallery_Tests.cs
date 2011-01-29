using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Gallery_Tests
    {
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


    }
}
