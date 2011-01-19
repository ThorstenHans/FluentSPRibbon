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
            var button1 = xmlDocument.SelectNodes(xpathForButton1);
            Assert.IsNotNull(button1);
            Console.Write(actual);
        }
        
    }
}