using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class TextBox : InteractiveRibbonElement
    {
        internal TextBox() : this("NotSet")
        {
        }

        internal TextBox(string id) : base(id)
        {
        }

        public String Get(TextBoxProperty propertyKey)
        {
            return GetPropertyValue(propertyKey);
        }

        public TextBox Set(TextBoxProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey, value);
            return this;
        }

        public TextBox Set(Dictionary<TextBoxProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}