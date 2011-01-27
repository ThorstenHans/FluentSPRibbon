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

        public ToggleButton ApplyProperty(String name, String value)
        {
            SetProperty(name, value);
            return this;
        }

        public ToggleButton ApplyProperties(Dictionary<String, String> properties)
        {
            SetProperties(properties);
            return this;
        }
    }
}