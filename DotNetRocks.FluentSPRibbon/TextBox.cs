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


        public TextBox ApplyProperty(String name, String value)
        {
            SetProperty(name, value);
            return this;
        }

        public TextBox ApplyProperties(Dictionary<String, String> properties)
        {
            SetProperties(properties);
            return this;
        }
    }
}