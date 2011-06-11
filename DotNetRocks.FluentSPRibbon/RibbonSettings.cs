using System;
using System.Collections.Generic;
using System.Web;


namespace DotNetRocks.FluentSPRibbon
{
    public static class RibbonSettings
    {
        private static string _resourceFileIdentifier;
        
        internal static bool LocalizeVisualElements { get; set; }

        public static String ImagesFolder { get; set; }

        public static String ResourceFileIdentifier
        {
            get { return _resourceFileIdentifier; }
            set
            {
                _resourceFileIdentifier = value;
                LocalizeVisualElements = !String.IsNullOrEmpty(_resourceFileIdentifier);
            }
        }

        public static KeyValuePair<Enum, string> ApplyResourceLink(KeyValuePair<Enum, string> property)
        {
            if (!LocalizeVisualElements)
                return property;
            return IsTextProvider(property.Key) ? new KeyValuePair<Enum, String>(property.Key, BuildResourceString(property.Value)) : property;
        }

        public static KeyValuePair<Enum, string> ApplyImagesFolder(KeyValuePair<Enum, string> imageProperty)
        {
            return IsImageProvider(imageProperty.Key) ? new KeyValuePair<Enum, string>(imageProperty.Key, BuildAbsoluteImageUrl(imageProperty.Value)) : imageProperty;
        }

        public static KeyValuePair<Enum,String> ApplyUrlEncoding(KeyValuePair<Enum,String> urlProperty)
        {
            
            return IsUrlProvider(urlProperty.Key) 
                       ? new KeyValuePair<Enum, string>(urlProperty.Key, Uri.EscapeUriString(urlProperty.Value)) : urlProperty;
        }

        public static KeyValuePair<Enum,String> ApplyHtmlEncoding(KeyValuePair<Enum,String> plainProperty)
        {
            if(IsUrlProvider(plainProperty.Key) ||
                IsImageProvider(plainProperty.Key))
                return plainProperty;
            
            return new KeyValuePair<Enum, string>(plainProperty.Key, HttpUtility.HtmlEncode(plainProperty.Value));
        }

        private static string BuildAbsoluteImageUrl(string relativeImageUrl)
        {
            if (String.IsNullOrEmpty(ImagesFolder))
                throw new ImageFolderNotSpecifiedException(
                    "The 'ImagesFolder' property on 'RibbonSettings' is not specified.");
            return ImagesFolder.EndsWith("/") ? String.Concat(ImagesFolder, relativeImageUrl) : String.Format("{0}/{1}", ImagesFolder, relativeImageUrl);
        }

        private static string BuildResourceString(string resourceKey)
        {
            var resourceFile = ResourceFileIdentifier.IndexOf(".resx") > -1
                                   ? ResourceFileIdentifier.Substring(0, ResourceFileIdentifier.IndexOf(".resx"))
                                   : ResourceFileIdentifier;
            return String.Format("$Resources:{0}, {1}", resourceFile, resourceKey);
        }

        private static bool IsTextProvider(Enum key)
        {
            return key.GetType().GetField(key.ToString()).GetCustomAttributes(typeof (TextProvider), false).Length > 0;
        }

        private static bool IsUrlProvider(Enum key)
        {
            return key.GetType().GetField(key.ToString()).GetCustomAttributes(typeof (UrlProvider), false).Length > 0;
        }

        private static bool IsImageProvider(Enum key)
        {
            return key.GetType().GetField(key.ToString()).GetCustomAttributes(typeof (ImageProvider), false).Length > 0;
        }
    }
}