using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class GroupTemplate_Tests
    {
        private GroupTemplate _sut;

        [SetUp]
        public void Setup()
        {
            _sut = GroupTemplate.Create("MyGroupTemplate");
        }

        [Test]
        public void Passed_Parameter_Should_Be_Stored_In_OriginalId()
        {
            var expected = "MyGroupTemplate";
            Assert.AreEqual(expected,_sut.OriginalId);
        }

        [Test]
        public void Set_Should_Store_Value()
        {
            _sut.Set(GroupTemplateProperty.ClassName, "My GroupTemplateClassName");
            Assert.AreEqual("My GroupTemplateClassName", _sut.Get(GroupTemplateProperty.ClassName));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            _sut.Set(new Dictionary<GroupTemplateProperty, string>()
                                  {
                                      {GroupTemplateProperty.ClassName, "My GroupTemplateClassName"}
                                  });
            Assert.AreEqual("My GroupTemplateClassName", _sut.Get(GroupTemplateProperty.ClassName));
        }

        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<GroupTemplate>(_sut);
            Assert.AreEqual("MyGroupTemplate",_sut.Id);
        }

        [Test]
        public void With_Should_Add_New_Layout_And_Set_Parent_Reference()
        {
            var expected = Layout.Create("MyLayout", "MyTitle");
            _sut.With(() => expected);
            Assert.IsNotNull(_sut._layouts);
            Assert.AreEqual(1,_sut._layouts.Count);
            Assert.AreEqual(_sut,expected.Parent);
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            Assert.IsTrue(_sut.IsIdProvider);
        }
    }
}