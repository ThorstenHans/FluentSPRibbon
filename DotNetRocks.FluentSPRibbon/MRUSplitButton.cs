using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    

        public MRUSplitButton ApplyProperty(String name, String value)
        {
            SetProperty(name, value);
            return this;
        }

        public MRUSplitButton ApplyProperties(Dictionary<String, String> properties)
        {
            SetProperties(properties);
            return this;
        }
    }
}
