using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class MRUSplitButton_Tests
    {
        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            var sut = Create<MRUSplitButton>.Instance("MyMRUSplitButton");

            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<MRUSplitButton>(sut);
            Assert.AreEqual("MyMRUSplitButton", sut.Id);
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            var sut = new MRUSplitButton("MyMRUSplitButton");
            Assert.AreEqual("MyMRUSplitButton", sut.OriginalId);
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            var sut = new MRUSplitButton("MyMRUSplitButton");
            Assert.IsTrue(sut.IsIdProvider);
        }

        [Test]
        public void Id_Should_Be_Compsited_If_Parent_Is_Present()
        {
            var sut = new MRUSplitButton("MRUSplitButton1");
            var group = new Group("ActionGroup1");
            var tab = new Tab("CommonTab");
            var ribbon = new Ribbon("MyRibbon");
            ribbon.With(() => tab
                                  .With(() => group
                                                  .With(() => sut)));

            Assert.AreEqual("MyRibbon.CommonTab.ActionGroup1.MRUSplitButton1", sut.Id);
        }

        [Test]
        public void Id_Should_Not_Be_Composited_If_Parent_Is_Not_Present()
        {
            var sut = new MRUSplitButton("MyMRUSplitButton");
            Assert.AreEqual("MyMRUSplitButton", sut.Id);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            var sut = new MRUSplitButton("MyMRUSplitButton");
            sut.Set(MRUProperty.ToolTipTitle, "My MRUSplitButton");

            Assert.AreEqual("My MRUSplitButton", sut.Get(MRUProperty.ToolTipTitle));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            var sut = new MRUSplitButton("MyMRUSplitButton");
            sut.Set(new Dictionary<MRUProperty, string>()
                                  {
                                      {MRUProperty.ToolTipTitle, "My MRUSplitButton ToolTip"},
                                      {MRUProperty.Alt, "My MRUSplitButton"}
                                  });
            Assert.AreEqual("My MRUSplitButton ToolTip", sut.Get(MRUProperty.ToolTipTitle));
            Assert.AreEqual("My MRUSplitButton", sut.Get(MRUProperty.Alt));
        }
    }
}