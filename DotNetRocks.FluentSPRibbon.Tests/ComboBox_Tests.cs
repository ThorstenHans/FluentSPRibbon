using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class ComboBox_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            var sut = Create<ComboBox>.Instance("MyComboBox");

            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<ComboBox>(sut);
            Assert.AreEqual("MyComboBox", sut.Id);
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            var sut = new ComboBox("MyComboBox");
            Assert.AreEqual("MyComboBox", sut.OriginalId);
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            var sut = new ComboBox("MyComboBox");
            Assert.IsTrue(sut.IsIdProvider);
        }

        [Test]
        public void Id_Should_Be_Compsited_If_Parent_Is_Present()
        {
            var sut = new ComboBox("ComboBox1");
            var group = new Group("ActionGroup1");
            var tab = new Tab("CommonTab");
            var ribbon = new Ribbon("MyRibbon");
            ribbon.With(() => tab
                                  .With(() => group
                                                  .With(() => sut)));

            Assert.AreEqual("MyRibbon.CommonTab.ActionGroup1.ComboBox1", sut.Id);
        }

        [Test]
        public void Id_Should_Not_Be_Composited_If_Parent_Is_Not_Present()
        {
            var sut = new ComboBox("MyComboBox");
            Assert.AreEqual("MyComboBox", sut.Id);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            var sut = new ComboBox("MyComboBox");
            sut.Set(ComboBoxProperty.ToolTipTitle, "My ComboBox");

            Assert.AreEqual("My ComboBox", sut.Get(ComboBoxProperty.ToolTipTitle));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            var sut = new ComboBox("MyComboBox");
            sut.Set(new Dictionary<ComboBoxProperty, string>()
                                  {
                                      {ComboBoxProperty.ToolTipTitle, "My ComboBox ToolTip"},
                                      {ComboBoxProperty.Alt, "My ComboBox"}
                                  });
            Assert.AreEqual("My ComboBox ToolTip", sut.Get(ComboBoxProperty.ToolTipTitle));
            Assert.AreEqual("My ComboBox", sut.Get(ComboBoxProperty.Alt));
        }
    }
}