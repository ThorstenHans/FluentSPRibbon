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

        public string GetProperty(ColorProperty propertyKey)
        {
            return GetPropertyValue(propertyKey);
        }

        public Color SetProperty(ColorProperty propertyKey, string value)
        {
            AddOrUpdateProperty(propertyKey,value);
            return this;
        }

        public Color SetProperties(Dictionary<ColorProperty, String> properties)
        {
            foreach (var property in properties)
            {
                SetProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}