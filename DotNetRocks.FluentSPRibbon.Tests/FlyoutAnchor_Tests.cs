using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class FlyoutAnchor_Tests
    {
        private FlyoutAnchor _sut;

        [SetUp]
        public void Setup()
        {
            _sut = FlyoutAnchor.Create("MyFlyoutAnchor");
        }

        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<FlyoutAnchor>(_sut);
            Assert.AreEqual("MyFlyoutAnchor", _sut.Id);
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            Assert.AreEqual("MyFlyoutAnchor", _sut.OriginalId);
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

            Assert.AreEqual("MyRibbon.CommonTab.ActionGroup1.MyFlyoutAnchor", _sut.Id);
        }

        [Test]
        public void Id_Should_Not_Be_Composited_If_Parent_Is_Not_Present()
        {
            Assert.AreEqual("MyFlyoutAnchor", _sut.Id);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            _sut.Set(FlyoutAnchorProperty.ToolTipTitle, "My FlyoutAnchor");
            Assert.AreEqual("My FlyoutAnchor", _sut.Get(FlyoutAnchorProperty.ToolTipTitle));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            _sut.Set(new Dictionary<FlyoutAnchorProperty, string>()
                                  {
                                      {FlyoutAnchorProperty.ToolTipTitle, "My FlyoutAnchor ToolTip"},
                                      {FlyoutAnchorProperty.Alt, "My FlyoutAnchor"}
                                  });
            Assert.AreEqual("My FlyoutAnchor ToolTip", _sut.Get(FlyoutAnchorProperty.ToolTipTitle));
            Assert.AreEqual("My FlyoutAnchor", _sut.Get(FlyoutAnchorProperty.Alt));
        }

        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode_For_Current_Instance()
        {
            var actual = FlyoutAnchorDisplayMode.Medium;
            _sut.SetDisplayMode(actual);
            Assert.AreEqual(actual.ToString(), _sut.GetDisplayMode());
        }
    }
}