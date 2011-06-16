using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class CommandUIHandler : RibbonElement<CommandUIHandler,CommandUIHandlerProperty>
    {
        internal CommandUIHandler() : this("NotSet") { }

        internal CommandUIHandler(string id) : base(id)
        {
        }

        public static new CommandUIHandler Create()
        {
            return RibbonElement<CommandUIHandler>.Create("NotSet");
        }

        internal override bool IsIdProvider
        {
            get { return false; }
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