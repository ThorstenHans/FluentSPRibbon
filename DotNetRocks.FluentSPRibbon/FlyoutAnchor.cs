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
            return GetProperty(propertyKey.ToString());
        }

        public FlyoutAnchor ApplyProperty(FlyoutAnchorProperty propertyKey, String value)
        {
            SetProperty(propertyKey.ToString(),value);
            return this;
        }

        public FlyoutAnchor ApplyProperties(Dictionary<FlyoutAnchorProperty,String> properties)
        {
            SetProperties(properties.ToDictionary(e=>e.Key.ToString(),e=>e.Value));
            return this;
        }
    }
}
