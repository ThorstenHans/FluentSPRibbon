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
            return GetPropertyValue(propertyKey.ToString());
        }

        public Color SetProperty(ColorProperty propertyKey, string value)
        {
            AddOrUpdateProperty(propertyKey.ToString(),value);
            return this;
        }

        public Color SetProperties(Dictionary<ColorProperty, String> properties)
        {
            AddOrUpdateProperties(properties.ToDictionary(e=>e.Key.ToString(),e=>e.Value));
            return this;
        }
    }
}