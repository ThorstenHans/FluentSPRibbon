using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class Spinner : InteractiveRibbonElement<Spinner,SpinnerProperty,SpinnerDisplayMode>,
        IRibbonElementContainer<Spinner,Unit>
    {
        internal readonly IList<Unit> _units;
        internal Spinner() : this("NotSet")
        {
        }

        internal Spinner(String id) : base(id)
        {
            this._units=new List<Unit>();
        }

        public new static Spinner Create(String id)
        {
            return RibbonElement<Spinner>.Create(id);
        }

        public override Spinner SetDisplayMode(SpinnerDisplayMode displayMode)
        {
            SetDisplayModeTo(displayMode);
            return this;
        }

        public override Spinner Set(SpinnerProperty propertyName, String propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

        public override Spinner Set(Dictionary<SpinnerProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }

        public Spinner With(Func<Unit> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            this._units.Add(child);
            return this;
        }
    }
}
