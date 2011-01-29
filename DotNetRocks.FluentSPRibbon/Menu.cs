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
            return GetPropertyValue(propertyKey);
        }

        public Menu SetProperty(MenuProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey, value);
            return this;
        }

        public Menu SetProperties(Dictionary<MenuProperty, String> properties)
        {
            foreach (var property in properties)
            {
                SetProperty(property.Key, property.Value);
            }
            return this;
        }

    }
}
