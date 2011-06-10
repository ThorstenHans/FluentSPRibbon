using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace DotNetRocks.FluentSPRibbon
{
    public class Ribbon : RibbonElement<Ribbon,RibbonProperty>, 
        IRibbonElementContainer<Ribbon,Tab>,
        IRibbonElementContainer<Ribbon, ContextualGroup>
    {
        internal readonly IList<Tab> _tabs;
        internal readonly IList<ContextualGroup> _contextualGroups;
      
        public Tab this[string id]
        {
            get { return _tabs.FirstOrDefault(t => t.OriginalId == id); }
        }

        public new static Ribbon Create(String id)
        {
            return RibbonElement<Ribbon>.Create(id);
        }

        internal Ribbon():this("NotSet")
        {
            
        }
        internal Ribbon(string id) : base(id)
        {
            this._tabs = new List<Tab>();
            this._contextualGroups = new List<ContextualGroup>();
      
        }

        public override Ribbon Set(RibbonProperty propertyName, String propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

        public override Ribbon Set(Dictionary<RibbonProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
         
        public Ribbon With(Func<Tab> expression)
        {
            var tab = expression.Invoke();
            tab.Parent = this;
            this._tabs.Add(tab);
            return this;
        }

        public Ribbon With(Func<ContextualGroup> expression)
        {
            var contextualGroup = expression.Invoke();
            contextualGroup.Parent = this;
            this._contextualGroups.Add(contextualGroup);
            return this;
        }

        protected override void WriteChildren(XmlWriter writer)
        {
            writer.WriteStartElement("Tabs");
            writer.WriteAttributeString("Id", String.Concat(Id,".TabsContainer"));
            _tabs.ToList().ForEach(t=>
                                       {
                                           writer.WriteStartElement("Tab");
                                           t.WriteXml(writer);
                                           writer.WriteEndElement();
                                       });
            writer.WriteEndElement();
            writer.WriteStartElement("ContextualTabs");
            writer.WriteAttributeString("Id", String.Concat(Id,".ContextualTabs"));
            _contextualGroups.ToList().ForEach(cg=>
                                                   {
                                                       writer.WriteStartElement("ContextualGroup");
                                                       cg.WriteXml(writer);
                                                       writer.WriteEndElement();

                                                   });
            writer.WriteEndElement();
        }


        public String BuildTemplateXml()
        {
            return String.Empty;
        }
    }
}