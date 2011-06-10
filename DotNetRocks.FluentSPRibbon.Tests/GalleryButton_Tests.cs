using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class GalleryButton_Tests
    {
        private GalleryButton _sut;

        [SetUp]
        public void Setup()
        {
            _sut = GalleryButton.Create("MyGalleryButton", ElementDimension.Size16by16);
        }

        [Test]
        public void Create_Should_Create_A_New_Instance()
        {

            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<GalleryButton>(_sut);
            Assert.AreEqual("MyGalleryButton", _sut.Id);
            Assert.AreEqual("Size16by16",_sut.Get(GalleryButtonProperty.ElementDimensions));
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            Assert.AreEqual("MyGalleryButton", _sut.OriginalId);
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            Assert.IsTrue(_sut.IsIdProvider);
        }

        [Test]
        public void Id_Should_Be_Compsited_If_Parent_Is_Present()
        {
            var group = new Group("ActionGroup1");
            var tab = new Tab("CommonTab");
            var ribbon = new Ribbon("MyRibbon");
            ribbon.With(() => tab
                                  .With(() => group
                                                  .With(() => _sut)));

            Assert.AreEqual("MyRibbon.CommonTab.ActionGroup1.MyGalleryButton", _sut.Id);
        }

        [Test]
        public void Id_Should_Not_Be_Composited_If_Parent_Is_Not_Present()
        {
            Assert.AreEqual("MyGalleryButton", _sut.Id);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            _sut.Set(GalleryButtonProperty.ToolTipTitle, "My GalleryButton");
            Assert.AreEqual("My GalleryButton", _sut.Get(GalleryButtonProperty.ToolTipTitle));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            _sut.Set(new Dictionary<GalleryButtonProperty, string>()
                                  {
                                      {GalleryButtonProperty.ToolTipTitle, "My GalleryButton ToolTip"},
                                      {GalleryButtonProperty.Alt, "My GalleryButton"}
                                  });
            Assert.AreEqual("My GalleryButton ToolTip", _sut.Get(GalleryButtonProperty.ToolTipTitle));
            Assert.AreEqual("My GalleryButton", _sut.Get(GalleryButtonProperty.Alt));
        }

        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode_For_Current_Instance()
        {
            var actual = GalleryButtonDisplayMode.Menu;
            _sut.SetDisplayMode(actual);
            Assert.AreEqual(actual.ToString(), _sut.GetDisplayMode());
        }
    }
}