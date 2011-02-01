using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;

namespace DotNetRocks.FluentSPRibbon
{
    public class Strip : RibbonElement<Strip>, IRibbonElementContainer<Strip,ControlRef>
    {
        internal readonly IList<ControlRef> _controlRefs;

        internal Strip() : this("NotSet") { }

        internal Strip(String id) :base(id)
        {
            this._controlRefs = new List<ControlRef>();
        }

        public Strip With(Func<ControlRef> expression)
        {
            var controlRef = expression.Invoke();
            
            this._controlRefs.Add(controlRef);
            return this;
        }

        internal override bool IsIdProvider
        {
            get { return false; }
        }
    }
}