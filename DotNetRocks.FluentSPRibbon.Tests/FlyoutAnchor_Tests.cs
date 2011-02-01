using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class FlyoutAnchor_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            var sut = Create<FlyoutAnchor>.Instance("MyFlyoutAnchor");

            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<FlyoutAnchor>(sut);
            Assert.AreEqual("MyFlyoutAnchor", sut.Id);
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            var sut = new FlyoutAnchor("MyFlyoutAnchor");
            Assert.AreEqual("MyFlyoutAnchor", sut.OriginalId);
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            var sut = new FlyoutAnchor("MyFlyoutAnchor");
            Assert.IsTrue(sut.IsIdProvider);
        }

        [Test]
        public void Id_Should_Be_Compsited_If_Parent_Is_Present()
        {
            var sut = new FlyoutAnchor("FlyoutAnchor1");
            var group = new Group("ActionGroup1");
            var tab = new Tab("CommonTab");
            var ribbon = new Ribbon("MyRibbon");
            ribbon.With(() => tab
                                  .With(() => group
                                                  .With(() => sut)));

            Assert.AreEqual("MyRibbon.CommonTab.ActionGroup1.FlyoutAnchor1", sut.Id);
        }

        [Test]
        public void Id_Should_Not_Be_Composited_If_Parent_Is_Not_Present()
        {
            var sut = new FlyoutAnchor("MyFlyoutAnchor");
            Assert.AreEqual("MyFlyoutAnchor", sut.Id);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            var sut = new FlyoutAnchor("MyFlyoutAnchor");
            sut.Set(FlyoutAnchorProperty.ToolTipTitle, "My FlyoutAnchor");

            Assert.AreEqual("My FlyoutAnchor", sut.Get(FlyoutAnchorProperty.ToolTipTitle));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            var sut = new FlyoutAnchor("MyFlyoutAnchor");
            sut.Set(new Dictionary<FlyoutAnchorProperty, string>()
                                  {
                                      {FlyoutAnchorProperty.ToolTipTitle, "My FlyoutAnchor ToolTip"},
                                      {FlyoutAnchorProperty.Alt, "My FlyoutAnchor"}
                                  });
            Assert.AreEqual("My FlyoutAnchor ToolTip", sut.Get(FlyoutAnchorProperty.ToolTipTitle));
            Assert.AreEqual("My FlyoutAnchor", sut.Get(FlyoutAnchorProperty.Alt));
        }

        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode_For_Current_Instance()
        {
            // Arrange
            var sut = new FlyoutAnchor("FlyoutAnchor");
            var actual = FlyoutAnchorDisplayMode.Medium;
            // Act
            sut.SetDisplayMode(actual);
            // Assert
            Assert.AreEqual(actual.ToString(), sut.GetDisplayMode());
        }
    }
}