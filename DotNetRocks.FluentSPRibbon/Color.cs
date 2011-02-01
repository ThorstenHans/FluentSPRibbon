using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class Color : RibbonElement<Color,ColorProperty>
    {
        internal Color() :this("NotSet") { }

        internal Color(string id) : base(id) { }

        internal override bool IsIdProvider
        {
            get { return false; }
        }

        public override Color Set(ColorProperty propertyName, string propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

        public override Color Set(Dictionary<ColorProperty, String> properties)
        {
            foreach (var property in properties)
            {
                Set(property.Key, property.Value);
            }
            return this;
        }
    }
}