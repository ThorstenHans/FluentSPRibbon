using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Label_Tests
    {
        private Label _sut;

        [SetUp]
        public void Setup()
        {
            _sut = Label.Create("MyLabel");
        }

        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<Label>(_sut);
            Assert.AreEqual("MyLabel", _sut.Id);
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            Assert.AreEqual("MyLabel", _sut.OriginalId);
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
            Assert.AreEqual("MyRibbon.CommonTab.ActionGroup1.MyLabel", _sut.Id);
        }

        [Test]
        public void Id_Should_Not_Be_Composited_If_Parent_Is_Not_Present()
        {
            Assert.AreEqual("MyLabel", _sut.Id);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            _sut.Set(LabelProperty.LabelText, "My Label");
            Assert.AreEqual("My Label", _sut.Get(LabelProperty.LabelText));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            _sut.Set(new Dictionary<LabelProperty, string>()
                                  {
                                      {LabelProperty.LabelText, "My Label ToolTip"},
                                      {LabelProperty.TemplateAlias, "My Label"}
                                  });
            Assert.AreEqual("My Label ToolTip", _sut.Get(LabelProperty.LabelText));
            Assert.AreEqual("My Label", _sut.Get(LabelProperty.TemplateAlias));
        }

        [Test]
        public void SetDisplayMode_Should_Store_DisplayMode_For_Current_Instance()
        {
            var actual = LabelDisplayMode.Medium;
            _sut.SetDisplayMode(actual);
            Assert.AreEqual(actual.ToString(), _sut.GetDisplayMode());
        }
    }
}