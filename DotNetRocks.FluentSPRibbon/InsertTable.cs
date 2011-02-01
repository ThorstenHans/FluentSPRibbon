using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class InsertTable :InteractiveRibbonElement<InsertTable,InsertTableProperty,InsertTableDisplayMode>
    {
         internal InsertTable() : this("NotSet") { }

         internal InsertTable(string id) : base(id) { }

         public override InsertTable Set(InsertTableProperty propertyName, String propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

         public override InsertTable Set(Dictionary<InsertTableProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }

        public override InsertTable SetDisplayMode(InsertTableDisplayMode displayMode)
        {
            SetDisplayModeTo(displayMode);
            return this;
        }
    }
}