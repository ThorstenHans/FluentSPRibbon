using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class FlyoutAnchor : InteractiveRibbonElement
    {
        internal FlyoutAnchor() : this("NotSet") { }

        internal FlyoutAnchor(String id) : base(id) { }

        public String GetProperty(FlyoutAnchorProperty propertyKey)
        {
            return GetPropertyValue(propertyKey);
        }

        public FlyoutAnchor SetProperty(FlyoutAnchorProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey,value);
            return this;
        }

        public FlyoutAnchor SetProperties(Dictionary<FlyoutAnchorProperty,String> properties)
        {
            foreach (var property in properties)
            {
                SetProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}
