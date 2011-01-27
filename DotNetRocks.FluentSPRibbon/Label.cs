using System;
using System.Collections.Generic;
using System.Linq;

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

        public String GetProperty(LabelProperty propertyKey)
        {
            return GetProperty(propertyKey.ToString());
        }
  
        public Label ApplyProperty(LabelProperty propertyKey, String value)
        {
            SetProperty(propertyKey.ToString(), value);
            return this;
        }

        public Label ApplyProperties(Dictionary<LabelProperty, String> properties)
        {
            SetProperties(properties.ToDictionary(e=>e.Key.ToString(),e=>e.Value));
            return this;
        }
    }
}