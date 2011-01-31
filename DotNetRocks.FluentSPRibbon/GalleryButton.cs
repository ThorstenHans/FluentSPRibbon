using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class GalleryButton : InteractiveRibbonElement
    {
        internal GalleryButton() : this("NotSet") { }

        internal GalleryButton(string id) : base(id) { }

        public String Get(GalleryButtonProperty propertyKey)
        {
            return GetPropertyValue(propertyKey);
        }

        public GalleryButton SetDisplayMode(DisplayMode displayMode)
        {
            SetDisplayModeTo(displayMode);
            return this;
        }

        public GalleryButton Set(GalleryButtonProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey, value);
            return this;
        }

        public GalleryButton Set(Dictionary<GalleryButtonProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}
