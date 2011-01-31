using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class ComboBox : InteractiveRibbonElement
    {
        internal ComboBox() : this("NotSet"){ }

        internal ComboBox(String id) : base(id){ }
 
        public String Get(ComboBoxProperty propertyKey)
        {
            return GetPropertyValue(propertyKey);
        }

        public ComboBox Set(ComboBoxProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey,value);
            return this;
        }

        public ComboBox Set(Dictionary<ComboBoxProperty,String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}
