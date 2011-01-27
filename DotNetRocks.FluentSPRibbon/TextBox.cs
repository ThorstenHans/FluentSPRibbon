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
            return GetProperty(propertyKey.ToString());
        }

        public TextBox ApplyProperty(TextBoxProperty propertyKey, String value)
        {
            SetProperty(propertyKey.ToString(), value);
            return this;
        }

        public TextBox ApplyProperties(Dictionary<TextBoxProperty, String> properties)
        {
            SetProperties(properties.ToDictionary(e=>e.Key.ToString(),e=>e.Value));
            return this;
        }
    }
}