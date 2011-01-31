using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class ToggleButton_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            var sut = Create<ToggleButton>.Instance("MyToggleButton");

            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<ToggleButton>(sut);
            Assert.AreEqual("MyToggleButton", sut.Id);
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            var sut = new ToggleButton("MyToggleButton");
            Assert.AreEqual("MyToggleButton", sut.OriginalId);
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            var sut = new ToggleButton("MyToggleButton");
            Assert.IsTrue(sut.IsIdProvider);
        }

        [Test]
        public void Id_Should_Be_Compsited_If_Parent_Is_Present()
        {
            var sut = new ToggleButton("ToggleButton1");
            var group = new Group("ActionGroup1");
            var tab = new Tab("CommonTab");
            var ribbon = new Ribbon("MyRibbon");
            ribbon.With(() => tab
                                  .With(() => group
                                                  .With(() => sut)));

            Assert.AreEqual("MyRibbon.CommonTab.ActionGroup1.ToggleButton1", sut.Id);
        }

        [Test]
        public void Id_Should_Not_Be_Composited_If_Parent_Is_Not_Present()
        {
            var sut = new ToggleButton("MyToggleButton");
            Assert.AreEqual("MyToggleButton", sut.Id);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            var sut = new ToggleButton("MyToggleButton");
            sut.Set(ToggleButtonProperty.ToolTipTitle, "My ToggleButton");

            Assert.AreEqual("My ToggleButton", sut.Get(ToggleButtonProperty.ToolTipTitle));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            var sut = new ToggleButton("MyToggleButton");
            sut.Set(new Dictionary<ToggleButtonProperty, string>()
                                  {
                                      {ToggleButtonProperty.ToolTipTitle, "My ToggleButton ToolTip"},
                                      {ToggleButtonProperty.TemplateAlias, "My ToggleButton"}
                                  });
            Assert.AreEqual("My ToggleButton ToolTip", sut.Get(ToggleButtonProperty.ToolTipTitle));
            Assert.AreEqual("My ToggleButton", sut.Get(ToggleButtonProperty.TemplateAlias));
        }
    }
}