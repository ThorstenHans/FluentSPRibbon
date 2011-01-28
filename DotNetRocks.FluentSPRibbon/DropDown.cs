using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class DropDown : InteractiveRibbonElement
    {
        internal DropDown() : this("NotSet") { }

        internal DropDown(String id) :base(id) { }

        public String GetProperty(DropDownProperty propertyKey)
        {
            return GetPropertyValue(propertyKey.ToString());
        }

        public DropDown SetProperty(DropDownProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey.ToString(),value);
            return this;
        }

        public DropDown SetProperties(Dictionary<DropDownProperty,String> properties)
        {
            AddOrUpdateProperties(properties.ToDictionary(e=>e.Key.ToString(), e=>e.Value));
            return this;
        }
    }
}
