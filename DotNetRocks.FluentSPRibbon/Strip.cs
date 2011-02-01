using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class Strip : RibbonElement<Strip,StripProperty> , IRibbonElementContainer<Strip,ControlRef>
    {
        internal readonly IList<ControlRef> _controlRefs;

        internal Strip() : this("NotSet") { }

        internal Strip(String id) : base(id)
        {
            this._controlRefs = new List<ControlRef>();
        }

        public Strip With(Func<ControlRef> expression)
        {
            var controlRef = expression.Invoke();
            
            this._controlRefs.Add(controlRef);
            return this;
        }

        public override Strip Set(StripProperty propertyName, string propertyValue)
        {
            AddOrUpdateProperty(propertyName,propertyValue);
            return this;
        }

        public override Strip Set(Dictionary<StripProperty, string> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key,property.Value);
            }
            return this;
        }
    }
}