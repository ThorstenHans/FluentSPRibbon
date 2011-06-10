using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class Button : InteractiveRibbonElement<Button,ButtonProperty, ButtonDisplayMode>
    {
        
        internal Button():this("NotSet"){}

        internal Button(string id) : base(id) { }

        public static new Button Create(String id)
        {
            return RibbonElement<Button>.Create(id);
        }

        public override Button Set(ButtonProperty propertyName, String propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

        public override Button SetDisplayMode(ButtonDisplayMode displayMode)
        {
            SetDisplayModeTo(displayMode);
            return this;
        }

        public override Button Set(Dictionary<ButtonProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}