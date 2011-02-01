using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class GalleryButton_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            var sut = Create<GalleryButton>.Instance("MyGalleryButton");

            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<GalleryButton>(sut);
            Assert.AreEqual("MyGalleryButton", sut.Id);
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            var sut = new GalleryButton("MyGalleryButton");
            Assert.AreEqual("MyGalleryButton", sut.OriginalId);
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            var sut = new GalleryButton("MyGalleryButton");
            Assert.IsTrue(sut.IsIdProvider);
        }

        [Test]
        public void Id_Should_Be_Compsited_If_Parent_Is_Present()
        {
            var sut = new GalleryButton("GalleryButton1");
            var group = new Group("ActionGroup1");
            var tab = new Tab("CommonTab");
            var ribbon = new Ribbon("MyRibbon");
            ribbon.With(() => tab
                                  .With(() => group
                                                  .With(() => sut)));

            Assert.AreEqual("MyRibbon.CommonTab.ActionGroup1.GalleryButton1", sut.Id);
        }

        [Test]
        public void Id_Should_Not_Be_Composited_If_Parent_Is_Not_Present()
        {
            var sut = new GalleryButton("MyGalleryButton");
            Assert.AreEqual("MyGalleryButton", sut.Id);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            var sut = new GalleryButton("MyGalleryButton");
            sut.Set(GalleryButtonProperty.ToolTipTitle, "My GalleryButton");

            Assert.AreEqual("My GalleryButton", sut.Get(GalleryButtonProperty.ToolTipTitle));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            var sut = new GalleryButton("MyGalleryButton");
            sut.Set(new Dictionary<GalleryButtonProperty, string>()
                                  {
                                      {GalleryButtonProperty.ToolTipTitle, "My GalleryButton ToolTip"},
                                      {GalleryButtonProperty.Alt, "My GalleryButton"}
                                  });
            Assert.AreEqual("My GalleryButton ToolTip", sut.Get(GalleryButtonProperty.ToolTipTitle));
            Assert.AreEqual("My GalleryButton", sut.Get(GalleryButtonProperty.Alt));
        }

        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode_For_Current_Instance()
        {
            // Arrange
            var sut = new GalleryButton("GalleryButton");
            var actual = GalleryButtonDisplayMode.Menu;
            // Act
            sut.SetDisplayMode(actual);
            // Assert
            Assert.AreEqual(actual.ToString(), sut.GetDisplayMode());
        }
    }
}