using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class Button : InteractiveRibbonElement
    {
        

        internal Button():this("NotSet"){}

        internal Button(string id) : base(id) { }

        public Button SetProperty(ButtonProperty key, String value)
        {
            AddOrUpdateProperty(key.ToString(), value);
            return this;
        }

        internal String GetProperty(ButtonProperty propertyName)
        {
            return GetPropertyValue(propertyName.ToString());
        }

        public Button SetProperties(Dictionary<ButtonProperty, String> properties)
        {
            AddOrUpdateProperties(properties.ToDictionary(property => property.Key.ToString(), property => property.Value));
            return this;
        }

    }
}