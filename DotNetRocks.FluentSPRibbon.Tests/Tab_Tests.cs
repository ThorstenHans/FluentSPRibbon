using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Tab_Tests
    {
        [Test]
        public void Create_Should_Create_a_New_Instance()
        {
            var sut = Create<Tab>.Instance("Id");

            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<Tab>(sut);
            Assert.AreEqual("Id",sut.Id);
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            var sut = new Tab("MyTab");
            Assert.AreEqual("MyTab",sut.OriginalId);
        }

        [Test]
        public void IsIdProvider_Should_Return_True()
        {
            var sut = new Tab("MyTab");
            Assert.IsTrue(sut.IsIdProvider);
        }

        [Test]
        public void Id_Should_Return_Passed_Paremeter_If_No_Parent_Is_Present()
        {
            var sut = new Tab("MyTab1");
            Assert.AreEqual("MyTab1",sut.Id);
        }

        [Test]
        public void Id_Should_Return_A_Composite_Id_If_Parent_Is_Present()
        {
            var ribbon = Create<Ribbon>.Instance("MyRibbon")
                .With(() => Create<Tab>.Instance("My1stTab"));
            Assert.AreEqual("MyRibbon.My1stTab",ribbon["My1stTab"].Id);
        }

        [Test]
        public void Set_Should_Store_PropertyValue()
        {
            var sut = new Tab("MyRibbonTab");
            sut.Set(TabProperty.Title, "SuperTab");
            Assert.AreEqual("SuperTab",sut.Get(TabProperty.Title));
        }

        [Test]
        public void Set_Should_Store_PropertyValues()
        {
            var sut = new Tab("MyRibbonTab");
            sut.Set(new Dictionary<TabProperty, string>()
                                  {{TabProperty.Title, "SuperTab"}, {TabProperty.Description, "Description"}});

            Assert.AreEqual("SuperTab", sut.Get(TabProperty.Title));
            Assert.AreEqual("Description",sut.Get(TabProperty.Description));
        }

        [Test]
        public void With_Should_Add_Group_And_Set_Parent()
        {
            var sut = new Tab("MyTab");
            var actual = new Group("MyGroup");
            sut.With(() => actual);

            Assert.AreEqual(sut,actual.Parent);
            Assert.AreEqual(1,sut._groups.Count);
        }

        [Test]
        public void With_Should_Set_Scaling_And_Set_Parent()
        {
            var sut = new Tab("MyTab");
            var actual = new Scaling("MyScaling");
            sut.With(() => actual);
            Assert.AreEqual(actual,sut.Scaling);
            Assert.AreEqual(sut, actual.Parent);
            Assert.AreEqual("MyTab.MyScaling",actual.Id);
        }

        [Test]
        public void Indexer_Should_Return_Correct_Group()
        {
            var sut = new Tab("MyTab");
            var actual = new Group("MyGroup");
            var fake = new Group("SampleGroup");

            sut._groups.Add(actual);
            sut._groups.Add(fake);
            Assert.AreEqual(actual,sut["MyGroup"]);
        }

        [Test]
        public void ChildItemCount_Should_Return_Groups_Count()
        {
            var sut = new Tab("MyTab");
            var grp1 = new Group("MyGroup");
            var grp2 = new Group("SampleGroup");
            var grp3 = new Group("OtherGroup");

            sut.With(() => grp1);
            sut.With(() => grp2);
            sut.With(() => grp3);

            Assert.AreEqual(3,sut.ChildItemCount);
        }
    }
}
