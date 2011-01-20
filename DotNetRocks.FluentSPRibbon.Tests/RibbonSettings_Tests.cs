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
        public void It_Should_Be_Able_To_Store_A_ResourceFile_Indicator()
        {
            RibbonSettings.ResourceFileIdentifier = "MyResourceFile";

            Assert.AreEqual("MyResourceFile", RibbonSettings.ResourceFileIdentifier);
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
            // Arrange
            var resourceLink = "$Resources:MyResource, MyButtonTitle";
            RibbonSettings.ResourceFileIdentifier = "MyResource";
            var title = new KeyValuePair<String, String>("Title", "MyButtonTitle");

            // Act
            title = RibbonSettings.ApplyResourceLink(title);

            // Assert
            Assert.IsNotNull(title);
            Assert.AreEqual(resourceLink,title.Value);
        }

        [Test]
        public void ApplyResourceLink_Should_Remove_Resource_File_Ending_If_Passed_To_ResourceFileProperty()
        {
            // Arrange
            var resourceLink = "$Resources:MyResource, MyButtonTitle";
            RibbonSettings.ResourceFileIdentifier = "MyResource.resx";
            var title = new KeyValuePair<String, String>("Title", "MyButtonTitle");

            // Act
            title = RibbonSettings.ApplyResourceLink(title);

            // Assert
            Assert.IsNotNull(title);
            Assert.AreEqual(resourceLink, title.Value);
        }


        [Test]
        public void ApplyImagesFolder_Should_Concat_ImagesFolder_And_Relative_ImageUrl()
        {
            // Arrange
            var imageDestination = "/_layouts/SPFluentRibbon/Images/AddItem.png";
            RibbonSettings.ImagesFolder = "/_layouts/SPFluentRibbon/Images/";
            var imageProperty = new KeyValuePair<String, String>("Image32by32", "AddItem.png");

            // Act
            imageProperty = RibbonSettings.ApplyImagesFolder(imageProperty);

            // Assert
            Assert.IsNotNull(imageProperty);
            Assert.AreEqual(imageDestination, imageProperty.Value);
        }

        [Test]
        public void ApplyImagesFolder_Should_Throw_ImageFolderNotSpecified_Exception_If_ImageFolder_IsMissing()
        {
            var imageProperty = new KeyValuePair<String, String>("Image32by32", "AddItem.png");
            Assert.Throws<ImageFolderNotSpecifiedException>(()=> RibbonSettings.ApplyImagesFolder(imageProperty));
        }

        [Test]
        public void ApplyImagesFolder_Should_Add_An_Ending_Slash_To_ImagesFolder_If_Missing()
        {
            // Arrange
            var imageDestination = "/_layouts/SPFluentRibbon/Images/AddItem.png";
            RibbonSettings.ImagesFolder = "/_layouts/SPFluentRibbon/Images";
            var imageProperty = new KeyValuePair<String, String>("Image32by32", "AddItem.png");

            // Act
            imageProperty = RibbonSettings.ApplyImagesFolder(imageProperty);

            // Assert
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
            // Arrange
         

            // Act
            RibbonSettings.ResourceFileIdentifier = "Test";

            // Assert
            Assert.IsTrue(RibbonSettings.LocalizeVisualElements);
        }
        
        
        
    }
}