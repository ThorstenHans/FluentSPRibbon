using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Tab_Tests
    {
        private Tab _sut;

        [SetUp]
        public void Setup()
        {
            _sut = Tab.Create("MyTab");
        }

        [Test]
        public void Create_Should_Create_a_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<Tab>(_sut);
            Assert.AreEqual("MyTab", _sut.Id);
        }

        [Test]
        public void PassedParameter_Should_Be_Stored_In_OriginalId()
        {
            Assert.AreEqual("MyTab",_sut.OriginalId);
        }

        [Test]
        public void IsIdProvider_Should_Return_True()
        {
            Assert.IsTrue(_sut.IsIdProvider);
        }

        [Test]
        public void Id_Should_Return_Passed_Paremeter_If_No_Parent_Is_Present()
        {
            Assert.AreEqual("MyTab", _sut.Id);
        }

        [Test]
        public void Id_Should_Return_A_Composite_Id_If_Parent_Is_Present()
        {
            var ribbon = Ribbon.Create("MyRibbon")
                .With(() => Tab.Create("My1stTab"));
            Assert.AreEqual("MyRibbon.My1stTab",ribbon["My1stTab"].Id);
        }

        [Test]
        public void Set_Should_Store_PropertyValue()
        {
            _sut.Set(TabProperty.Title, "SuperTab");
            Assert.AreEqual("SuperTab",_sut.Get(TabProperty.Title));
        }

        [Test]
        public void Set_Should_Store_PropertyValues()
        {
            _sut.Set(new Dictionary<TabProperty, string>()
                                  {{TabProperty.Title, "SuperTab"}, {TabProperty.Description, "Description"}});

            Assert.AreEqual("SuperTab", _sut.Get(TabProperty.Title));
            Assert.AreEqual("Description",_sut.Get(TabProperty.Description));
        }

        [Test]
        public void With_Should_Add_Group_And_Set_Parent()
        {
            var actual = new Group("MyGroup");
            _sut.With(() => actual);
            Assert.AreEqual(_sut,actual.Parent);
            Assert.AreEqual(1,_sut._groups.Count);
        }

        [Test]
        public void With_Should_Set_Scaling_And_Set_Parent()
        {
            var actual = new Scaling("MyScaling");
            _sut.With(() => actual);
            Assert.AreEqual(actual,_sut.Scaling);
            Assert.AreEqual(_sut, actual.Parent);
            Assert.AreEqual("MyTab.MyScaling",actual.Id);
        }

        [Test]
        public void Indexer_Should_Return_Correct_Group()
        {
            var actual = new Group("MyGroup");
            var fake = new Group("SampleGroup");
            _sut._groups.Add(actual);
            _sut._groups.Add(fake);
            Assert.AreEqual(actual,_sut["MyGroup"]);
        }

        [Test]
        public void ChildItemCount_Should_Return_Groups_Count()
        {
            var grp1 = new Group("MyGroup");
            var grp2 = new Group("SampleGroup");
            var grp3 = new Group("OtherGroup");
            _sut.With(() => grp1);
            _sut.With(() => grp2);
            _sut.With(() => grp3);
            Assert.AreEqual(3,_sut._groups.Count);
        }
    }
}
