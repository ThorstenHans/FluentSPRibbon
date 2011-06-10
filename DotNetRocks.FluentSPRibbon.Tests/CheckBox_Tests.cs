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
        private CheckBox _sut;

        [SetUp]
        public void Setup()
        {
            _sut = CheckBox.Create("MyCheckBox");
        }

        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<CheckBox>(_sut);
            Assert.AreEqual("MyCheckBox",_sut.Id);
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            Assert.AreEqual("MyCheckBox",_sut.OriginalId);
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

            Assert.AreEqual("MyRibbon.CommonTab.ActionGroup1.MyCheckBox", _sut.Id);
        }

        [Test]
        public void Id_Should_Not_Be_Composited_If_Parent_Is_Not_Present()
        {
            Assert.AreEqual("MyCheckBox",_sut.Id);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            _sut.Set(CheckBoxProperty.LabelText, "My CheckBox");

            Assert.AreEqual("My CheckBox", _sut.Get(CheckBoxProperty.LabelText));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            _sut.Set(new Dictionary<CheckBoxProperty, string>()
                                  {
                                      {CheckBoxProperty.ToolTipTitle, "My CheckBox ToolTip"},
                                      {CheckBoxProperty.LabelText, "My CheckBox"}
                                  });
            Assert.AreEqual("My CheckBox ToolTip", _sut.Get(CheckBoxProperty.ToolTipTitle));
            Assert.AreEqual("My CheckBox", _sut.Get(CheckBoxProperty.LabelText));
        }

        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode_For_Current_Instance()
        {
            // Arrange
            var actual = CheckBoxDisplayMode.Medium;
            // Act
            _sut.SetDisplayMode(actual);
            // Assert
            Assert.AreEqual(actual.ToString(), _sut.GetDisplayMode());
        }
    }
}
