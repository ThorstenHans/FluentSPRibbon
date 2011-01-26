using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class ToggleButton: InteractiveRibbonElement
    {
        internal ToggleButton() : this("NotSet"){}

        internal ToggleButton(string id) : base(id)
        {
        }

        internal override string TagName
        {
            get { return "ToggleButton"; }
        }

        public ToggleButton ApplyProperty(String name, String value)
        {
            SetProperty(name, value);
            return this;
        }

        public ToggleButton ApplyProperties(Dictionary<String, String> properties)
        {
            foreach (var property in properties)
            {
                SetProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}