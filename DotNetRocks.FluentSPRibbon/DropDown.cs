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

      

        public DropDown ApplyProperty(String name, String value)
        {
            SetProperty(name,value);
            return this;
        }

        public DropDown ApplyProperties(Dictionary<String,String> properties)
        {
            SetProperties(properties);
            return this;
        }
    }
}
