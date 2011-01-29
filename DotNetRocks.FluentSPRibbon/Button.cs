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
            AddOrUpdateProperty(key, value);
            return this;
        }

        internal String GetProperty(ButtonProperty propertyName)
        {
            return GetPropertyValue(propertyName);
        }

        public Button SetProperties(Dictionary<ButtonProperty, String> properties)
        {
            foreach (var property in properties)
            {
                SetProperty(property.Key, property.Value);
            }
            return this;
        }

    }
}