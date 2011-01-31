using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class Scale : RibbonElement
    {
        internal Scale() : this("NotSet") { }

        internal Scale(String id) : base(id) { }

        public String Get(ScaleProperty propertyKey)
        {
            return GetPropertyValue(propertyKey);
        }

        public Scale Set(ScaleProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey,value);
            return this;
        }

        public Scale Set(Dictionary<ScaleProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key,property.Value);
            }
            return this;
        }
    }
}