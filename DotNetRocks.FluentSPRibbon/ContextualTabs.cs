using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class ContextualTabs : RibbonElement<ContextualTabs>, IRibbonElementContainer<ContextualTabs, ContextualGroup>
    {
        private IList<ContextualGroup> _contextualGroups; 

        internal ContextualTabs() : this("NotSet") { }

        internal ContextualTabs(string id) : base(id)
        {
            this._contextualGroups = new List<ContextualGroup>();    
        }

        public static new ContextualTabs Create(string id)
        {
            return RibbonElement<ContextualTabs>.Create(id);
        }

        internal override bool IsIdProvider
        {
            get { return true; }
        }

        public ContextualTabs With(Func<ContextualGroup> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            this._contextualGroups.Add(child);
            return this;
        }
    }
}