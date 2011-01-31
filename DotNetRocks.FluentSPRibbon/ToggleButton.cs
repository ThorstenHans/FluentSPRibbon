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

        public String Get(ToggleButtonProperty propertyKey)
        {
            return GetPropertyValue(propertyKey);
        }

        public ToggleButton SetDisplayMode(DisplayMode displayMode)
        {
            SetDisplayModeTo(displayMode);
            return this;
        }

        public ToggleButton Set(ToggleButtonProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey, value);
            return this;
        }

        public ToggleButton Set(Dictionary<ToggleButtonProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}