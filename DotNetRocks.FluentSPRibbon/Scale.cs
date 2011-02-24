using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class Scale : RibbonElement<Scale,ScaleProperty>
    {
        internal Scale() : this("NotSet") { }

        internal Scale(String id) : base(id) { }

        public new static Scale Create(String id, String groupId, String size)
        {
            var scale = RibbonElement<Scale>.Create(id);
            scale.Set(new Dictionary<ScaleProperty, string>
                          {
                              {ScaleProperty.GroupId, groupId},
                              {ScaleProperty.Size, size}
                          });
            return scale;
        }
        public override Scale Set(ScaleProperty propertyName, String propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

        public override Scale Set(Dictionary<ScaleProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key,property.Value);
            }
            return this;
        }
    }
}