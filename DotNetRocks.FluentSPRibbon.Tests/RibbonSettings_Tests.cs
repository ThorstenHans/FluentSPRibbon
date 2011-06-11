using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetRocks.FluentSPRibbon.Tests
{
    [TestFixture]
    public class RibbonSettings_Tests
    {
        [SetUp]
        public void SetUpRibbonSettings()
        {
            RibbonSettings.ImagesFolder = String.Empty;
            RibbonSettings.ResourceFileIdentifier = String.Empty;
            RibbonSettings.LocalizeVisualElements = false;
        }

        [Test]
        public void ApplyUrlEncoding_For_Image16by16_Property_ShouldTranslate_Non_Url_Chars()
        {
            var actual =
                RibbonSettings.ApplyUrlEncoding(new KeyValuePair<Enum, string>(ButtonProperty.Image16by16,
                                                                               "My Image.png"));
           
            Assert.That(actual.Value, Is.EqualTo("My%20Image.png"));
        }

        [Test]
        public void It_Should_Be_Able_To_Store_A_ResourceFile_Indicator()
        {
            RibbonSettings.ResourceFileIdentifier = "MyResourceFile";
                
            Assert.AreEqual("MyResourceFile", RibbonSettings.ResourceFileIdentifier);
        }

        [Test]
        public void ApplyHtmlEncoding_For_Title_Should_Transform_Non_Html_Chars()
        {
            var actual = RibbonSettings.ApplyHtmlEncoding(new KeyValuePair<Enum, string>(ButtonProperty.LabelText, "< >"));
            Assert.That(actual.Value, Is.EqualTo("&lt; &gt;"));

        }

        [Test]
        public void It_Should_Be_Able_To_Store_An_Image_Folder_Link()
        {
            RibbonSettings.ImagesFolder = "/_layouts/SPFluentRibbon/Images/";

            Assert.AreEqual("/_layouts/SPFluentRibbon/Images/",RibbonSettings.ImagesFolder);
        }

        [Test]
        public void ApplyResourceLink_Should_Transform_Title_Value_To_Resource_Link()
        {
            var resourceLink = "$Resources:MyResource, MyButtonTitle";
            RibbonSettings.ResourceFileIdentifier = "MyResource";
            var labelText = new KeyValuePair<Enum, String>(ButtonProperty.LabelText, "MyButtonTitle");
            labelText = RibbonSettings.ApplyResourceLink(labelText);
            Assert.IsNotNull(labelText);
            Assert.AreEqual(resourceLink,labelText.Value);
        }

        [Test]
        public void ApplyResourceLink_Should_Remove_Resource_File_Ending_If_Passed_To_ResourceFileProperty()
        {
            var resourceLink = "$Resources:MyResource, MyButtonTitle";
            RibbonSettings.ResourceFileIdentifier = "MyResource.resx";
            var labelText = new KeyValuePair<Enum, String>(ButtonProperty.LabelText, "MyButtonTitle");
            labelText = RibbonSettings.ApplyResourceLink(labelText);
            Assert.IsNotNull(labelText);
            Assert.AreEqual(resourceLink, labelText.Value);
        }


        [Test]
        public void ApplyImagesFolder_Should_Concat_ImagesFolder_And_Relative_ImageUrl()
        {
            var imageDestination = "/_layouts/SPFluentRibbon/Images/AddItem.png";
            RibbonSettings.ImagesFolder = "/_layouts/SPFluentRibbon/Images/";
            var imageProperty = new KeyValuePair<Enum, String>(ButtonProperty.Image32by32, "AddItem.png");
            imageProperty = RibbonSettings.ApplyImagesFolder(imageProperty);
            Assert.IsNotNull(imageProperty);
            Assert.AreEqual(imageDestination, imageProperty.Value);
        }

        [Test]
        public void ApplyImagesFolder_Should_Throw_ImageFolderNotSpecified_Exception_If_ImageFolder_IsMissing()
        {
            var imageProperty = new KeyValuePair<Enum, String>(ButtonProperty.Image32by32, "AddItem.png");
            Assert.Throws<ImageFolderNotSpecifiedException>(()=> RibbonSettings.ApplyImagesFolder(imageProperty));
        }

        [Test]
        public void ApplyImagesFolder_Should_Add_An_Ending_Slash_To_ImagesFolder_If_Missing()
        {
            var imageDestination = "/_layouts/SPFluentRibbon/Images/AddItem.png";
            RibbonSettings.ImagesFolder = "/_layouts/SPFluentRibbon/Images";
            var imageProperty = new KeyValuePair<Enum, String>(ButtonProperty.Image32by32, "AddItem.png");
            imageProperty = RibbonSettings.ApplyImagesFolder(imageProperty);
            Assert.IsNotNull(imageProperty);
            Assert.AreEqual(imageDestination, imageProperty.Value);
        }

        [Test]
        public void Locatlization_Should_Only_Act_If_Specified()
        {
            Assert.IsFalse(RibbonSettings.LocalizeVisualElements);
        }

        [Test]
        public void LocalizeVisualElements_Should_Be_True_If_ResourceFileIdentifier_Was_Set()
        {
            RibbonSettings.ResourceFileIdentifier = "Test";
            Assert.IsTrue(RibbonSettings.LocalizeVisualElements);
        }
    }
}