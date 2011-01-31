using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class CheckBox : InteractiveRibbonElement
    {

        internal CheckBox() : this("NotSet")
        {
        }

        internal CheckBox(string id) : base(id)
        {
        }

        public String Get(CheckBoxProperty propertyKey)
        {
            return GetPropertyValue(propertyKey);
        }
      
        public CheckBox Set(CheckBoxProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey,value);
            return this;
        }

        public CheckBox Set(Dictionary<CheckBoxProperty,String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}