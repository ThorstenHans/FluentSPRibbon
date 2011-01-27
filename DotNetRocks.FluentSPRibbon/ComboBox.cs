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
            return GetProperty(propertyKey.ToString());
        }

        public ComboBox ApplyProperty(ComboBoxProperty propertyKey, String value)
        {
            SetProperty(propertyKey.ToString(),value);
            return this;
        }

        public ComboBox ApplyProperties(Dictionary<String,String> properties)
        {
            SetProperties(properties.ToDictionary(e=>e.Key.ToString(),e=>e.Value));
            return this;
        }
    }
}
