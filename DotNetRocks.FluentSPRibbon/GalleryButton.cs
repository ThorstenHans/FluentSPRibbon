using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class GalleryButton : InteractiveRibbonElement<GalleryButton,GalleryButtonProperty,GalleryButtonDisplayMode>
    {
        internal GalleryButton() : this("NotSet") { }

        internal GalleryButton(string id) : base(id) { }

        public new static GalleryButton Create(String id, ElementDimension elementDimension)
        {
            var galleryButton = RibbonElement<GalleryButton>.Create(id);
            galleryButton.Set(GalleryButtonProperty.ElementDimensions,
                              Enum.GetName(typeof (ElementDimension), elementDimension));
            return galleryButton;

        }
        
        public override GalleryButton SetDisplayMode(GalleryButtonDisplayMode displayMode)
        {
            SetDisplayModeTo(displayMode);
            return this;
        }

        public override GalleryButton Set(GalleryButtonProperty propertyName, String propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

        public override GalleryButton Set(Dictionary<GalleryButtonProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}
