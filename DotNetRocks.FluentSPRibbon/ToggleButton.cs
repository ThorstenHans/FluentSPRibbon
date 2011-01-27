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
            return GetProperty(propertyKey.ToString());
        }

        public ToggleButton ApplyProperty(ToggleButtonProperty propertyKey, String value)
        {
            SetProperty(propertyKey.ToString(), value);
            return this;
        }

        public ToggleButton ApplyProperties(Dictionary<ToggleButtonProperty, String> properties)
        {
            SetProperties(properties.ToDictionary(e=>e.Key.ToString(),e=>e.Value));
            return this;
        }
    }
}