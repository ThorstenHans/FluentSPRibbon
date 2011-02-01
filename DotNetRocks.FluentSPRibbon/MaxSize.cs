using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class MaxSize : RibbonElement<MaxSize,MaxSizeProperty>
    {
        internal MaxSize() : this("NotSet") { }

        internal MaxSize(string id) : base(id) { }

        public override  MaxSize Set(MaxSizeProperty propertyName, String propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

        public override MaxSize Set(Dictionary<MaxSizeProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}