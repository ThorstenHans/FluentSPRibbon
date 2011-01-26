using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class Spinner : InteractiveRibbonElement
    {
        internal Spinner() : this("NotSet")
        {

        }

        internal Spinner(String id) : base(id)
        {

        }

        internal override string TagName
        {
            get { return "Spinner"; }
        }

        public Spinner ApplyProperty(String name, String value)
        {
            SetProperty(name, value);
            return this;
        }

        public Spinner ApplyProperties(Dictionary<String, String> properties)
        {
            foreach (var property in properties)
            {
                SetProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}
