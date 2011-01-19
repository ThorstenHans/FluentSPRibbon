using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DotNetRocks.FluentSPRibbon
{
    public class Ribbon : RibbonElementBase, IRibbonElementContainer<Ribbon,Tab>
    {
        private readonly IList<Tab> _tabs;
        private readonly IList<GroupTemplate> _templates;

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
            this._templates = new List<GroupTemplate>();
        }

        public new Ribbon SetPropertyTo(string name, string value)
        {
            base.SetPropertyTo(name,value);
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


        public void DoTemplateAction(object sender, TemplateActionRequiredEventArgs e)
        {
            if (String.IsNullOrEmpty(e.ControlTemplateAlias))
            {
                this._templates.Add(Create<GroupTemplate>.Instance(e.TemplateId));
            }
            else
            {
                var template = this._templates.First(t => t.Id == e.TemplateId);

            }
        }
    }

    internal class GroupTemplate : RibbonElementBase, IRibbonElement<GroupTemplate>
    {
        private readonly Layout _layout;
        public GroupTemplate():this("NotSet")
        {
            
        }
        public GroupTemplate(string id) : base(id)
        {
            this._layout=new Layout();
        }

        public GroupTemplate SetPropertyTo(string name, string value)
        {
            base.SetPropertyTo(name, value);
            return this;
        }
    }

    internal class Layout: RibbonElementBase, IRibbonElement<Layout>
    {

        public Layout():this("NotSet","NotSet")
        {
            
        }

        public Layout(String title,String layoutTitle)
        {
            SetPropertyTo(LayoutProperties.Title, title);
            SetPropertyTo(LayoutProperties.LayoutTitle, layoutTitle);
        }
        public Layout SetPropertyTo(string name, string value)
        {
            base.SetPropertyTo(name,value);
            return this;
        }
    }

    public class LayoutProperties
    {
        public const String Title = "Title";
        public const String LayoutTitle = "LayoutTitle";
    }
}