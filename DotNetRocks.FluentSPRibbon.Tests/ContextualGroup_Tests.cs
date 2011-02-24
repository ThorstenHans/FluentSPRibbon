using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class ContextualGroup_Tests
    {
        private ContextualGroup _sut;

        [SetUp]
        public void Setup()
        {
            _sut = ContextualGroup.Create("MyContextualTab");
        }

        [Test]
        public void Create_Should_Be_Able_To_Create_A_New_Instance()
        {
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOf<ContextualGroup>(_sut);
        }

        [Test]
        public void Set_Should_Store_Property_On_Current_Instance()
        {
            _sut.Set(ContextualGroupProperty.Color, "DarkBlue");
            Assert.AreEqual("DarkBlue", _sut.Get(ContextualGroupProperty.Color));
        }

        [Test]
        public void Get_Should_Return_String_Empty_If_Property_Doesnt_Exist()
        {
            var actual = _sut.Get(ContextualGroupProperty.Color);
            Assert.IsEmpty(actual);
        }

        [Test]
        public void Set_Should_Store_Multiple_Properties_On_Current_Instance()
        {
            var expectedColor = "DarkBlue";
            var expectedCommand = "myCommand();";
            _sut.Set(new Dictionary<ContextualGroupProperty, string>()
                        {
                            {ContextualGroupProperty.Color, expectedColor},
                            {ContextualGroupProperty.Command, expectedCommand}
                        });
            Assert.AreEqual(expectedColor,_sut.Get(ContextualGroupProperty.Color));
            Assert.AreEqual(expectedCommand,_sut.Get(ContextualGroupProperty.Command));
        }


        [Test]
        public void Set_Overwrite_Existing_Property_Value_On_Current_Instance()
        {
        _sut.Set(ContextualGroupProperty.Color, "DarkBlue");
        _sut.Set(ContextualGroupProperty.Color, "DarkRed");
        Assert.AreEqual("DarkRed", _sut.Get(ContextualGroupProperty.Color));
    }

        [Test]
        public void Ribbon_Should_Be_Able_To_Store_Multiple_Contextual_Groups()
        {
            var ribbon = new Ribbon("MyRibbon");
            ribbon.With(() => _sut);
            ribbon.With(() => ContextualGroup.Create("2nd"));
            Assert.AreEqual(2,ribbon._contextualGroups.Count);
        }

        [Test]
        public void ContextualGroup_Should_Be_Able_To_Store_Multiple_Tabs()
        {
            _sut.With(() => Tab.Create("Tab"));
            _sut.With(() => Tab.Create("Tab2"));
            Assert.AreEqual(2,_sut._tabs.Count);
        }

    }


}