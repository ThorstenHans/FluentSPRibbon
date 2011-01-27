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
            return GetProperty(propertyKey.ToString());
        }
      
        public CheckBox ApplyProperty(CheckBoxProperty propertyKey, String value)
        {
            SetProperty(propertyKey.ToString(),value);
            return this;
        }

        public CheckBox ApplyProperties(Dictionary<String,String> properties)
        {
            SetProperties(properties.ToDictionary(e=>e.Key.ToString(),e=>e.Value));
            return this;
        }
    }
}