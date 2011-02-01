using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class Spinner : InteractiveRibbonElement<Spinner,SpinnerProperty,SpinnerDisplayMode>
    {
        internal Spinner() : this("NotSet")
        {

        }

        internal Spinner(String id) : base(id)
        {

        }

        public override Spinner SetDisplayMode(SpinnerDisplayMode displayMode)
        {
            SetDisplayModeTo(displayMode);
            return this;
        }

        public override Spinner Set(SpinnerProperty propertyName, String propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

        public override Spinner Set(Dictionary<SpinnerProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}
