using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class FlyoutAnchor : InteractiveRibbonElement
    {
        internal FlyoutAnchor() : this("NotSet") { }

        internal FlyoutAnchor(String id) : base(id) { }

        public String Get(FlyoutAnchorProperty propertyKey)
        {
            return GetPropertyValue(propertyKey);
        }

        public FlyoutAnchor SetDisplayMode(DisplayMode displayMode)
        {
            SetDisplayModeTo(displayMode);
            return this;
        }

        public FlyoutAnchor Set(FlyoutAnchorProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey,value);
            return this;
        }

        public FlyoutAnchor Set(Dictionary<FlyoutAnchorProperty,String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}
