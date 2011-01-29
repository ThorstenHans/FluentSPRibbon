using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class Gallery : RibbonElement, IRibbonElementContainer<Gallery, GalleryButton>
    {

        internal Gallery():this("NotSet") { }

        internal Gallery(String id) : base(id)
        {
            _galleryButtons=new List<GalleryButton>();
        }

        internal readonly IList<GalleryButton> _galleryButtons;

        public String GetProperty(GalleryProperty propertyKey)
        {
            return GetPropertyValue(propertyKey);
        }

        public Gallery SetProperty(GalleryProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey,value);
            return this;
        }

        public Gallery SetProperties(Dictionary<GalleryProperty,String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key,property.Value);
            }
            return this;
        }

        public GalleryButton this[string id]
        {
            get { return _galleryButtons.FirstOrDefault(gb => gb.OriginalId == id); }
        }

        public Gallery With(Func<GalleryButton> expression)
        {
            var galleryButton = expression.Invoke();
            galleryButton.Parent = this;
            _galleryButtons.Add(galleryButton);
            return this;
        }
    }
}
