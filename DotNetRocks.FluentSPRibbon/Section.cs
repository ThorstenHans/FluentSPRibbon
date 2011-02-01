using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class Section : RibbonElement<Section,SectionProperty>, IRibbonElementContainer<Section, Row>
    {
        internal readonly IList<Row> _rows;

        internal Section() : this("NotSet") { }

        internal Section(String id)
            : base(id)
        {
            this._rows = new List<Row>();
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


        public override Section Set(SectionProperty propertyName, string propertyValue)
        {
            AddOrUpdateProperty(propertyName,propertyValue);
            return this;
        }

        public override Section Set(Dictionary<SectionProperty, string> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key,property.Value);
            }
            return this;
        }
    }
}