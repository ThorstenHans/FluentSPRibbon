using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class UnitAbbreviation :RibbonElement<UnitAbbreviation,UnitAbbreviationProperty>
    {
        internal UnitAbbreviation() : this("NotSet") { }

        internal UnitAbbreviation(string id) : base(id) { }

        public new static UnitAbbreviation Create(String id)
        {
            return RibbonElement<UnitAbbreviation>.Create(id);
        }

        internal override bool IsIdProvider
        {
            get { return false; }
        }
        public override UnitAbbreviation Set(UnitAbbreviationProperty propertyName, string propertyValue)
        {
            AddOrUpdateProperty(propertyName,propertyValue);
            return this;
        }

        public override UnitAbbreviation Set(Dictionary<UnitAbbreviationProperty, string> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key,property.Value);
            }
            return this;
        }
    }
}