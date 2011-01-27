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
            return GetProperty(propertyKey.ToString());
        }

        public GalleryButton ApplyProperty(GalleryButtonProperty propertyKey, String value)
        {
            SetProperty(propertyKey.ToString(), value);
            return this;
        }

        public GalleryButton ApplyProperties(Dictionary<GalleryButtonProperty, String> properties)
        {
            SetProperties(properties.ToDictionary(e=>e.Key.ToString(), e=>e.Value));
            return this;
        }
    }
}
