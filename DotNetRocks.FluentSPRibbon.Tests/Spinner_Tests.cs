using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Spinner_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            var sut = Create<Spinner>.Instance("MySpinner");

            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<Spinner>(sut);
            Assert.AreEqual("MySpinner", sut.Id);
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            var sut = new Spinner("MySpinner");
            Assert.AreEqual("MySpinner", sut.OriginalId);
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            var sut = new Spinner("MySpinner");
            Assert.IsTrue(sut.IsIdProvider);
        }

        [Test]
        public void Id_Should_Be_Compsited_If_Parent_Is_Present()
        {
            var sut = new Spinner("Spinner1");
            var group = new Group("ActionGroup1");
            var tab = new Tab("CommonTab");
            var ribbon = new Ribbon("MyRibbon");
            ribbon.With(() => tab
                                  .With(() => group
                                                  .With(() => sut)));

            Assert.AreEqual("MyRibbon.CommonTab.ActionGroup1.Spinner1", sut.Id);
        }

        [Test]
        public void Id_Should_Not_Be_Composited_If_Parent_Is_Not_Present()
        {
            var sut = new Spinner("MySpinner");
            Assert.AreEqual("MySpinner", sut.Id);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            var sut = new Spinner("MySpinner");
            sut.Set(SpinnerProperty.ToolTipTitle, "My Spinner");

            Assert.AreEqual("My Spinner", sut.Get(SpinnerProperty.ToolTipTitle));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            var sut = new Spinner("MySpinner");
            sut.Set(new Dictionary<SpinnerProperty, string>()
                                  {
                                      {SpinnerProperty.ToolTipTitle, "My Spinner ToolTip"},
                                      {SpinnerProperty.TemplateAlias, "My Spinner"}
                                  });
            Assert.AreEqual("My Spinner ToolTip", sut.Get(SpinnerProperty.ToolTipTitle));
            Assert.AreEqual("My Spinner", sut.Get(SpinnerProperty.TemplateAlias));
        }

        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode_For_Current_Instance()
        {
            // Arrange
            var sut = new Spinner("Spinner");
            var actual = SpinnerDisplayMode.Medium;
            // Act
            sut.SetDisplayMode(actual);
            // Assert
            Assert.AreEqual(actual.ToString(), sut.GetDisplayMode());
        }
    }
}