using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class OverflowArea : TemplateElement<OverflowArea,OverflowAreaProperty,OverflowAreaDisplayMode>
    {
        internal OverflowArea() : this("NotSet") { }

        internal OverflowArea(String id) : base(id) { }


        public override OverflowArea Set(OverflowAreaProperty propertyName, string propertyValue)
        {
            AddOrUpdateProperty(propertyName,propertyValue);
            return this;
        }

        public override OverflowArea Set(Dictionary<OverflowAreaProperty, string> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key,property.Value);
            }
            return this;
        }

        public override OverflowArea SetDisplayMode(OverflowAreaDisplayMode displayMode)
        {
            SetDisplayModeTo(displayMode.ToString());
            return this;
        }

        public override OverflowAreaDisplayMode GetDisplayMode()
        {
            if (this._properties.ContainsKey(TemplateProperty.DisplayMode))
                return (OverflowAreaDisplayMode)Enum.Parse(typeof(OverflowAreaDisplayMode), this._properties[TemplateProperty.DisplayMode]);
            return OverflowAreaDisplayMode.Large;
        }
    }
}