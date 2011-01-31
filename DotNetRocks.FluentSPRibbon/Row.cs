using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class Row : RibbonElement, 
                       IRibbonElementContainer<Row, OverflowArea>, 
                       IRibbonElementContainer<Row, ControlRef>,
                       IRibbonElementContainer<Row,Strip>
    {
        internal readonly IList<OverflowArea> _overflowAreas;
        internal readonly IList<ControlRef> _controlRefs;
        internal readonly IList<Strip> _strips;

        internal Row() : this("NotSet") { }

        internal Row(String id) : base(id)
        {
            this._strips = new List<Strip>();
            this._overflowAreas=new List<OverflowArea>();
            this._controlRefs = new List<ControlRef>();
        }

        public Row With(Func<OverflowArea> expression)
        {
            var overflowArea = expression.Invoke();
            overflowArea.Parent = this;
            this._overflowAreas.Add(overflowArea);
            return this;
        }

        public Row With(Func<ControlRef> expression)
        {
            var controlRef = expression.Invoke();
            controlRef.Parent = this;
            this._controlRefs.Add(controlRef);
            return this;
        }

        public Row With(Func<Strip> expression)
        {
            var strip = expression.Invoke();
            strip.Parent = this;
            this._strips.Add(strip);
            return this;
        }
    }
}