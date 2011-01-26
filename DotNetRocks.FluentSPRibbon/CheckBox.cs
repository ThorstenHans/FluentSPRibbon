using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class CheckBox : InteractiveRibbonElement
    {
        internal CheckBox() : this("NotSet")
        {
        }

        internal CheckBox(string id) : base(id)
        {
        }

        internal override string TagName
        {
            get { return "CheckBox"; }
        }

        public CheckBox ApplyProperty(String name, String value)
        {
            SetProperty(name,value);
            return this;
        }

        public CheckBox ApplyProperties(Dictionary<String,String> properties)
        {
            foreach (var property in properties)
            {
                SetProperty(property.Key,property.Value);
            }
            return this;
        }
    }
}