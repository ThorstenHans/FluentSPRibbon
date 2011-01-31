using System;
using System.Collections.Generic;
using System.Linq;

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

        public String Get(SpinnerProperty propertyKey)
        {
            return GetPropertyValue(propertyKey);
        }

        public Spinner SetDisplayMode(DisplayMode displayMode)
        {
            SetDisplayModeTo(displayMode);
            return this;
        }

        public Spinner Set(SpinnerProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey, value);
            return this;
        }

        public Spinner Set(Dictionary<SpinnerProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}
