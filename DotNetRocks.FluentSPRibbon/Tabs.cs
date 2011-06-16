using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class Tabs : RibbonElement<Tabs>, IRibbonElementContainer<Tabs, Tab>
    {
        private readonly IList<Tab> _tabs;

        internal Tabs() : this("NotSet") { }

        internal Tabs(string id) : base(id)
        {
            this._tabs = new List<Tab>();
        }

        public static new Tabs Create(string id)
        {
            return RibbonElement<Tabs>.Create(id);
        }

        internal override bool IsIdProvider
        {
            get { return true; }
        }

        public Tabs With(Func<Tab> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            this._tabs.Add(child);
            return this;
        }
    }
}