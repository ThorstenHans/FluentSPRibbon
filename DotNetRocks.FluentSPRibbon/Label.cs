using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class Label : InteractiveRibbonElement
    {
        internal Label():this("NotSet")
        {
            
        }

        internal Label(string id) : base(id)
        {
        }

  
        public Label ApplyProperty(String name, String value)
        {
            SetProperty(name, value);
            return this;
        }

        public Label ApplyProperties(Dictionary<String, String> properties)
        {
            SetProperties(properties);
            return this;
        }
    }
}