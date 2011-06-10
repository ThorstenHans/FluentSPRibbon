using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class Section : RibbonElement<Section>, IRibbonElementContainer<Section, Row>
    {
        internal readonly IList<Row> _rows;

        internal Section() : this("NotSet") { }

        internal Section(String id)
            : base(id)
        {
            this._rows = new List<Row>();
        }

        public new static Section Create(String id)
        {
            return RibbonElement<Section>.Create(id);
        }

        internal override bool IsIdProvider
        {
            get { return false; }
        }

        public Section With(Func<Row> expression)
        {
            if (this._rows.Count <= 2)
            {
                var row = expression.Invoke();
                row.Parent = this;
                this._rows.Add(row);
                return this;
            }
            throw new IndexOutOfRangeException("Please provide max. three rows.");

        }
    }
}