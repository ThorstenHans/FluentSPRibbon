using System;
using System.Collections.Generic;
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
        public void Api_Should_Be_Able_To_Add_All_Common_RibbonElements()
        {
            var button = Button.Create("Button1");
            var checkBox = CheckBox.Create("CheckBox1");
            var colorPicker = ColorPicker.Create("ColorPicker1")
                .With(()=>Color.Create("Red")
                          .Set(new Dictionary<ColorProperty, string>
                                   {{ColorProperty.Title, "Red"},{ColorProperty.Color, "red"},{ColorProperty.Sequence, "1"}})
                )
                .With(() => Color.Create("Brown")
                          .Set(new Dictionary<ColorProperty, string> { { ColorProperty.Title, "Brown" }, { ColorProperty.Color, "Brown" }, { ColorProperty.Sequence, "2" } })
                )
                .With(() => Color.Create("Black")
                          .Set(new Dictionary<ColorProperty, string> { { ColorProperty.Title, "Black" }, { ColorProperty.Color, "Black" }, { ColorProperty.Sequence, "3" } })
                )
                .With(() => Color.Create("Green")
                          .Set(new Dictionary<ColorProperty, string> { { ColorProperty.Title, "Green" }, { ColorProperty.Color, "Green" }, { ColorProperty.Sequence, "4" } })
                )
                .With(() => Color.Create("Orange")
                          .Set(new Dictionary<ColorProperty, string> { { ColorProperty.Title, "Orange" }, { ColorProperty.Color, "Orange" }, { ColorProperty.Sequence, "5" } })
                )
                .With(() => Color.Create("Blue")
                          .Set(new Dictionary<ColorProperty, string>
                                   {{ColorProperty.Title, "Blue"},{ColorProperty.Color, "Blue"}, {ColorProperty.Sequence, "6"}})
                );
            var button2 = Button.Create("MyButton2")
                .Set(ButtonProperty.LabelText, "MyButton2LabelText");
            var comboBox = ComboBox.Create("ComboBox1")
                .With(()=>Menu.Create("ComboBoxMenu1")
                    .With(()=>MenuSection.Create("MenuSection1")
                    .With(()=> colorPicker)
                    .With(()=> button2)));
            var dropDown = DropDown.Create("DropDown1");
            var flyoutAnchor = FlyoutAnchor.Create("FlyoutAnchor1");
            var galleryButton = GalleryButton.Create("GalleryButton1",ElementDimension.Size16by16);
            var label = Label.Create("Label1").Set(LabelProperty.LabelText,"Sample LabelText").Set(LabelProperty.Sequence,"50");
            var mruSplitButton = MRUSplitButton.Create("MRUSplitButton1");
            var spinner = Spinner.Create("Spinner1");
            var splitButton = SplitButton.Create("SplitButton");
            var textBox = TextBox.Create("TextBox1").Set(TextBoxProperty.Width,"200px").Set(TextBoxProperty.ToolTipTitle,"TextBox ToolTips are cool");
            var toggleButton = ToggleButton.Create("ToggleButton1");
            var firstGroup = Group.Create("1stGroup").Set(GroupProperty.Title,"Item Actions");
            var secondGroup = Group.Create("2ndGroup").Set(GroupProperty.Title,"View Actions");
            var firstTab = Tab.Create("1stTab").Set(TabProperty.Title,"My LineOfBusiness Application Tab");
            var secondTab = Tab.Create("2ndTab").Set(TabProperty.Title, "My Information Tab");

            var ribbon = Ribbon.Create("DotNetRocksRibbon")
                .With(() => firstTab.
                    With(()=> secondGroup
                    .With(()=>button).With(()=>comboBox).With(()=>flyoutAnchor).With(()=> label)
                    .With(()=> spinner).With(()=> toggleButton)))
                .With(() => secondTab.
                    With(()=>firstGroup
                        .With(()=>checkBox).With(()=>dropDown).With(()=>galleryButton).With(()=>mruSplitButton)
                        .With(()=>splitButton).With(()=>textBox)));

            var actual = ribbon.ToXml();
            Assert.IsNotNull(actual);
            Console.WriteLine(actual);
        }
        [Test]
        public void Properties_Should_Be_Written_To_Xml()
        {
            String actual = String.Empty;
            RibbonSettings.ImagesFolder = "/_images/RibbonImages/";
            RibbonSettings.ResourceFileIdentifier = "MyResources";

                var ribbon = Ribbon.Create("FluentRibbon")
                    .Set(RibbonProperty.ToolTipFooterText, ".NET Rocks Fluent SPRibbon API")
                    .With(() => Tab.Create("FluentRibbonTab1")
                                    .Set(TabProperty.Title, "Hello World Tab!")
                                    .Set(TabProperty.Sequence, "1001")
                                    .Set(TabProperty.Description, "see http://www.dotnet-rocks.de")
                                    .With(() => Group.Create("ActionsGroup")
                                                    .Set(GroupProperty.Title, "$Resources: MyResourceFile, Key")
                                                    .Set(GroupProperty.Sequence, "10")
                                                    .Set(GroupProperty.Description, "These are my actions")
                                                    .With(()=>Button.Create("MyButton1")
                                                    .Set(ButtonProperty.LabelText,"Click me!")))
                                    .With(() => Group.Create("WorkflowActions")
                                                    .Set(GroupProperty.Title, "My Workflow Actions")
                                                    .Set(GroupProperty.Sequence, "20")
                                                    .Set(GroupProperty.Description,
                                                                   "Master your Workflows by using Ribbon Elements")
                                                                   .With(()=>Button.Create("Button2")
                                                                       .Set(ButtonProperty.TemplateAlias,"1"))
                                                                       )
                                    .With(() => Group.Create("ViewSettingsGroup")
                                                    .Set(GroupProperty.Title, "Customize your view")
                                                    .Set(GroupProperty.Sequence, "30")
                                                    .Set(GroupProperty.Description,
                                                                   "Customize the current view for your needs")))
                    .With(() => Tab.Create("FluentRibbonTab2")
                                    .Set(TabProperty.Title, "FluentRibbon rocks")
                                    .Set(TabProperty.Sequence, "1002")
                                    .Set(TabProperty.Description, ".NET Rocks Fluent SPRibbon API"));

            actual = ribbon.ToXml();
            
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(actual);

            string xpathForButton1 =
                "/Ribbon/Tabs/Tab[@Id='FluentRibbon.FluentRibbonTab1']/Groups/Group[@Id='FluentRibbon.FluentRibbonTab1.ActionsGroup']/Controls/Button[@Id='FluentRibbon.FluentRibbonTab1.ActionsGroup.MyButton1']";
            var button1 = xmlDocument.SelectSingleNode(xpathForButton1);
            Assert.IsNotNull(button1);
            Console.Write(actual);
        }

        [Test]
        public void Titles_Should_Be_Localized()
        {
            String actual = String.Empty;
            using (var stream = new MemoryStream())
            {
                RibbonSettings.ResourceFileIdentifier = "MyResourceFile";
                XmlSerializer serializer = new XmlSerializer(typeof(Ribbon));
                var button = Button.Create("MyButton").Set(ButtonProperty.Sequence, "12");
                var ribbon = Ribbon.Create("FluentRibbon")
                    .Set(RibbonProperty.ToolTipFooterText, ".NET Rocks Fluent SPRibbon API")
                    .With(() => Tab.Create("FluentRibbonTab1")
                                    .Set(TabProperty.Title, "Tab1Title")
                                    .Set(TabProperty.Sequence, "1001")
                                    .Set(TabProperty.Description, "see http://www.dotnet-rocks.de")
                                    .With(() => Group.Create("ActionsGroup")
                                                    .Set(GroupProperty.Title, "Group1Title")
                                                    .Set(GroupProperty.Sequence, "10")
                                                    .Set(GroupProperty.Description, "These are my actions")
                                                    .With(() => Button.Create("MyButton1")
                                                    .Set(ButtonProperty.LabelText, "Click me!")))
                                    .With(() => Group.Create("WorkflowActions")
                                                    .Set(GroupProperty.Title, "Group2Title")
                                                    .Set(GroupProperty.Sequence, "20")
                                                    .Set(GroupProperty.Description,
                                                                   "Master your Workflows by using Ribbon Elements")
                                                                   .With(() => Button.Create("Button2").Set(ButtonProperty.LabelText, "OrClickMe!")))
                                    .With(() => Group.Create("ViewSettingsGroup")
                                                    .Set(GroupProperty.Title, "Group3Title")
                                                    .Set(GroupProperty.Sequence, "30")
                                                    .Set(GroupProperty.Description,
                                                                   "Customize the current view for your needs")))
                    .With(() => Tab.Create("FluentRibbonTab2")
                                    .Set(TabProperty.Title, "Tab2Title")
                                    .Set(TabProperty.Sequence, "1002")
                                    .Set(TabProperty.Description, ".NET Rocks Fluent SPRibbon API"));

                serializer.Serialize(stream, ribbon);
                using (var reader = new StreamReader(stream))
                {
                    stream.Position = 0;
                    actual = reader.ReadToEnd();
                }
            }
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(actual);
            var xPathForTab1= "/Ribbon/Tabs/Tab[@Id='FluentRibbon.FluentRibbonTab1']";
            var xPathForTab2 = "/Ribbon/Tabs/Tab[@Id='FluentRibbon.FluentRibbonTab2']";
            var xPathForGroup1 = "/Ribbon/Tabs/Tab[@Id='FluentRibbon.FluentRibbonTab1']/Groups/Group[@Id='FluentRibbon.FluentRibbonTab1.ActionsGroup']";
            var xPathForGroup2 = "/Ribbon/Tabs/Tab[@Id='FluentRibbon.FluentRibbonTab1']/Groups/Group[@Id='FluentRibbon.FluentRibbonTab1.WorkflowActions']";
            var xPathForGroup3 = "/Ribbon/Tabs/Tab[@Id='FluentRibbon.FluentRibbonTab1']/Groups/Group[@Id='FluentRibbon.FluentRibbonTab1.ViewSettingsGroup']";

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
            Console.WriteLine(actual);
        }

        [Test]
        public void Titles_Should_Be_Localized_And_Image_Urls_Should_be_composed()
        {
            String actual = String.Empty;
                RibbonSettings.ResourceFileIdentifier = "MyResourceFile";
                RibbonSettings.ImagesFolder = "/_layouts/FluentSPRibbon/Images/";

            var ribbon = Ribbon.Create("FluentRibbon")
                    .Set(RibbonProperty.ToolTipFooterText, ".NET Rocks Fluent SPRibbon API")
                    .With(() => Tab.Create("FluentRibbonTab1")
                                    .Set(TabProperty.Title, "Tab1Title")
                                    .Set(TabProperty.Sequence, "1001")
                                    .Set(TabProperty.Description, "see http://www.dotnet-rocks.de")
                                    .With(() => Group.Create("ActionsGroup")
                                                    .Set(GroupProperty.Title, "Group1Title")
                                                    .Set(GroupProperty.Sequence, "10")
                                                    .Set(GroupProperty.Description, "These are my actions")
                                                    .With(() => Button.Create("MyButton1")
                                                    .Set(ButtonProperty.Image32by32, "CoolIcon.png")
                                                    .Set(ButtonProperty.LabelText, "Click me!")))
                                    .With(() => Group.Create("WorkflowActions")
                                                    .Set(GroupProperty.Title, "Group2Title")
                                                    .Set(GroupProperty.Sequence, "20")
                                                    .Set(GroupProperty.Description,
                                                                   "Master your Workflows by using Ribbon Elements")
                                                                   .With(() => Button.Create("Button2").Set(ButtonProperty.LabelText, "OrClickMe!")))
                                    .With(() => Group.Create("ViewSettingsGroup")
                                                    .Set(GroupProperty.Title, "Group3Title")
                                                    .Set(GroupProperty.Sequence, "30")
                                                    .Set(GroupProperty.Description,
                                                                   "Customize the current view for your needs")))
                    .With(() => Tab.Create("FluentRibbonTab2")
                                    .Set(TabProperty.Title, "Tab2Title")
                                    .Set(TabProperty.Sequence, "1002")
                                    .Set(TabProperty.Description, ".NET Rocks Fluent SPRibbon API"));

            actual = ribbon.ToXml();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(actual);

            var xPathForTab1 = "/Ribbon/Tabs/Tab[@Id='FluentRibbon.FluentRibbonTab1']";
            var xPathForTab2 = "/Ribbon/Tabs/Tab[@Id='FluentRibbon.FluentRibbonTab2']";
            var xPathForGroup1 = "/Ribbon/Tabs/Tab[@Id='FluentRibbon.FluentRibbonTab1']/Groups/Group[@Id='FluentRibbon.FluentRibbonTab1.ActionsGroup']";
            var xPathForGroup2 = "/Ribbon/Tabs/Tab[@Id='FluentRibbon.FluentRibbonTab1']/Groups/Group[@Id='FluentRibbon.FluentRibbonTab1.WorkflowActions']";
            var xPathForGroup3 = "/Ribbon/Tabs/Tab[@Id='FluentRibbon.FluentRibbonTab1']/Groups/Group[@Id='FluentRibbon.FluentRibbonTab1.ViewSettingsGroup']";
            var xpathForButton1 = "/Ribbon/Tabs/Tab[@Id='FluentRibbon.FluentRibbonTab1']/Groups/Group[@Id='FluentRibbon.FluentRibbonTab1.ActionsGroup']/Controls/Button[@Id='FluentRibbon.FluentRibbonTab1.ActionsGroup.MyButton1']";
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
            String actual = String.Empty;
            RibbonSettings.ImagesFolder = "/_layouts/FluentSPRibbon/Images/";

                var ribbon = Ribbon.Create("FluentRibbon")
                     .Set(RibbonProperty.ToolTipFooterText, ".NET Rocks Fluent SPRibbon API")
                     .With(() => Tab.Create("FluentRibbonTab1")
                                     .Set(TabProperty.Title, "Hello World Tab!")
                                     .Set(TabProperty.Sequence, "1001")
                                     .Set(TabProperty.Description, "see http://www.dotnet-rocks.de")
                                     .With(() => Group.Create("ActionsGroup")
                                                     .Set(GroupProperty.Title, "My Actions")
                                                     .Set(GroupProperty.Sequence, "10")
                                                     .Set(GroupProperty.Description, "These are my actions")
                                                     .With(() => Button.Create("MyButton1")
                                                     .Set(ButtonProperty.LabelText, "Click me!")
                                                     .Set(ButtonProperty.Image32by32,"CoolIcon.png"))));

            actual = ribbon.ToXml();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(actual);
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
            var ribbon = Ribbon.Create("FluentRibbon")
                .Set(RibbonProperty.ToolTipFooterText, "RibbonToolTipFooter")
                .With(() => Tab.Create("FluentRibbonTab1")
                                .Set(TabProperty.Title, "Tab1Title")
                                .Set(TabProperty.Sequence, "1001")
                                .Set(TabProperty.Description, "Tab1Description")
                                .With(() => Group.Create("ActionsGroup")
                                                .Set(GroupProperty.Title, "Group1Title")
                                                .Set(GroupProperty.Sequence, "10")
                                                .Set(GroupProperty.Description, "Group1Description")
                                                .With(() => Button.Create("MyButton1")
                                                .Set(ButtonProperty.Image32by32, "CoolIcon.png")
                                                .Set(ButtonProperty.LabelText, "MyButton1LabelText")))
                                .With(() => Group.Create("WorkflowActions")
                                                .Set(GroupProperty.Title, "Group2Title")
                                                .Set(GroupProperty.Sequence, "20")
                                                .Set(GroupProperty.Description,
                                                               "Group2Description")
                                                               .With(() => Button.Create("Button2")
                                                                   .Set(ButtonProperty.LabelText, "Button2LabelText")))
                                .With(() => Group.Create("ViewSettingsGroup")
                                                .Set(GroupProperty.Title, "Group3Title")
                                                .Set(GroupProperty.Sequence, "30")
                                                .Set(GroupProperty.Description,
                                                               "Group3Description")))
                .With(() => Tab.Create("FluentRibbonTab2")
                                .Set(TabProperty.Title, "Tab2Title")
                                .Set(TabProperty.Sequence, "1002")
                                .Set(TabProperty.Description, "Tab2Description")
                                .With(() => Group.Create("Group4711")
                                    .Set(GroupProperty.Title, "Group4711Title")
                                    .With(() => TextBox.Create("MyTextBox")
                                        .Set(new Dictionary<TextBoxProperty, String>()
                                                           {
                                                               { TextBoxProperty.ShowAsLabel,"TRUE"},
                                                               { TextBoxProperty.Width,"100px"}
                                                           }
                                                        ))));
            Assert.IsNotNullOrEmpty(ribbon.ToXml());
        }
    }
}