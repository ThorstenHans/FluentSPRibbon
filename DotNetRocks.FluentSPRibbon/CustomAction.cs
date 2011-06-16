using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class CustomAction : RibbonElement<CustomAction,CustomActionProperty>, 
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

        public static new CustomAction Create(String id)
        {
            return RibbonElement<CustomAction>.Create(id);
        }


        internal override bool IsIdProvider
        {
            get { return true; }
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

        public override CustomAction Set(CustomActionProperty propertyName, string propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

        public override CustomAction Set(Dictionary<CustomActionProperty, string> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }

        protected override void WriteChildren(System.Xml.XmlWriter writer)
        {
            if (this._commandUIDefinitions.Count > 0 || this._commandUIHandlers.Count > 0)
            {
                writer.WriteStartElement("CommandUIExtension");
                if (_commandUIDefinitions.Count > 0)
                {
                    writer.WriteStartElement("CommandUIDefinitions");
                    _commandUIDefinitions.ToList().ForEach(cuid =>
                                                               {
                                                                   writer.WriteStartElement("CommandUIDefinition");
                                                                   cuid.WriteXml(writer);
                                                                   writer.WriteEndElement();
                                                               });
                    writer.WriteEndElement();
                }

                if(_commandUIHandlers.Count>0)
                {
                    writer.WriteStartElement("CommandUIHandlers");
                    _commandUIHandlers.ToList().ForEach(cuih=>
                                                            {
                                                                writer.WriteStartElement("CommandUIHandler");
                                                                cuih.WriteXml(writer);
                                                                writer.WriteEndElement();
                                                            });
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }
    }
}
