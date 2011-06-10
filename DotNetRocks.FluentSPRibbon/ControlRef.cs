using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class ControlRef : TemplateElement<ControlRef,ControlRefProperty,ControlRefDisplayMode>
    {
        internal ControlRef() :base("NotSet")  { }

        internal ControlRef(String id) :base(id) { }

        public new static ControlRef Create(String id)
        {
            return TemplateElement<ControlRef, ControlRefProperty, ControlRefDisplayMode>.Create(id);
        }

        public override ControlRef Set(ControlRefProperty propertyName, string propertyValue)
        {
            AddOrUpdateProperty(propertyName,propertyValue);
            return this;
        }

        

        public override ControlRef Set(Dictionary<ControlRefProperty, string> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key,property.Value);
            }
            return this;
        }

        public override ControlRef SetDisplayMode(ControlRefDisplayMode displayMode)
        {
            SetDisplayModeTo(displayMode.ToString());
            return this;
        }

        public override ControlRefDisplayMode GetDisplayMode()
        {
            if (this._properties.ContainsKey(TemplateProperty.DisplayMode))
                return (ControlRefDisplayMode)Enum.Parse(typeof (ControlRefDisplayMode), this._properties[TemplateProperty.DisplayMode]);
            return ControlRefDisplayMode.Large;
        }
    }
}