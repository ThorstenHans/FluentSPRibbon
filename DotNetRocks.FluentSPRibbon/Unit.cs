using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class Unit : RibbonElement<Unit,UnitProperty>,
                        IRibbonElementContainer<Unit,UnitAbbreviation>
    {
        internal readonly IList<UnitAbbreviation> _unitAbbreviations;
        internal Unit() : this("NotSet"){ }

        internal Unit(String id) : base(id)
        {
            this._unitAbbreviations=new List<UnitAbbreviation>();
        }

        internal override bool  IsIdProvider
        { get { return false; } 
        }

        public override Unit Set(UnitProperty propertyName, string propertyValue)
        {
            AddOrUpdateProperty(propertyName,propertyValue);
            return this;
        }

        public override Unit Set(Dictionary<UnitProperty, string> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key,property.Value);
            }
            return this;
        }

        public Unit With(Func<UnitAbbreviation> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            this._unitAbbreviations.Add(child);
            return this;
        }
    }
}