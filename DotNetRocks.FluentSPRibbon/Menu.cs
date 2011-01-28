using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class Menu :RibbonElement
    {
        internal Menu() :this("NotSet")
        {

        }

        internal Menu(String id) : base(id)
        {

        }

        public String GetProperty(MenuProperty propertyKey)
        {
            return GetPropertyValue(propertyKey.ToString());
        }

        public Menu SetProperty(MenuProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey.ToString(), value);
            return this;
        }

        public Menu SetProperties(Dictionary<MenuProperty, String> properties)
        {
            AddOrUpdateProperties(properties.ToDictionary(e=>e.Key.ToString(),e=>e.Value));
            return this;
        }

    }
}
