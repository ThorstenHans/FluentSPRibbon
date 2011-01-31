using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class Color : InteractiveRibbonElement
    {
        internal Color() :this("NotSet") { }

        internal Color(string id) : base(id) { }

        internal override bool IsIdProvider
        {
            get { return false; }
        }

        public string Get(ColorProperty propertyKey)
        {
            return GetPropertyValue(propertyKey);
        }

        public Color Set(ColorProperty propertyKey, string value)
        {
            AddOrUpdateProperty(propertyKey,value);
            return this;
        }

        public Color Set(Dictionary<ColorProperty, String> properties)
        {
            foreach (var property in properties)
            {
                Set(property.Key, property.Value);
            }
            return this;
        }
    }
}