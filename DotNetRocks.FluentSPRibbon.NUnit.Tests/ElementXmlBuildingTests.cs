namespace DotNetRocks.FluentSPRibbon.NUnit.Tests
{
    [RibbonExtensions]
    public class ElementXmlBuildingTests
    {

        [RibbonCustomization]
        public void WriteTo_Should_Replace_The_Content_Of_The_Elements_Node()
        {
            RibbonSettings.ImagesFolder = "/_layouts/images/FluentSPRibbon";

            Button.Create("myButton")
                .Set(ButtonProperty.LabelText,"Click me")
                .Set(ButtonProperty.Image32by32, "MyButton32.png")
                .WriteTo("Elements.xml");
        }
        
    }
}