using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class GroupTemplate_Tests
    {
        [Test]
        public void If_Default_Constructor_Is_Called_DefaultValue_Should_Be_Stored_In_OriginalId()
        {
            // Arrange
            var sut = new GroupTemplate();
            // Assert
            Assert.AreEqual("NotSet",sut.OriginalId);
        }

        [Test]
        public void Passed_Parameter_Should_Be_Stored_In_OriginalId()
        {
            // Arrange
            var expected = "MyGroupTemplate";
            var sut = new GroupTemplate(expected);
            // Assert
            Assert.AreEqual(expected,sut.OriginalId);
        }

        public void Set_Should_Store_Value()
        {
            var sut = new GroupTemplate("MyGroupTemplate");
            sut.Set(GroupTemplateProperty.ClassName, "My GroupTemplateClassName");

            Assert.AreEqual("My GroupTemplateClassName", sut.Get(GroupTemplateProperty.ClassName));
        }

        [Test]
        public void Set_Should_Store_MultipleValues()
        {
            var sut = new GroupTemplate("MyGroupTemplate");
            sut.Set(new Dictionary<GroupTemplateProperty, string>()
                                  {
                                      {GroupTemplateProperty.ClassName, "My GroupTemplateClassName"}
                                  });
            Assert.AreEqual("My GroupTemplateClassName", sut.Get(GroupTemplateProperty.ClassName));
        }

        [Test]
        public void Create_Should_Create_A_New_Instance()
        {
            // Arrange
            var sut = Create<GroupTemplate>.Instance("MyGroupTemplate");
            // Assert
            Assert.IsNotNull(sut);
            Assert.IsInstanceOf<GroupTemplate>(sut);
            Assert.AreEqual("MyGroupTemplate",sut.Id);
        }

        [Test]
        public void With_Should_Add_New_Layout_And_Set_Parent_Reference()
        {
            // Arrange
            var sut = new GroupTemplate("MyGroupTemplate");
            var expected = Create<Layout>.Instance("MyLayout");
            // Act
            sut.With(() => expected);

            // Assert
            Assert.IsNotNull(sut._layouts);
            Assert.AreEqual(1,sut._layouts.Count);
            Assert.AreEqual(sut,expected.Parent);
        }

        [Test]
        public void IsIdProvider_Should_Be_True()
        {
            // Arrange
            var sut = new GroupTemplate("MyGroupTemplate");
            // Assert
            Assert.IsTrue(sut.IsIdProvider);
        }
    }
}