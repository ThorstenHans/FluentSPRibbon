using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class ToggleButton: InteractiveRibbonElement
    {
        internal ToggleButton() : this("NotSet"){}

        internal ToggleButton(string id) : base(id)
        {
        }

        public String GetProperty(ToggleButtonProperty propertyKey)
        {
            return GetPropertyValue(propertyKey.ToString());
        }

        public ToggleButton SetProperty(ToggleButtonProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey.ToString(), value);
            return this;
        }

        public ToggleButton SetProperties(Dictionary<ToggleButtonProperty, String> properties)
        {
            AddOrUpdateProperties(properties.ToDictionary(e=>e.Key.ToString(),e=>e.Value));
            return this;
        }
    }
}