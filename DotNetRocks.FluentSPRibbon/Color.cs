using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class Color : InteractiveRibbonElement
    {
        internal Color() :this("NotSet") { }

        internal Color(string id) : base(id) { }

        public string GetProperty(ColorProperty propertyKey)
        {
            return GetProperty(propertyKey.ToString());
        }

        public Color ApplyProperty(ColorProperty propertyKey, string value)
        {
            SetProperty(propertyKey.ToString(),value);
            return this;
        }

        public Color ApplyProperties(Dictionary<ColorProperty, String> properties)
        {
            SetProperties(properties.ToDictionary(e=>e.Key.ToString(),e=>e.Value));
            return this;
        }
    }
}