using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class DropDown_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            var sut = Create<DropDown>.Instance("MyDropDown");

            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<DropDown>(sut);
            Assert.AreEqual("MyDropDown", sut.Id);
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            var sut = new DropDown("MyDropDown");
            Assert.AreEqual("MyDropDown", sut.OriginalId);
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            var sut = new DropDown("MyDropDown");
            Assert.IsTrue(sut.IsIdProvider);
        }

        [Test]
        public void Id_Should_Be_Compsited_If_Parent_Is_Present()
        {
            var sut = new DropDown("DropDown1");
            var group = new Group("ActionGroup1");
            var tab = new Tab("CommonTab");
            var ribbon = new Ribbon("MyRibbon");
            ribbon.With(() => tab
                                  .With(() => group
                                                  .With(() => sut)));

            Assert.AreEqual("MyRibbon.CommonTab.ActionGroup1.DropDown1", sut.Id);
        }

        [Test]
        public void Id_Should_Not_Be_Composited_If_Parent_Is_Not_Present()
        {
            var sut = new DropDown("MyDropDown");
            Assert.AreEqual("MyDropDown", sut.Id);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            var sut = new DropDown("MyDropDown");
            sut.Set(DropDownProperty.ToolTipTitle, "My DropDown");

            Assert.AreEqual("My DropDown", sut.Get(DropDownProperty.ToolTipTitle));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            var sut = new DropDown("MyDropDown");
            sut.Set(new Dictionary<DropDownProperty, string>()
                                  {
                                      {DropDownProperty.ToolTipTitle, "My DropDown ToolTip"},
                                      {DropDownProperty.Alt, "My DropDown"}
                                  });
            Assert.AreEqual("My DropDown ToolTip", sut.Get(DropDownProperty.ToolTipTitle));
            Assert.AreEqual("My DropDown", sut.Get(DropDownProperty.Alt));
        }
    }
}