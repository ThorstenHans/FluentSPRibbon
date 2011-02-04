using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class ContextualGroup : RibbonElement<ContextualGroup, ContextualGroupProperty>,
        IRibbonElementContainer<ContextualGroup,Tab>
    {
        internal readonly IList<Tab> _tabs;
        internal ContextualGroup() : this("NotSet") { }

        internal ContextualGroup(String id) :base(id)
        {
            this._tabs= new List<Tab>();
        }
        public override ContextualGroup Set(ContextualGroupProperty propertyName, string propertyValue)
        {
            AddOrUpdateProperty(propertyName,propertyValue);
            return this;
        }

        public override ContextualGroup Set(Dictionary<ContextualGroupProperty, string> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key,property.Value);
            }
            return this;
        }

        public ContextualGroup With(Func<Tab> expression)
        {
            var tab = expression.Invoke();
            tab.Parent = this;
            this._tabs.Add(tab);
            return this;
        }
    }
}
