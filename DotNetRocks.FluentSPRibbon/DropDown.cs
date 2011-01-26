using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetRocks.FluentSPRibbon
{
    public class DropDown : InteractiveRibbonElement
    {
        internal DropDown() : this("NotSet")
        {
            
        }

        internal DropDown(String id) :base(id)
        {
            
        }

        internal override string TagName
        {
            get { return "DropDown"; }
        }

        public DropDown ApplyProperty(String name, String value)
        {
            SetProperty(name,value);
            return this;
        }

        public DropDown ApplyProperties(Dictionary<String,String> properties)
        {
            foreach (var property in properties)
            {
                SetProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}
