using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Ribbon_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            var sut = Create<Ribbon>.Instance("MyRibbon");

            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<Ribbon>(sut);
            Assert.AreEqual("MyRibbon", sut.Id);
        }

        [Test]
        public void A_New_Ribbon_Should_Always_Be_Empty()
        {
            var newRibbon = new Ribbon("MyRibbon");

            Assert.AreEqual(0, newRibbon.ChildItemCount);
        }

        [Test]
        public void With_Should_Add_Tab_And_Set_Parent()
        {
            var sut = new Ribbon("MyRibbon");
            var actual = new Tab("MyTab");

            sut.With(() => actual);

            Assert.AreEqual(1, sut._tabs.Count);
            Assert.AreEqual(actual, sut["MyTab"]);
            Assert.AreEqual(sut, actual.Parent);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            var sut = new Ribbon("MyRibbon");

            sut.Set(RibbonProperty.NavigationHelpText, "Help");

            Assert.AreEqual("Help", sut.Get(RibbonProperty.NavigationHelpText));
        }

        [Test]
        public void Set_Should_Store_Values()
        {
            var sut = new Ribbon("MyRibbon");
            sut.Set(new Dictionary<RibbonProperty, string>()
                                  {
                                      {RibbonProperty.NavigationHelpText, "Help"},
                                      {RibbonProperty.ToolTipFooterText, "Footer"}
                                  });

            Assert.AreEqual("Help", sut.Get(RibbonProperty.NavigationHelpText));
            Assert.AreEqual("Footer", sut.Get(RibbonProperty.ToolTipFooterText));
        }

        [Test]
        public void ChildItemCount_Should_Return_Correct_Tabs_Count()
        {
            var sut = new Ribbon("MyRibbon");
            var tab1 = new Tab("Tab1");
            var tab2 = new Tab("Tab2");
            var tab3 = new Tab("Tab3");
            sut.With(() => tab1);
            sut.With(() => tab2);
            sut.With(() => tab3);

            Assert.AreEqual(3, sut.ChildItemCount);
        }

        [Test]
        public void IsIdProvider_Should_Return_True()
        {
            var sut = new Ribbon("MyRibbon");
            Assert.IsTrue(sut.IsIdProvider);
        }

        [Test]
        public void Passed_Parameter_Should_Be_Stored_In_OriginalId()
        {
            var sut = new Ribbon("MyRibbon");
            Assert.AreEqual("MyRibbon",sut.OriginalId);
        }

        [Test]
        public void Indexer_Should_Return_Correct_Tab()
        {
            var sut = new Ribbon("MyRibbon");
            var tab1 = new Tab("Tab1");
            var tab2 = new Tab("Tab2");
            var tab3 = new Tab("Tab3");
            sut.With(() => tab1);
            sut.With(() => tab2);
            sut.With(() => tab3);

            Assert.IsNull(sut["MyRibbon.Tab1"]);
            Assert.AreEqual(tab1, sut["Tab1"]);
            Assert.AreEqual(tab3, sut["Tab3"]);
        }


    }
}