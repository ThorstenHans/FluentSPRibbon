using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class Xml_Serialization_Tests
    {
        [Test]
        public void Properties_Should_Be_Written_To_Xml()
        {
            // Arrange
            String actual = String.Empty;
                var ribbon = Create<Ribbon>.Instance("FluentRibbon")
                    .ApplyProperty("Name", ".NET Rocks Fluent SPRibbon API")
                    .With(() => Create<Tab>.Instance("FluentRibbonTab1")
                                    .ApplyProperty("Title", "Hello World Tab!")
                                    .ApplyProperty("Sequence", "1001")
                                    .ApplyProperty("Description", "see http://www.dotnet-rocks.de")
                                    .With(() => Create<Group>.Instance("ActionsGroup")
                                                    .ApplyProperty("Title", "My Actions")
                                                    .ApplyProperty("Sequence", "10")
                                                    .ApplyProperty("Description", "These are my actions")
                                                    .With(()=>Create<Button>.Instance("MyButton1")
                                                    .ApplyProperty("LabelText","Click me!")))
                                    .With(() => Create<Group>.Instance("WorkflowActions")
                                                    .ApplyProperty("Title", "My Workflow Actions")
                                                    .ApplyProperty("Sequence", "20")
                                                    .ApplyProperty("Description",
                                                                   "Master your Workflows by using Ribbon Elements")
                                                                   .With(()=>Create<Button>.Instance("Button2").ApplyProperty("LabelText","OrClickMe!")))
                                    .With(() => Create<Group>.Instance("ViewSettingsGroup")
                                                    .ApplyProperty("Title", "Customize your view")
                                                    .ApplyProperty("Sequence", "30")
                                                    .ApplyProperty("Description",
                                                                   "Customize the current view for your needs")))
                    .With(() => Create<Tab>.Instance("FluentRibbonTab2")
                                    .ApplyProperty("Title", "FluentRibbon rocks")
                                    .ApplyProperty("Sequence", "1002")
                                    .ApplyProperty("Description", ".NET Rocks Fluent SPRibbon API"));

            actual = ribbon.ToXml();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(actual);
            // Assert
            string xpathForButton1 =
                "/Ribbon/Tabs/Tab[@Id='FluentRibbon.FluentRibbonTab1']/Groups/Group[@Id='FluentRibbon.FluentRibbonTab1.ActionsGroup']/Controls/Button[@Id='FluentRibbon.FluentRibbonTab1.ActionsGroup.MyButton1']";
            var button1 = xmlDocument.SelectSingleNode(xpathForButton1);
            Assert.IsNotNull(button1);
            Console.Write(actual);
        }

        [Test]
        public void Titles_Should_Be_Localized()
        {
            // Arrange
            String actual = String.Empty;
            using (var stream = new MemoryStream())
            {
                RibbonSettings.ResourceFileIdentifier = "MyResourceFile";
                XmlSerializer serializer = new XmlSerializer(typeof(Ribbon));

                var ribbon = Create<Ribbon>.Instance("FluentRibbon")
                    .ApplyProperty("Name", ".NET Rocks Fluent SPRibbon API")
                    .With(() => Create<Tab>.Instance("FluentRibbonTab1")
                                    .ApplyProperty("Title", "Tab1Title")
                                    .ApplyProperty("Sequence", "1001")
                                    .ApplyProperty("Description", "see http://www.dotnet-rocks.de")
                                    .With(() => Create<Group>.Instance("ActionsGroup")
                                                    .ApplyProperty("Title", "Group1Title")
                                                    .ApplyProperty("Sequence", "10")
                                                    .ApplyProperty("Description", "These are my actions")
                                                    .With(() => Create<Button>.Instance("MyButton1")
                                                    .ApplyProperty("LabelText", "Click me!")))
                                    .With(() => Create<Group>.Instance("WorkflowActions")
                                                    .ApplyProperty("Title", "Group2Title")
                                                    .ApplyProperty("Sequence", "20")
                                                    .ApplyProperty("Description",
                                                                   "Master your Workflows by using Ribbon Elements")
                                                                   .With(() => Create<Button>.Instance("Button2").ApplyProperty("LabelText", "OrClickMe!")))
                                    .With(() => Create<Group>.Instance("ViewSettingsGroup")
                                                    .ApplyProperty("Title", "Group3Title")
                                                    .ApplyProperty("Sequence", "30")
                                                    .ApplyProperty("Description",
                                                                   "Customize the current view for your needs")))
                    .With(() => Create<Tab>.Instance("FluentRibbonTab2")
                                    .ApplyProperty("Title", "Tab2Title")
                                    .ApplyProperty("Sequence", "1002")
                                    .ApplyProperty("Description", ".NET Rocks Fluent SPRibbon API"));

                // Act
                serializer.Serialize(stream, ribbon);
                using (var reader = new StreamReader(stream))
                {
                    stream.Position = 0;
                    actual = reader.ReadToEnd();
                }
            }
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(actual);
            // Assert
            string xPathForTab1= "/Ribbon/Tabs/Tab[@Id='FluentRibbon.FluentRibbonTab1']";
            string xPathForTab2 = "/Ribbon/Tabs/Tab[@Id='FluentRibbon.FluentRibbonTab2']";
            string xPathForGroup1 = "/Ribbon/Tabs/Tab[@Id='FluentRibbon.FluentRibbonTab1']/Groups/Group[@Id='FluentRibbon.FluentRibbonTab1.ActionsGroup']";
            string xPathForGroup2 = "/Ribbon/Tabs/Tab[@Id='FluentRibbon.FluentRibbonTab1']/Groups/Group[@Id='FluentRibbon.FluentRibbonTab1.WorkflowActions']";
            string xPathForGroup3 = "/Ribbon/Tabs/Tab[@Id='FluentRibbon.FluentRibbonTab1']/Groups/Group[@Id='FluentRibbon.FluentRibbonTab1.ViewSettingsGroup']";

            var tab1 = xmlDocument.SelectSingleNode(xPathForTab1);
            var tab2 = xmlDocument.SelectSingleNode(xPathForTab2);
            var group1 = xmlDocument.SelectSingleNode(xPathForGroup1);
            var group2 = xmlDocument.SelectSingleNode(xPathForGroup2);
            var group3 = xmlDocument.SelectSingleNode(xPathForGroup3);

            Assert.IsNotNull(tab1);
            Assert.AreEqual("$Resources:MyResourceFile, Tab1Title",tab1.Attributes["Title"].Value);
            Assert.AreEqual("$Resources:MyResourceFile, Tab2Title", tab2.Attributes["Title"].Value);
            Assert.AreEqual("$Resources:MyResourceFile, Group1Title", group1.Attributes["Title"].Value);
            Assert.AreEqual("$Resources:MyResourceFile, Group2Title", group2.Attributes["Title"].Value);
            Assert.AreEqual("$Resources:MyResourceFile, Group3Title", group3.Attributes["Title"].Value);
           
        }
 


        [Test]
        public void Titles_Should_Be_Localized_And_Image_Urls_Should_be_composed()
        {
            // Arrange
            String actual = String.Empty;
                RibbonSettings.ResourceFileIdentifier = "MyResourceFile";
                RibbonSettings.ImagesFolder = "/_layouts/FluentSPRibbon/Images/";
                

                var ribbon = Create<Ribbon>.Instance("FluentRibbon")
                    .ApplyProperty("Name", ".NET Rocks Fluent SPRibbon API")
                    .With(() => Create<Tab>.Instance("FluentRibbonTab1")
                                    .ApplyProperty("Title", "Tab1Title")
                                    .ApplyProperty("Sequence", "1001")
                                    .ApplyProperty("Description", "see http://www.dotnet-rocks.de")
                                    .With(() => Create<Group>.Instance("ActionsGroup")
                                                    .ApplyProperty("Title", "Group1Title")
                                                    .ApplyProperty("Sequence", "10")
                                                    .ApplyProperty("Description", "These are my actions")
                                                    .With(() => Create<Button>.Instance("MyButton1")
                                                    .ApplyProperty("Image32by32", "CoolIcon.png")
                                                    .ApplyProperty("LabelText", "Click me!")))
                                    .With(() => Create<Group>.Instance("WorkflowActions")
                                                    .ApplyProperty("Title", "Group2Title")
                                                    .ApplyProperty("Sequence", "20")
                                                    .ApplyProperty("Description",
                                                                   "Master your Workflows by using Ribbon Elements")
                                                                   .With(() => Create<Button>.Instance("Button2").ApplyProperty("LabelText", "OrClickMe!")))
                                    .With(() => Create<Group>.Instance("ViewSettingsGroup")
                                                    .ApplyProperty("Title", "Group3Title")
                                                    .ApplyProperty("Sequence", "30")
                                                    .ApplyProperty("Description",
                                                                   "Customize the current view for your needs")))
                    .With(() => Create<Tab>.Instance("FluentRibbonTab2")
                                    .ApplyProperty("Title", "Tab2Title")
                                    .ApplyProperty("Sequence", "1002")
                                    .ApplyProperty("Description", ".NET Rocks Fluent SPRibbon API"));

            actual = ribbon.ToXml();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(actual);
            // Assert
            string xPathForTab1 = "/Ribbon/Tabs/Tab[@Id='FluentRibbon.FluentRibbonTab1']";
            string xPathForTab2 = "/Ribbon/Tabs/Tab[@Id='FluentRibbon.FluentRibbonTab2']";
            string xPathForGroup1 = "/Ribbon/Tabs/Tab[@Id='FluentRibbon.FluentRibbonTab1']/Groups/Group[@Id='FluentRibbon.FluentRibbonTab1.ActionsGroup']";
            string xPathForGroup2 = "/Ribbon/Tabs/Tab[@Id='FluentRibbon.FluentRibbonTab1']/Groups/Group[@Id='FluentRibbon.FluentRibbonTab1.WorkflowActions']";
            string xPathForGroup3 = "/Ribbon/Tabs/Tab[@Id='FluentRibbon.FluentRibbonTab1']/Groups/Group[@Id='FluentRibbon.FluentRibbonTab1.ViewSettingsGroup']";
            string xpathForButton1 = "/Ribbon/Tabs/Tab[@Id='FluentRibbon.FluentRibbonTab1']/Groups/Group[@Id='FluentRibbon.FluentRibbonTab1.ActionsGroup']/Controls/Button[@Id='FluentRibbon.FluentRibbonTab1.ActionsGroup.MyButton1']";

            var tab1 = xmlDocument.SelectSingleNode(xPathForTab1);
            var tab2 = xmlDocument.SelectSingleNode(xPathForTab2);
            var group1 = xmlDocument.SelectSingleNode(xPathForGroup1);
            var group2 = xmlDocument.SelectSingleNode(xPathForGroup2);
            var group3 = xmlDocument.SelectSingleNode(xPathForGroup3);
            var button1 = xmlDocument.SelectSingleNode(xpathForButton1);

            Assert.IsNotNull(button1);
            Assert.IsNotNull(tab1);
            Assert.IsNotNull(tab2);
            Assert.IsNotNull(group1);
            Assert.IsNotNull(group2);
            Assert.IsNotNull(group3);
            Assert.AreEqual("/_layouts/FluentSPRibbon/Images/CoolIcon.png", button1.Attributes["Image32by32"].Value);
            Assert.AreEqual("$Resources:MyResourceFile, Tab1Title", tab1.Attributes["Title"].Value);
            Assert.AreEqual("$Resources:MyResourceFile, Tab2Title", tab2.Attributes["Title"].Value);
            Assert.AreEqual("$Resources:MyResourceFile, Group1Title", group1.Attributes["Title"].Value);
            Assert.AreEqual("$Resources:MyResourceFile, Group2Title", group2.Attributes["Title"].Value);
            Assert.AreEqual("$Resources:MyResourceFile, Group3Title", group3.Attributes["Title"].Value);
            Console.Write(actual);
        }

        [Test]
        public void ImagePath_Should_Contain_A_Composite_Url()
        {
            // Arrange
            String actual = String.Empty;
            RibbonSettings.ImagesFolder = "/_layouts/FluentSPRibbon/Images/";

                var ribbon = Create<Ribbon>.Instance("FluentRibbon")
                     .ApplyProperty("Name", ".NET Rocks Fluent SPRibbon API")
                     .With(() => Create<Tab>.Instance("FluentRibbonTab1")
                                     .ApplyProperty("Title", "Hello World Tab!")
                                     .ApplyProperty("Sequence", "1001")
                                     .ApplyProperty("Description", "see http://www.dotnet-rocks.de")
                                     .With(() => Create<Group>.Instance("ActionsGroup")
                                                     .ApplyProperty("Title", "My Actions")
                                                     .ApplyProperty("Sequence", "10")
                                                     .ApplyProperty("Description", "These are my actions")
                                                     .With(() => Create<Button>.Instance("MyButton1")
                                                     .ApplyProperty("LabelText", "Click me!")
                                                     .ApplyProperty("Image32by32","CoolIcon.png"))));

                // Act
            actual = ribbon.ToXml();
            // Assert
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(actual);
            // Assert
            string xpathForButton1 =
                "/Ribbon/Tabs/Tab[@Id='FluentRibbon.FluentRibbonTab1']/Groups/Group[@Id='FluentRibbon.FluentRibbonTab1.ActionsGroup']/Controls/Button[@Id='FluentRibbon.FluentRibbonTab1.ActionsGroup.MyButton1']";
            var button1 = xmlDocument.SelectSingleNode(xpathForButton1);
            Assert.AreEqual("/_layouts/FluentSPRibbon/Images/CoolIcon.png",button1.Attributes["Image32by32"].Value);
            Console.Write(actual);

        }


        [Test]
        public void Ribbon_Element_Should_Be_Exportable_To_Xml()
        {
            RibbonSettings.ResourceFileIdentifier = "MyResourceFile";
            RibbonSettings.ImagesFolder = "/_layouts/FluentSPRibbon/Images/";
           

            var ribbon = Create<Ribbon>.Instance("FluentRibbon")
                .ApplyProperty("Name", ".NET Rocks Fluent SPRibbon API")
                .With(() => Create<Tab>.Instance("FluentRibbonTab1")
                                .ApplyProperty("Title", "Tab1Title")
                                .ApplyProperty("Sequence", "1001")
                                .ApplyProperty("Description", "see http://www.dotnet-rocks.de")
                                .With(() => Create<Group>.Instance("ActionsGroup")
                                                .ApplyProperty("Title", "Group1Title")
                                                .ApplyProperty("Sequence", "10")
                                                .ApplyProperty("Description", "These are my actions")
                                                .With(() => Create<Button>.Instance("MyButton1")
                                                .ApplyProperty("Image32by32", "CoolIcon.png")
                                                .ApplyProperty("LabelText", "Click me!")))
                                .With(() => Create<Group>.Instance("WorkflowActions")
                                                .ApplyProperty("Title", "Group2Title")
                                                .ApplyProperty("Sequence", "20")
                                                .ApplyProperty("Description",
                                                               "Master your Workflows by using Ribbon Elements")
                                                               .With(() => Create<Button>.Instance("Button2").ApplyProperty("LabelText", "OrClickMe!")))
                                .With(() => Create<Group>.Instance("ViewSettingsGroup")
                                                .ApplyProperty("Title", "Group3Title")
                                                .ApplyProperty("Sequence", "30")
                                                .ApplyProperty("Description",
                                                               "Customize the current view for your needs")))
                .With(() => Create<Tab>.Instance("FluentRibbonTab2")
                                .ApplyProperty("Title", "Tab2Title")
                                .ApplyProperty("Sequence", "1002")
                                .ApplyProperty("Description", ".NET Rocks Fluent SPRibbon API"));

            Assert.IsNotNullOrEmpty(ribbon.ToXml());
        }
    }
}