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
            return GetProperty(propertyKey.ToString());
        }
        public Spinner ApplyProperty(SpinnerProperty propertyKey, String value)
        {
            SetProperty(propertyKey.ToString(), value);
            return this;
        }

        public Spinner ApplyProperties(Dictionary<SpinnerProperty, String> properties)
        {
            SetProperties(properties.ToDictionary(e=>e.Key.ToString(),e=>e.Value));
            return this;
        }
    }
}
