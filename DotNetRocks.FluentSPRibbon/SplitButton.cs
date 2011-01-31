using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class SplitButton : InteractiveRibbonElement
    {
        internal SplitButton() : this("NotSet")
        {
            
        }

        internal SplitButton(String id) : base(id)
        {
            
        }

        public String Get(SplitButtonProperty propertyKey)
        {
            return GetPropertyValue(propertyKey);
        }

        public SplitButton Set(SplitButtonProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey, value);
            return this;
        }

        public SplitButton Set(Dictionary<SplitButtonProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
       
    }
}
