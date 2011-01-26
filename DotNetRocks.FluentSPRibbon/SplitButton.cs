using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        internal override string TagName
        {
            get { return "SplitButton"; }
        }

        public SplitButton ApplyProperty(String name, String value)
        {
            SetProperty(name, value);
            return this;
        }

        public SplitButton ApplyProperties(Dictionary<String, String> properties)
        {
            foreach (var property in properties)
            {
                SetProperty(property.Key, property.Value);
            }
            return this;
        }
       
    }
}
