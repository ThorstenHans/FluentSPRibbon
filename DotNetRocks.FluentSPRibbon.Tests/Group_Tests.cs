using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Group_Tests
    {
        private Group _sut;

        [SetUp]
        public void Setup()
        {
            _sut = Group.Create("MyGroup");
        }

        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<Group>(_sut);
            Assert.AreEqual("MyGroup",_sut.Id);
        }

        [Test]
        public void SetClassTo_Should_Set_CssClass_OnGroup()
        {
            var expected = "myCssClass";
            _sut.SetClassTo(expected);
            Assert.That(_sut.ClassName, Is.EqualTo(expected));
        }

        [Test]
        public void SetLayout_Should_Set_Layou_Properties()
        {
            var expectedTitle = "Title";
            var expectedLayoutTitle = "LayoutTitle";
            _sut.SetLayout(() => Layout.Create("MyLayout", "Title")
                                      .Set(LayoutProperty.Title, expectedTitle)
                                       .Set(LayoutProperty.LayoutTitle, expectedLayoutTitle));
            Assert.That(_sut.Layout, Is.Not.Null);
            Assert.That(_sut.Layout.Get(LayoutProperty.Title),Is.EqualTo(expectedTitle));
            Assert.That(_sut.Layout.Get(LayoutProperty.LayoutTitle), Is.EqualTo(expectedLayoutTitle));
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            Assert.IsTrue(_sut.IsIdProvider);
        }

        [Test]
        public void PassedParameter_Is_Stored_In_OriginalId()
        {
            Assert.AreEqual("MyGroup",_sut.OriginalId);
        }

        [Test]
        public void Id_Should_Return_Passed_Parameter_If_No_Parent_Is_Present()
        {
            Assert.AreEqual("MyGroup", _sut.Id);
        }

        [Test]
        public void Id_Should_Be_Composed_If_Parent_Is_Present()
        {
            var tab = new Tab("Tab2").With(() => _sut);
            var ribbon = new Ribbon("Ribbon3")
                .With(()=>tab);
            Assert.AreEqual("Ribbon3.Tab2.MyGroup", _sut.Id);
        }
        [Test]
        public void ApplyControlsProperty_Should_Store_Property_On_Controls_PropertyCollection()
        {
            _sut.ApplyControlsProperty("Name", "Controls");
            Assert.AreEqual("Controls", _sut.GetControlsProperty("Name"));
        }

        [Test]
        public void With_Should_Add_InterActiveRibbonElement_And_Set_Parent()
        {
            var actual = new Button("MyButton");
            _sut.With(() => actual);
            Assert.AreEqual(_sut,actual.Parent);
            Assert.AreEqual(1,_sut._innerControls.Count);
        }

        [Test]
        public void ApplyControlsProperties_Should_Store_Multiple_Properties_On_Controls_PropertyCollection()
        {
            _sut.ApplyControlsProperties(new Dictionary<string, string>{{"Name","My Controls"},{"Visible","True"}});
            Assert.AreEqual("My Controls",_sut.GetControlsProperty("Name"));
            Assert.AreEqual("True",_sut.GetControlsProperty("Visible"));
        }

        [Test]
        public void ApplyControlsProperties_Should_Override_Existing_Properties_On_Controls_PropertyCollection()
        {   
            _sut.ApplyControlsProperties(new Dictionary<string, string> { { "Name", "My Controls" }, { "Visible", "True" } });
            _sut.ApplyControlsProperties(new Dictionary<string, string> { { "Name", "My new Controls" }});
            Assert.AreEqual("My new Controls", _sut.GetControlsProperty("Name"));
        }

        [Test]
        public void GetControlsProperty_Should_Return_Controls_PropertyValue()
        {
            _sut.ApplyControlsProperty("Name", "Controls");
            Assert.AreEqual("Controls", _sut.GetControlsProperty("Name"));
        }

        [Test]
        public void ChildItemCount_Should_Return_Correct_InterActiveRibbonElement_Count()
        {
            var iae1 = new Button("MyButton");
            var iae2 = new Button("MyButton2");
            var iae3 = new TextBox("TextBox1");
            _sut.With(() => iae1).With(() => iae2).With(() => iae3);
            Assert.AreEqual(3,_sut.ChildItemCount);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            _sut.Set(GroupProperty.Title, "My Group");
            Assert.AreEqual("My Group", _sut.Get(GroupProperty.Title));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            _sut.Set(new Dictionary<GroupProperty, string>()
                                  {
                                      {GroupProperty.Description, "My Group Description"},
                                      {GroupProperty.Title, "My Group"}
                                  });
            Assert.AreEqual("My Group Description", _sut.Get(GroupProperty.Description));
            Assert.AreEqual("My Group", _sut.Get(GroupProperty.Title));
        }
    }
}