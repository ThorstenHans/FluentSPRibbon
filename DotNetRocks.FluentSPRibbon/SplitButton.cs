using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class SplitButton : InteractiveRibbonElement
    {
        internal SplitButton() : this("NotSet")
        {
            
        }

        internal SplitButton(String id) : base(id)
        {
            
        }

        public String GetProperty(SplitButtonProperty propertyKey)
        {
            return GetProperty(propertyKey.ToString());
        }

        public SplitButton ApplyProperty(SplitButtonProperty propertyKey, String value)
        {
            SetProperty(propertyKey.ToString(), value);
            return this;
        }

        public SplitButton ApplyProperties(Dictionary<SplitButtonProperty, String> properties)
        {
            SetProperties(properties.ToDictionary(e=>e.Key.ToString(),e=>e.Value));
            return this;
        }
       
    }
}
