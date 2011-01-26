using System;
using System.Collections.Generic;

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

        internal override string TagName
        {
            get { return "TextBox"; }
        }

        public TextBox ApplyProperty(String name, String value)
        {
            SetProperty(name, value);
            return this;
        }

        public TextBox ApplyProperties(Dictionary<String, String> properties)
        {
            foreach (var property in properties)
            {
                SetProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}