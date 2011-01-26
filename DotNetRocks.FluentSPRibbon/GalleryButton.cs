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

        internal override string TagName
        {
            get { return "GalleryButton"; }
        }

        public GalleryButton ApplyProperty(String name, String value)
        {
            SetProperty(name, value);
            return this;
        }

        public GalleryButton ApplyProperties(Dictionary<String, String> properties)
        {
            foreach (var property in properties)
            {
                SetProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}
