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

        internal override string TagName
        {
            get { return "Label"; }
        }

        public Label ApplyProperty(String name, String value)
        {
            SetProperty(name, value);
            return this;
        }

        public Label ApplyProperties(Dictionary<String, String> properties)
        {
            foreach (var property in properties)
            {
                SetProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}