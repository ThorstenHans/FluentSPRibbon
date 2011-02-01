using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class ToggleButton: InteractiveRibbonElement<ToggleButton,ToggleButtonProperty, ToggleButtonDisplayMode>
    {
        internal ToggleButton() : this("NotSet"){}

        internal ToggleButton(string id) : base(id)
        {
        }
         
        public override ToggleButton SetDisplayMode(ToggleButtonDisplayMode displayMode)
        {
            SetDisplayModeTo(displayMode);
            return this;
        }

        public override ToggleButton Set(ToggleButtonProperty propertyName, String propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

        public override ToggleButton Set(Dictionary<ToggleButtonProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}