using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class CheckBox_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            var sut = Create<CheckBox>.Instance("MyCheckBox");

            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<CheckBox>(sut);
            Assert.AreEqual("MyCheckBox",sut.Id);
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            var sut = new CheckBox("MyCheckBox");
            Assert.AreEqual("MyCheckBox",sut.OriginalId);
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            var sut = new CheckBox("MyCheckBox");
            Assert.IsTrue(sut.IsIdProvider);
        }

        [Test]
        public void Id_Should_Be_Compsited_If_Parent_Is_Present()
        {
            var sut = new CheckBox("CheckBox1");
            var group = new Group("ActionGroup1");
            var tab = new Tab("CommonTab");
            var ribbon = new Ribbon("MyRibbon");
            ribbon.With(() => tab
                                  .With(() => group
                                                  .With(() => sut)));

            Assert.AreEqual("MyRibbon.CommonTab.ActionGroup1.CheckBox1", sut.Id);
        }

        [Test]
        public void Id_Should_Not_Be_Composited_If_Parent_Is_Not_Present()
        {
            var sut = new CheckBox("MyCheckBox");
            Assert.AreEqual("MyCheckBox",sut.Id);
        }

        [Test]
        public void SetProperty_Should_Store_Value()
        {
            var sut = new CheckBox("MyCheckBox");
            sut.SetProperty(CheckBoxProperty.LabelText, "My CheckBox");

            Assert.AreEqual("My CheckBox", sut.GetProperty(CheckBoxProperty.LabelText));
        }

        [Test]
        public void SetProperties_Should_Store_MultipleValues()
        {
            var sut = new CheckBox("MyCheckBox");
            sut.SetProperties(new Dictionary<CheckBoxProperty, string>()
                                  {
                                      {CheckBoxProperty.ToolTipTitle, "My CheckBox ToolTip"},
                                      {CheckBoxProperty.LabelText, "My CheckBox"}
                                  });
            Assert.AreEqual("My CheckBox ToolTip", sut.GetProperty(CheckBoxProperty.ToolTipTitle));
            Assert.AreEqual("My CheckBox", sut.GetProperty(CheckBoxProperty.LabelText));
        }
    }
}
