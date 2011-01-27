using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

      
        public Menu ApplyProperty(String name, String value)
        {
            SetProperty(name, value);
            return this;
        }

        public Menu ApplyProperties(Dictionary<String, String> properties)
        {
            SetProperties(properties);
            return this;
        }

    }
}
