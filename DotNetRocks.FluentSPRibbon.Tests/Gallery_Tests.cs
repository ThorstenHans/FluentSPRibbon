using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Gallery_Tests
    {
        private Gallery _sut;

        [SetUp]
        public void Setup()
        {
            _sut = Gallery.Create("MyGallery", ElementDimension.Size16by16, "100px");
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            Assert.IsTrue(_sut.IsIdProvider);
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            Assert.AreEqual("MyGallery",_sut.OriginalId);
            Assert.AreEqual("Size16by16", _sut.Get(GalleryProperty.ElementDimensions));
            Assert.AreEqual("100px", _sut.Get(GalleryProperty.Width));
        }

        [Test]
        public void Indexer_Should_Return_GalleryButton()
        {
            var actual = new GalleryButton("MyGalleryButton");
            _sut._galleryButtons.Add(actual);
            Assert.AreEqual(actual, _sut["MyGalleryButton"]);
        }

        [Test]
        public void With_Should_Add_Current_GalleryButton_And_Set_Parent()
        {
            var actual = new GalleryButton("MyGalleryButton");
            _sut.With(() => actual);
            Assert.IsTrue(_sut._galleryButtons.Contains(actual));
            Assert.AreEqual(actual.Parent,_sut);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            _sut.Set(GalleryProperty.Command, "My Gallery");
            Assert.AreEqual("My Gallery", _sut.Get(GalleryProperty.Command));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            _sut.Set(new Dictionary<GalleryProperty, string>()
                                  {
                                      {GalleryProperty.QueryCommand, "My Gallery!"},
                                      {GalleryProperty.Command, "My Gallery"}
                                  });
            Assert.AreEqual("My Gallery!", _sut.Get(GalleryProperty.QueryCommand));
            Assert.AreEqual("My Gallery", _sut.Get(GalleryProperty.Command));
        }
    }
}
