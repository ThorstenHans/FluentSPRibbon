using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class MRUSplitButton : InteractiveRibbonElement
    {
        internal MRUSplitButton()  : this("NotSet")
        {
            
        }

        internal MRUSplitButton(String id)
            : base(id)
        {
            
        }

        public String GetProperty(MRUProperty propertyKey)
        {
            return GetProperty(propertyKey.ToString());
        }
    

        public MRUSplitButton ApplyProperty(MRUProperty propertyKey, String value)
        {
            SetProperty(propertyKey.ToString(), value);
            return this;
        }

        public MRUSplitButton ApplyProperties(Dictionary<MRUProperty, String> properties)
        {
            SetProperties(properties.ToDictionary(e=>e.Key.ToString(),e=>e.Value));
            return this;
        }
    }
}
