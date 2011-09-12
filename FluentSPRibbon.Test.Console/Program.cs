using System.Collections.Generic;
using System.IO;
using DotNetRocks.FluentSPRibbon;

namespace FluentSPRibbon.Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            RibbonSettings.ImagesFolder = "~/_images/DotNetRocks_Sample/";
            RibbonSettings.ResourceFileIdentifier = "DotNetRocks.Core.Resources";

           var myRibbon =  Ribbon.Create("DotNetRocks.Ribbon")
                .With(() => Tab.Create("FirstTab")
                    .Set(TabProperty.Title, "Tab1_Title")
                    .Set(new Dictionary<TabProperty, string>(){
                        {TabProperty.Description, "Tab1_Description"},
                        {TabProperty.Sequence, "100"},
                        {TabProperty.CssClass, "DotNetRocksTab"}
                    })
                    .With(()=> Group.Create("FirstGroup")
                        .Set(GroupProperty.Title,"Group1_Title")
                        .With(()=> TextBox.Create("NameTextBox")
                            .Set(TextBoxProperty.Width, "200"))
                            .With(()=>Button.Create("ButtonSayHello")
                            .Set(new Dictionary<ButtonProperty, string>()
                                     {
                                         {ButtonProperty.LabelText, "Say Hello"},
                                         {ButtonProperty.Command ,"SayHelloCommand"},
                                         {ButtonProperty.Sequence, "200"}
                                     })))
                    .With(()=> Group.Create("SecondGroup")
                        .With(()=> ToggleButton.Create("MyToggle")
                            .Set(new Dictionary<ToggleButtonProperty, string>()
                                     {
                                         {ToggleButtonProperty.Image16by16, "Toggle16.png"},
                                         {ToggleButtonProperty.Image32by32, "Toggle32.png"},
                                         {ToggleButtonProperty.LabelText, "Sample Toggle Button"},
                                         {ToggleButtonProperty.Command, "ToggleClicked"}

                                     })))
                );

            File.WriteAllText("..\\..\\Output.xml", myRibbon.ToXml());

            System.Console.ReadLine();
        }
    }
}
