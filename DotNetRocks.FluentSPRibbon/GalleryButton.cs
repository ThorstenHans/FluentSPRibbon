using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class GalleryButton : InteractiveRibbonElement
    {
        internal GalleryButton() : this("NotSet")
        {

        }

        internal GalleryButton(string id) : base(id)
        {

        }

   
        public GalleryButton ApplyProperty(String name, String value)
        {
            SetProperty(name, value);
            return this;
        }

        public GalleryButton ApplyProperties(Dictionary<String, String> properties)
        {
            SetProperties(properties);
            return this;
        }
    }
}
