using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class Strip : RibbonElement , IRibbonElementContainer<Strip,ControlRef>
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
            controlRef.Parent = this;
            this._controlRefs.Add(controlRef);
            return this;
        }
    }
}