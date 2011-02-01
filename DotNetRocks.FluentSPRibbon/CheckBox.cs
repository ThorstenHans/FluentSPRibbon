using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class CheckBox : InteractiveRibbonElement<CheckBox, CheckBoxProperty, CheckBoxDisplayMode>
    {

        internal CheckBox() : this("NotSet")
        {
        }

        internal CheckBox(string id) : base(id)
        {
        }

        public override CheckBox SetDisplayMode(CheckBoxDisplayMode displayMode)
        {
            SetDisplayModeTo(displayMode);
            return this;
        }
      
        public override CheckBox Set(CheckBoxProperty propertyName, String propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

        public override CheckBox Set(Dictionary<CheckBoxProperty,String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}