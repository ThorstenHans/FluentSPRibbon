using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class CommandUIExtension : RibbonElement<CommandUIExtension, CommandUIExtensionProperty>
    {
        internal CommandUIExtension() : this("NotSet") { }

        public CommandUIExtension(string id) : base(id)
        {
        }

        public override CommandUIExtension Set(CommandUIExtensionProperty propertyName, string propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

        public override CommandUIExtension Set(Dictionary<CommandUIExtensionProperty, string> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}