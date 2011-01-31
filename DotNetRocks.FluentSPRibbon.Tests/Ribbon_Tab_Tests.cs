using System;
using System.Xml;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Ribbon_Tab_Tests
    {

        [Test]
        public void Tab_Should_Store_Multiple_Groups()
        {
            // Act
            var tab = Create<Tab>.Instance("MyTab")
                .With(() => Create<Group>.Instance("Grp1")
                                .Set(GroupProperty.Description, "Group 1"))
                .With(()=>Create<Group>.Instance("Grp2"));
            // Assert
            Assert.AreEqual(2,tab.ChildItemCount);
        }
        
        [Test]
        public void A_New_Tab_Should_Always_Be_Empty()
        {
            var sut = Create<Ribbon>.Instance("MyRibbon")
                .With(()=>Create<Tab>.Instance("MyTab"));

            Assert.IsNotNull(sut);
            Assert.IsNotNull(sut["MyTab"]);
            Assert.AreEqual(0,sut["MyTab"].ChildItemCount);
        }

        [Test]
        public void A_Single_Tab_Should_Be_Exported_To_WellFormed_Xml()
        {
            // Act
            var tab = Create<Tab>.Instance("MyTab")
                .With(() => Create<Group>.Instance("Grp1")
                                .Set(GroupProperty.Description, "Group 1"))
                .With(() => Create<Group>.Instance("Grp2"));
            string actual = tab.ToXml();
            
            // Assert
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(actual);

            String selectTabXPath = "/Tab[@Id='MyTab']";
            var tabNode = xmlDocument.SelectSingleNode(selectTabXPath);
            Assert.IsNotNull(tabNode);
            Assert.AreEqual("MyTab", tabNode.Attributes["Id"].Value);
            Console.WriteLine(actual);
        }
    }
}