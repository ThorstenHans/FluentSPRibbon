using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetRocks.FluentSPRibbon
{
    public class ComboBox : InteractiveRibbonElement
    {
        internal ComboBox() : this("NotSet")
        {
            
        }

        internal ComboBox(String id) : base(id)
        {
            
        }

        internal override string TagName
        {
            get { return "ComboBox"; }
        }

        public ComboBox ApplyProperty(String name, String value)
        {
            SetProperty(name,value);
            return this;
        }

        public ComboBox ApplyProperties(Dictionary<String,String> properties)
        {
            foreach (var property in properties)
            {
                SetProperty(property.Key,property.Value);
            }
            return this;
        }
    }
}
