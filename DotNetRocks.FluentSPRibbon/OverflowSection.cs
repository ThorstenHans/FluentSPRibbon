using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class OverflowSection : TemplateElement<OverflowSection,OverflowSectionProperty, OverflowSectionDisplayMode>
    {
        internal OverflowSection() :this("NotSet") { }

        internal OverflowSection(String id) :base(id){ }

        public override OverflowSection Set(OverflowSectionProperty propertyName, string propertyValue)
        {
            AddOrUpdateProperty(propertyName,propertyValue);
            return this;
        }

        public new static OverflowSection Create(String id)
        {
            return TemplateElement<OverflowSection, OverflowSectionProperty, OverflowSectionDisplayMode>.Create(id);
        }

        public override OverflowSection Set(Dictionary<OverflowSectionProperty, string> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key,property.Value);
            }
            return this;
        }

        public override OverflowSection SetDisplayMode(OverflowSectionDisplayMode displayMode)
        {
            SetDisplayModeTo(displayMode.ToString());
            return this;
        }

        public override OverflowSectionDisplayMode GetDisplayMode()
        {
            if (this._properties.ContainsKey(TemplateProperty.DisplayMode))
                return (OverflowSectionDisplayMode)Enum.Parse(typeof(OverflowSectionDisplayMode), this._properties[TemplateProperty.DisplayMode]);
            return OverflowSectionDisplayMode.Large;
        }
    }
}