using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class Button : InteractiveRibbonElement
    {
        

        internal Button():this("NotSet"){}

        internal Button(string id) : base(id) { }

        public Button Set(ButtonProperty key, String value)
        {
            AddOrUpdateProperty(key, value);
            return this;
        }

        public Button SetDisplayMode(DisplayMode displayMode)
        {
            SetDisplayModeTo(displayMode);
            return this;
        }

        internal String Get(ButtonProperty propertyName)
        {
            return GetPropertyValue(propertyName);
        }

        public Button Set(Dictionary<ButtonProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }

    }
}