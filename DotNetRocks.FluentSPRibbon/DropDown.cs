using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class DropDown : InteractiveRibbonElement
    {
        internal DropDown() : this("NotSet") { }

        internal DropDown(String id) :base(id) { }

        public String GetProperty(DropDownProperty propertyKey)
        {
            return GetProperty(propertyKey.ToString());
        }

        public DropDown ApplyProperty(DropDownProperty propertyKey, String value)
        {
            SetProperty(propertyKey.ToString(),value);
            return this;
        }

        public DropDown ApplyProperties(Dictionary<DropDownProperty,String> properties)
        {
            SetProperties(properties.ToDictionary(e=>e.Key.ToString(), e=>e.Value));
            return this;
        }
    }
}
