using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class GalleryButton : InteractiveRibbonElement
    {
        internal GalleryButton() : this("NotSet") { }

        internal GalleryButton(string id) : base(id) { }

        public String GetProperty(GalleryButtonProperty propertyKey)
        {
            return GetPropertyValue(propertyKey.ToString());
        }

        public GalleryButton SetProperty(GalleryButtonProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey.ToString(), value);
            return this;
        }

        public GalleryButton SetProperties(Dictionary<GalleryButtonProperty, String> properties)
        {
            AddOrUpdateProperties(properties.ToDictionary(e=>e.Key.ToString(), e=>e.Value));
            return this;
        }
    }
}
