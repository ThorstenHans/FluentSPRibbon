using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class DropDown : InteractiveRibbonElement
    {
        internal DropDown() : this("NotSet") { }

        internal DropDown(String id) :base(id) { }

        public String Get(DropDownProperty propertyKey)
        {
            return GetPropertyValue(propertyKey);
        }

        public DropDown SetDisplayMode(DisplayMode displayMode)
        {
            SetDisplayModeTo(displayMode);
            return this;
        }

        public DropDown Set(DropDownProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey,value);
            return this;
        }

        public DropDown Set(Dictionary<DropDownProperty,String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}
