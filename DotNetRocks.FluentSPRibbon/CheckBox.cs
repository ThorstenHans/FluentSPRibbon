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

        public String GetProperty(CheckBoxProperty propertyKey)
        {
            return GetPropertyValue(propertyKey);
        }
      
        public CheckBox SetProperty(CheckBoxProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey,value);
            return this;
        }

        public CheckBox SetProperties(Dictionary<CheckBoxProperty,String> properties)
        {
            foreach (var property in properties)
            {
                SetProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}