using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Ribbon_Tests
    {
        private Ribbon _sut;

        [SetUp]
        public void Setup()
        {
            _sut = Ribbon.Create("MyRibbon");
        }

        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<Ribbon>(_sut);
            Assert.AreEqual("MyRibbon", _sut.Id);
        }

        [Test]
        public void A_New_Ribbon_Should_Always_Be_Empty()
        {
            Assert.AreEqual(0, _sut._tabs.Count);
        }

        [Test]
        public void With_Should_Add_Tab_And_Set_Parent()
        {
            var actual = new Tab("MyTab");
            _sut.With(() => actual);
            Assert.AreEqual(1, _sut._tabs.Count);
            Assert.AreEqual(actual, _sut["MyTab"]);
            Assert.AreEqual(_sut, actual.Parent);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            _sut.Set(RibbonProperty.NavigationHelpText, "Help");
            Assert.AreEqual("Help", _sut.Get(RibbonProperty.NavigationHelpText));
        }

        [Test]
        public void Set_Should_Store_Values()
        {
            _sut.Set(new Dictionary<RibbonProperty, string>()
                                  {
                                      {RibbonProperty.NavigationHelpText, "Help"},
                                      {RibbonProperty.ToolTipFooterText, "Footer"}
                                  });

            Assert.AreEqual("Help", _sut.Get(RibbonProperty.NavigationHelpText));
            Assert.AreEqual("Footer", _sut.Get(RibbonProperty.ToolTipFooterText));
        }

        [Test]
        public void ChildItemCount_Should_Return_Correct_Tabs_Count()
        {
            var tab1 = new Tab("Tab1");
            var tab2 = new Tab("Tab2");
            var tab3 = new Tab("Tab3");
            _sut.With(() => tab1);
            _sut.With(() => tab2);
            _sut.With(() => tab3);
            Assert.AreEqual(3, _sut._tabs.Count);
        }

        [Test]
        public void IsIdProvider_Should_Return_True()
        {
            Assert.IsTrue(_sut.IsIdProvider);
        }

        [Test]
        public void Passed_Parameter_Should_Be_Stored_In_OriginalId()
        {
            Assert.AreEqual("MyRibbon",_sut.OriginalId);
        }

        [Test]
        public void Ribbon_Should_Not_Contain_Tabs_Node_When_No_Tab_Is_Given()
        {
            var sut = Ribbon.Create("MyRibbon")
                .With(() => ContextualGroup.Create("MyContextualGroup"))
                .ToXml();
            Assert.That(sut,Is.Not.Contains("<Tabs"));
            Assert.That(sut, Is.StringContaining("<ContextualTabs"));
        }

        [Test]
        public void Ribbon_Should_Not_Contain_ContextualTabs_Node_When_No_ContextualTab_Is_Given()
        {
            var sut = Ribbon.Create("MyRibbon")
                .With(() => Tab.Create("MyTab"))
                .ToXml();
            Assert.That(sut, Is.Not.Contains("<ContextualTabs"));
            Assert.That(sut, Is.StringContaining("<Tabs"));
        }

        [Test]
        public void Indexer_Should_Return_Correct_Tab()
        {
            var tab1 = new Tab("Tab1");
            var tab2 = new Tab("Tab2");
            var tab3 = new Tab("Tab3");
            _sut.With(() => tab1);
            _sut.With(() => tab2);
            _sut.With(() => tab3);
            Assert.IsNull(_sut["MyRibbon.Tab1"]);
            Assert.AreEqual(tab1, _sut["Tab1"]);
            Assert.AreEqual(tab3, _sut["Tab3"]);
        }
    }
}