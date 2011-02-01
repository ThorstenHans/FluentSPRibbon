using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class Gallery : RibbonElement<Gallery,GalleryProperty>, IRibbonElementContainer<Gallery, GalleryButton>
    {

        internal Gallery():this("NotSet") { }

        internal Gallery(String id) : base(id)
        {
            _galleryButtons=new List<GalleryButton>();
        }

        internal readonly IList<GalleryButton> _galleryButtons;


        public override Gallery Set(GalleryProperty propertyName, String propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

        public override Gallery Set(Dictionary<GalleryProperty,String> properties)
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
