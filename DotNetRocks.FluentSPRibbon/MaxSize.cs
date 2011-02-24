using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class MaxSize : RibbonElement<MaxSize,MaxSizeProperty>
    {
        internal MaxSize() : this("NotSet") { }

        internal MaxSize(string id) : base(id) { }

        public new static MaxSize Create(String id, String groupId, String size)
        {
            var maxSize = RibbonElement<MaxSize>.Create(id);
            maxSize.Set(new Dictionary<MaxSizeProperty, string>
                            {
                                {MaxSizeProperty.GroupId, groupId},
                                {MaxSizeProperty.Size, size}
                            });
            return maxSize;
        }

        public override  MaxSize Set(MaxSizeProperty propertyName, String propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

        public override MaxSize Set(Dictionary<MaxSizeProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}