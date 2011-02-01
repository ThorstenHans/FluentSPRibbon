using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class OverflowArea : RibbonElement<OverflowArea,OverflowAreaProperty>
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
    }
}