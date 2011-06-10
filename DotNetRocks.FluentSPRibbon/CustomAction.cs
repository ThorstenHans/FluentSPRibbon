using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class CustomAction : InteractiveRibbonElement, 
        IRibbonElementContainer<CustomAction, CommandUIDefinition>,
        IRibbonElementContainer<CustomAction, CommandUIHandler>
    {
        private readonly IList<CommandUIDefinition> _commandUIDefinitions;
        private readonly IList<CommandUIHandler> _commandUIHandlers;

        internal CustomAction() : this("NotSet") { }

        internal CustomAction(string id) : base(id)
        {
            this._commandUIDefinitions = new List<CommandUIDefinition>();
            this._commandUIHandlers = new List<CommandUIHandler>();
        }


        internal override bool IsIdProvider
        {
            get { return true; }
        }

        internal override string XmlElementName
        {
            get { return "CustomAction"; }
        }

        public CustomAction RequiresFarmAdmin()
        {
            this.AddOrUpdateProperty(CustomActionProperty.RequiredAdmin,"Farm");
            return this;
        }

        public CustomAction RequiresMachineAdmin()
        {
            this.AddOrUpdateProperty(CustomActionProperty.RequiredAdmin, "Machine");
            return this;
        }

        public CustomAction RequiresDelegatedAdmin()
        {
            this.AddOrUpdateProperty(CustomActionProperty.RequiredAdmin, "Delegated");
            return this;
        }

        public CustomAction OnRootWebOnly()
        {
            this.AddOrUpdateProperty(CustomActionProperty.RootWebOnly, "TRUE");
            return this;
        }

        public CustomAction ShowInLists()
        {
            this.AddOrUpdateProperty(CustomActionProperty.ShowInLists,"TRUE");
            return this;
        }

        public CustomAction ShowInReadOnlyContentTypes()
        {
            this.AddOrUpdateProperty(CustomActionProperty.ShowInReadOnlyContentTypes, "TRUE");
            return this;
        }

        public CustomAction ShowInSealedContentTypes()
        {
            this.AddOrUpdateProperty(CustomActionProperty.ShowInSealedContentTypes, "TRUE");
            return this;
        }

        public CustomAction SetProperty(CustomActionProperty key, String value)
        {
            AddOrUpdateProperty(key, value);
            return this;
        }

        internal String GetProperty(CustomActionProperty propertyName)
        {
            return GetPropertyValue(propertyName);
        }

        public CustomAction SetProperties(Dictionary<CustomActionProperty, String> properties)
        {
            foreach (var property in properties)
            {
                SetProperty(property.Key, property.Value);
            }
            return this;
        }

        public CustomAction With(Func<CommandUIDefinition> expression)
        {
            var cuiDef = expression.Invoke();
            cuiDef.Parent = this;
            this._commandUIDefinitions.Add(cuiDef);
            return this;
        }

        public CustomAction With(Func<CommandUIHandler> expression)
        {
            var cuiHandler = expression.Invoke();
            cuiHandler.Parent = this;
            this._commandUIHandlers.Add(cuiHandler);
            return this;
        }
    }
}
