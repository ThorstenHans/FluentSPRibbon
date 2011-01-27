using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetRocks.FluentSPRibbon
{
    public class FlyoutAnchor : InteractiveRibbonElement
    {
        internal FlyoutAnchor() : this("NotSet")
        {

        }

        internal FlyoutAnchor(String id) : base(id)
        {

        }


        public FlyoutAnchor ApplyProperty(String name, String value)
        {
            SetProperty(name,value);
            return this;
        }

        public FlyoutAnchor ApplyProperties(Dictionary<String,String> properties)
        {
            SetProperties(properties);
            return this;
        }
    }
}
