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

        public String GetProperty(SpinnerProperty propertyKey)
        {
            return GetPropertyValue(propertyKey.ToString());
        }
        public Spinner SetProperty(SpinnerProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey.ToString(), value);
            return this;
        }

        public Spinner SetProperties(Dictionary<SpinnerProperty, String> properties)
        {
            AddOrUpdateProperties(properties.ToDictionary(e=>e.Key.ToString(),e=>e.Value));
            return this;
        }
    }
}
