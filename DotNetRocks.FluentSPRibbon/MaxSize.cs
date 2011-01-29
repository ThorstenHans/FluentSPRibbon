using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class MaxSize : RibbonElement
    {
        internal MaxSize() : this("NotSet") { }

        internal MaxSize(string id) : base(id) { }

        public String GetProperty(MaxSizeProperty propertyKey)
        {
            return GetPropertyValue(propertyKey);
        }

        public MaxSize SetProperty(MaxSizeProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey, value);
            return this;
        }

        public MaxSize SetProperties(Dictionary<MaxSizeProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}