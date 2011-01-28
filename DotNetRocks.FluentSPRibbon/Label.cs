using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class Label : InteractiveRibbonElement
    {
        internal Label():this("NotSet")
        {
            
        }

        internal Label(string id) : base(id)
        {
        }

        public String GetProperty(LabelProperty propertyKey)
        {
            return GetPropertyValue(propertyKey.ToString());
        }
  
        public Label SetProperty(LabelProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey.ToString(), value);
            return this;
        }

        public Label SetProperties(Dictionary<LabelProperty, String> properties)
        {
            AddOrUpdateProperties(properties.ToDictionary(e=>e.Key.ToString(),e=>e.Value));
            return this;
        }
    }
}