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
            return GetProperty(propertyKey.ToString());
        }

        public Menu ApplyProperty(MenuProperty propertyKey, String value)
        {
            SetProperty(propertyKey.ToString(), value);
            return this;
        }

        public Menu ApplyProperties(Dictionary<MenuProperty, String> properties)
        {
            SetProperties(properties.ToDictionary(e=>e.Key.ToString(),e=>e.Value));
            return this;
        }

    }
}
