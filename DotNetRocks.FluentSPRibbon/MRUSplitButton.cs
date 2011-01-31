using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class MRUSplitButton : InteractiveRibbonElement
    {
        internal MRUSplitButton()  : this("NotSet")
        {
            
        }

        internal MRUSplitButton(String id)
            : base(id)
        {
            
        }

        public String Get(MRUProperty propertyKey)
        {
            return GetPropertyValue(propertyKey);
        }

        public MRUSplitButton SetDisplayMode(DisplayMode displayMode)
        {
            SetDisplayModeTo(displayMode);
            return this;
        }

        public MRUSplitButton Set(MRUProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey, value);
            return this;
        }

        public MRUSplitButton Set(Dictionary<MRUProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}
