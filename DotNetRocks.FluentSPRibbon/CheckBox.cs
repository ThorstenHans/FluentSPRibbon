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
            return GetPropertyValue(propertyKey.ToString());
        }
      
        public CheckBox SetProperty(CheckBoxProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey.ToString(),value);
            return this;
        }

        public CheckBox SetProperties(Dictionary<String,String> properties)
        {
            AddOrUpdateProperties(properties.ToDictionary(e=>e.Key.ToString(),e=>e.Value));
            return this;
        }
    }
}