using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Spinner_Tests
    {
        private Spinner _sut;

        [SetUp]
        public void Setup()
        {
            _sut = Spinner.Create("MySpinner");
        }
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<Spinner>(_sut);
            Assert.AreEqual("MySpinner", _sut.Id);
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            Assert.AreEqual("MySpinner", _sut.OriginalId);
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
            Assert.AreEqual("MyRibbon.CommonTab.ActionGroup1.MySpinner", _sut.Id);
        }

        [Test]
        public void Id_Should_Not_Be_Composited_If_Parent_Is_Not_Present()
        {
            Assert.AreEqual("MySpinner", _sut.Id);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            _sut.Set(SpinnerProperty.ToolTipTitle, "My Spinner");
            Assert.AreEqual("My Spinner", _sut.Get(SpinnerProperty.ToolTipTitle));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            _sut.Set(new Dictionary<SpinnerProperty, string>()
                                  {
                                      {SpinnerProperty.ToolTipTitle, "My Spinner ToolTip"},
                                      {SpinnerProperty.TemplateAlias, "My Spinner"}
                                  });
            Assert.AreEqual("My Spinner ToolTip", _sut.Get(SpinnerProperty.ToolTipTitle));
            Assert.AreEqual("My Spinner", _sut.Get(SpinnerProperty.TemplateAlias));
        }

        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode_For_Current_Instance()
        {
            var actual = SpinnerDisplayMode.Medium;
            _sut.SetDisplayMode(actual);
            Assert.AreEqual(actual.ToString(), _sut.GetDisplayMode());
        }
    }
}