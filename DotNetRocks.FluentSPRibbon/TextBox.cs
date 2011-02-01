using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public enum TextBoxDisplayMode
    {
        
    }
    public class TextBox : InteractiveRibbonElement<TextBox,TextBoxProperty, TextBoxDisplayMode>
    {
        internal TextBox() : this("NotSet")
        {
        }

        internal TextBox(string id) : base(id)
        {
        }


        public override TextBox SetDisplayMode(TextBoxDisplayMode displayMode)
        {
            SetDisplayModeTo(displayMode);
            return this;
        }

        public override TextBox Set(TextBoxProperty propertyName, String propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

        public override TextBox Set(Dictionary<TextBoxProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}