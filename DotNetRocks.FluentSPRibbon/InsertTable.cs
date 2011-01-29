using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class InsertTable : RibbonElement
    {
         internal InsertTable() : this("NotSet") { }

         internal InsertTable(string id) : base(id) { }

         public String GetProperty(InsertTableProperty propertyKey)
        {
            return GetPropertyValue(propertyKey);
        }

         public InsertTable SetProperty(InsertTableProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey, value);
            return this;
        }

         public InsertTable SetProperties(Dictionary<InsertTableProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}