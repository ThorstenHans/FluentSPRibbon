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
            return GetPropertyValue(propertyKey.ToString());
        }

        public FlyoutAnchor SetProperty(FlyoutAnchorProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey.ToString(),value);
            return this;
        }

        public FlyoutAnchor SetProperties(Dictionary<FlyoutAnchorProperty,String> properties)
        {
            AddOrUpdateProperties(properties.ToDictionary(e=>e.Key.ToString(),e=>e.Value));
            return this;
        }
    }
}
