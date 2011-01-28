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

        public String GetProperty(TextBoxProperty propertyKey)
        {
            return GetPropertyValue(propertyKey.ToString());
        }

        public TextBox SetProperty(TextBoxProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey.ToString(), value);
            return this;
        }

        public TextBox SetProperties(Dictionary<TextBoxProperty, String> properties)
        {
            AddOrUpdateProperties(properties.ToDictionary(e=>e.Key.ToString(),e=>e.Value));
            return this;
        }
    }
}