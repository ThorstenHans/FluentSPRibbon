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
            using (var stream = new MemoryStream())
            {

                XmlSerializer serializer = new XmlSerializer(typeof (Ribbon));

                var ribbon = Create<Ribbon>.Instance("FluentRibbon")
                    .SetPropertyTo("Name", ".NET Rocks Fluent SPRibbon API")
                    .With(() => Create<Tab>.Instance("FluentRibbonTab1")
                                    .SetPropertyTo("Title", "Hello World Tab!")
                                    .SetPropertyTo("Sequence", "1001")
                                    .SetPropertyTo("Description", "see http://www.dotnet-rocks.de")
                                    .With(() => Create<Group>.Instance("ActionsGroup")
                                                    .SetPropertyTo("Title", "My Actions")
                                                    .SetPropertyTo("Sequence", "10")
                                                    .SetPropertyTo("Description", "These are my actions")
                                                    .With(()=>Create<Button>.Instance("MyButton1")
                                                    .SetPropertyTo("LabelText","Click me!")))
                                    .With(() => Create<Group>.Instance("WorkflowActions")
                                                    .SetPropertyTo("Title", "My Workflow Actions")
                                                    .SetPropertyTo("Sequence", "20")
                                                    .SetPropertyTo("Description",
                                                                   "Master your Workflows by using Ribbon Elements")
                                                                   .With(()=>Create<Button>.Instance("Button2").SetPropertyTo("LabelText","OrClickMe!")))
                                    .With(() => Create<Group>.Instance("ViewSettingsGroup")
                                                    .SetPropertyTo("Title", "Customize your view")
                                                    .SetPropertyTo("Sequence", "30")
                                                    .SetPropertyTo("Description",
                                                                   "Customize the current view for your needs")))
                    .With(() => Create<Tab>.Instance("FluentRibbonTab2")
                                    .SetPropertyTo("Title", "FluentRibbon rocks")
                                    .SetPropertyTo("Sequence", "1002")
                                    .SetPropertyTo("Description", ".NET Rocks Fluent SPRibbon API"));

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
                    .SetPropertyTo("Name", ".NET Rocks Fluent SPRibbon API")
                    .With(() => Create<Tab>.Instance("FluentRibbonTab1")
                                    .SetPropertyTo("Title", "Tab1Title")
                                    .SetPropertyTo("Sequence", "1001")
                                    .SetPropertyTo("Description", "see http://www.dotnet-rocks.de")
                                    .With(() => Create<Group>.Instance("ActionsGroup")
                                                    .SetPropertyTo("Title", "Group1Title")
                                                    .SetPropertyTo("Sequence", "10")
                                                    .SetPropertyTo("Description", "These are my actions")
                                                    .With(() => Create<Button>.Instance("MyButton1")
                                                    .SetPropertyTo("LabelText", "Click me!")))
                                    .With(() => Create<Group>.Instance("WorkflowActions")
                                                    .SetPropertyTo("Title", "Group2Title")
                                                    .SetPropertyTo("Sequence", "20")
                                                    .SetPropertyTo("Description",
                                                                   "Master your Workflows by using Ribbon Elements")
                                                                   .With(() => Create<Button>.Instance("Button2").SetPropertyTo("LabelText", "OrClickMe!")))
                                    .With(() => Create<Group>.Instance("ViewSettingsGroup")
                                                    .SetPropertyTo("Title", "Group3Title")
                                                    .SetPropertyTo("Sequence", "30")
                                                    .SetPropertyTo("Description",
                                                                   "Customize the current view for your needs")))
                    .With(() => Create<Tab>.Instance("FluentRibbonTab2")
                                    .SetPropertyTo("Title", "Tab2Title")
                                    .SetPropertyTo("Sequence", "1002")
                                    .SetPropertyTo("Description", ".NET Rocks Fluent SPRibbon API"));

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
            using (var stream = new MemoryStream())
            {
                RibbonSettings.ResourceFileIdentifier = "MyResourceFile";
                RibbonSettings.ImagesFolder = "/_layouts/FluentSPRibbon/Images/";
                XmlSerializer serializer = new XmlSerializer(typeof(Ribbon));

                var ribbon = Create<Ribbon>.Instance("FluentRibbon")
                    .SetPropertyTo("Name", ".NET Rocks Fluent SPRibbon API")
                    .With(() => Create<Tab>.Instance("FluentRibbonTab1")
                                    .SetPropertyTo("Title", "Tab1Title")
                                    .SetPropertyTo("Sequence", "1001")
                                    .SetPropertyTo("Description", "see http://www.dotnet-rocks.de")
                                    .With(() => Create<Group>.Instance("ActionsGroup")
                                                    .SetPropertyTo("Title", "Group1Title")
                                                    .SetPropertyTo("Sequence", "10")
                                                    .SetPropertyTo("Description", "These are my actions")
                                                    .With(() => Create<Button>.Instance("MyButton1")
                                                    .SetPropertyTo("Image32by32", "CoolIcon.png")
                                                    .SetPropertyTo("LabelText", "Click me!")))
                                    .With(() => Create<Group>.Instance("WorkflowActions")
                                                    .SetPropertyTo("Title", "Group2Title")
                                                    .SetPropertyTo("Sequence", "20")
                                                    .SetPropertyTo("Description",
                                                                   "Master your Workflows by using Ribbon Elements")
                                                                   .With(() => Create<Button>.Instance("Button2").SetPropertyTo("LabelText", "OrClickMe!")))
                                    .With(() => Create<Group>.Instance("ViewSettingsGroup")
                                                    .SetPropertyTo("Title", "Group3Title")
                                                    .SetPropertyTo("Sequence", "30")
                                                    .SetPropertyTo("Description",
                                                                   "Customize the current view for your needs")))
                    .With(() => Create<Tab>.Instance("FluentRibbonTab2")
                                    .SetPropertyTo("Title", "Tab2Title")
                                    .SetPropertyTo("Sequence", "1002")
                                    .SetPropertyTo("Description", ".NET Rocks Fluent SPRibbon API"));

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

        }

        [Test]
        public void ImagePath_Should_Contain_A_Composite_Url()
        {
            // Arrange
            String actual = String.Empty;
            using (var stream = new MemoryStream())
            {
                RibbonSettings.ImagesFolder = "/_layouts/FluentSPRibbon/Images/";
                XmlSerializer serializer = new XmlSerializer(typeof(Ribbon));

                var ribbon = Create<Ribbon>.Instance("FluentRibbon")
                     .SetPropertyTo("Name", ".NET Rocks Fluent SPRibbon API")
                     .With(() => Create<Tab>.Instance("FluentRibbonTab1")
                                     .SetPropertyTo("Title", "Hello World Tab!")
                                     .SetPropertyTo("Sequence", "1001")
                                     .SetPropertyTo("Description", "see http://www.dotnet-rocks.de")
                                     .With(() => Create<Group>.Instance("ActionsGroup")
                                                     .SetPropertyTo("Title", "My Actions")
                                                     .SetPropertyTo("Sequence", "10")
                                                     .SetPropertyTo("Description", "These are my actions")
                                                     .With(() => Create<Button>.Instance("MyButton1")
                                                     .SetPropertyTo("LabelText", "Click me!")
                                                     .SetPropertyTo("Image32by32","CoolIcon.png"))));

                // Act
                serializer.Serialize(stream, ribbon);
                using (var reader = new StreamReader(stream))
                {
                    stream.Position = 0;
                    actual = reader.ReadToEnd();
                }
            }
        
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
    }
}