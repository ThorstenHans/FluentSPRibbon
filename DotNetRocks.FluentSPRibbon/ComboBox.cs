using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class ComboBox : InteractiveRibbonElement
    {
        internal ComboBox() : this("NotSet"){ }

        internal ComboBox(String id) : base(id){ }
 
        public String GetProperty(ComboBoxProperty propertyKey)
        {
            return GetPropertyValue(propertyKey.ToString());
        }

        public ComboBox SetProperty(ComboBoxProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey.ToString(),value);
            return this;
        }

        public ComboBox SetProperties(Dictionary<String,String> properties)
        {
            AddOrUpdateProperties(properties.ToDictionary(e=>e.Key.ToString(),e=>e.Value));
            return this;
        }
    }
}
