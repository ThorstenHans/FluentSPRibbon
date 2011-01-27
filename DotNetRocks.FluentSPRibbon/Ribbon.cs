using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace DotNetRocks.FluentSPRibbon
{
    public class Ribbon : InteractiveRibbonElement, IRibbonElementContainer<Ribbon,Tab>
    {
        private readonly IList<Tab> _tabs;
      
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

        public Ribbon ApplyProperty(String name, String value)
        {
            SetProperty(name, value);
            return this;
        }

        public Ribbon ApplyProperties(Dictionary<String, String> properties)
        {
            SetProperties(properties);
            return this;
        }

        public int ChildItemCount
        {
            get { return _tabs.Count; }
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