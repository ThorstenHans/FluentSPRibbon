using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class CommandUIHandler : RibbonElement<CommandUIHandler,CommandUIHandlerProperty>
    {
        internal CommandUIHandler() : this("NotSet") { }

        public CommandUIHandler(string id) : base(id)
        {
        }

        public override CommandUIHandler Set(CommandUIHandlerProperty propertyName, string propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

        public override CommandUIHandler Set(Dictionary<CommandUIHandlerProperty, string> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}