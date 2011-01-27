using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class Button : InteractiveRibbonElement
    {
        

        internal Button():this("NotSet"){}

        internal Button(string id) : base(id) { }

        public Button ApplyProperty(ButtonProperty key, String value)
        {
            SetProperty(key.ToString(), value);
            return this;
        }

        internal String GetProperty(ButtonProperty propertyName)
        {
            return GetProperty(propertyName.ToString());
        }

        public Button ApplyProperties(Dictionary<ButtonProperty, String> properties)
        {
            SetProperties(properties.ToDictionary(property => property.Key.ToString(), property => property.Value));
            return this;
        }

    }
}