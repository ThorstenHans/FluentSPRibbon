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

        public String Get(LabelProperty propertyKey)
        {
            return GetPropertyValue(propertyKey);
        }
  
        public Label Set(LabelProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey, value);
            return this;
        }

        public Label Set(Dictionary<LabelProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}