using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class Label : InteractiveRibbonElement<Label,LabelProperty,LabelDisplayMode>
    {
        internal Label():this("NotSet")
        {
            
        }

        internal Label(string id) : base(id)
        {
        }

        public override Label SetDisplayMode(LabelDisplayMode displayMode)
        {
            SetDisplayModeTo(displayMode);
            return this;
        }

        public override  Label Set(LabelProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey, value);
            return this;
        }

        public override Label Set(Dictionary<LabelProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}