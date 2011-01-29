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
            return GetPropertyValue(propertyKey);
        }

        public DropDown SetProperty(DropDownProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey,value);
            return this;
        }

        public DropDown SetProperties(Dictionary<DropDownProperty,String> properties)
        {
            foreach (var property in properties)
            {
                SetProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}
