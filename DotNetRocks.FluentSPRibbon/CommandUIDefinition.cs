using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class CommandUIDefinition : RibbonElement<CommandUIDefinition,CommandUIDefinitionProperty>
    {
         internal CommandUIDefinition() : this("NotSet") { }

         internal CommandUIDefinition(string id)
             : base(id)
        {
        }

        public static new CommandUIDefinition Create()
        {
            return RibbonElement<CommandUIDefinition>.Create("NotSet");
        }

        internal override bool IsIdProvider
        {
            get { return false; }
        }

         public override CommandUIDefinition Set(CommandUIDefinitionProperty propertyName, string propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

         public override CommandUIDefinition Set(Dictionary<CommandUIDefinitionProperty, string> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}