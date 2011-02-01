using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace DotNetRocks.FluentSPRibbon
{
    public class Ribbon : RibbonElement<Ribbon,RibbonProperty>, IRibbonElementContainer<Ribbon,Tab>
    {
        internal readonly IList<Tab> _tabs;
      
        public Tab this[string id]
        {
            get { return _tabs.FirstOrDefault(t => t.OriginalId == id); }
        }

        internal Ribbon():this("NotSet")
        {
            
        }
        internal Ribbon(string id) : base(id)
        {
            this._tabs = new List<Tab>();
      
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
        }


        public String BuildTemplateXml()
        {
            return String.Empty;
        }
    }
}