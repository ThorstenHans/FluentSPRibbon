using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public static class RibbonSettings
    {
        private static string _resourceFileIdentifier;
        public static String ImagesFolder { get; set; }
        public static String ResourceFileIdentifier
        {
            get { return _resourceFileIdentifier; }
            set
            {
                _resourceFileIdentifier = value;
                if (String.IsNullOrEmpty(_resourceFileIdentifier))
                    LocalizeVisualElements = false;
                else
                    LocalizeVisualElements = true;
            }
        }
        
        internal static bool LocalizeVisualElements { get; set; }
        private static readonly List<String> LocalizableProperties;
        private static readonly List<String> ImagesFolderProperties;
        

        static RibbonSettings()
        {
            LocalizableProperties = new List<string>()
                                         {
                                             "Title"
                                         };

            ImagesFolderProperties = new List<string>()
                                          {
                                              "Image32by32"
                                          };


        }

        public static KeyValuePair<string, string> ApplyResourceLink(KeyValuePair<string, string> property)
        {
            if(!LocalizeVisualElements)
                return property;
            if(LocalizableProperties.Contains(property.Key))
                return new KeyValuePair<String, String>(property.Key, BuildResourceString(property.Value));
            return property;
        }


        public static KeyValuePair<string, string> ApplyImagesFolder(KeyValuePair<string, string> imageProperty)
        {
            if(ImagesFolderProperties.Contains(imageProperty.Key))
                return new KeyValuePair<string, string>(imageProperty.Key,BuildAbsoluteImageUrl(imageProperty.Value));
            return imageProperty;
        }

        private static string BuildAbsoluteImageUrl(string relativeImageUrl)
        {
            if (String.IsNullOrEmpty(ImagesFolder))
                throw new ImageFolderNotSpecifiedException("The 'ImagesFolder' property on 'RibbonSettings' is not specified.");
            if (ImagesFolder.EndsWith("/"))
                return String.Concat(ImagesFolder, relativeImageUrl);
            return String.Format("{0}/{1}", ImagesFolder, relativeImageUrl);
        }

        private static string BuildResourceString(string resourceKey)
        {
            if (String.IsNullOrEmpty(ResourceFileIdentifier))
                throw new ResourceFileIdentifierNotSpecifiedException("The 'ResourceFile' Property on 'RibbonSettings' is not specified");
            var resourceFile = ResourceFileIdentifier.IndexOf(".resx")>-1?ResourceFileIdentifier.Substring(0,ResourceFileIdentifier.IndexOf(".resx")):ResourceFileIdentifier;
            return String.Format("$Resources:{0}, {1}", resourceFile, resourceKey);
        }

    }
}
