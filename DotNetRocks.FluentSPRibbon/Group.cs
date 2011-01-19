using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class Group : RibbonElementBase, IRibbonElementContainer<Group,SuitableRibbonElement>, ITemplateProvider<Group>
    {
        internal event EventHandler<TemplateActionRequiredEventArgs> TemplateActionRequired;
        private readonly IList<SuitableRibbonElement> _suitableElements;
        private string _templateId;

        internal Group():this("NotSet")
        {
            
        }
        internal Group(string id) : base(id)
        {
            this._suitableElements= new List<SuitableRibbonElement>();
        }

        internal String TemplateId
        {
            get { return String.Format("{0}.{1}", this.Id, _templateId); }
        }
        public new Group SetPropertyTo(string name, string value)
        {
            base.SetPropertyTo(name,value);
            return this;
        }

        public SuitableRibbonElement this[string id]
        {
            get { return _suitableElements.FirstOrDefault(t => t.OriginalId == id); }
        }

        public int ChildItemCount
        {
            get { return _suitableElements.Count; }
        }

        public Group With(Func<SuitableRibbonElement> expression)
        {
            var suitableRibbonElement = expression.Invoke();
            suitableRibbonElement.Parent = this;
            this._suitableElements.Add(suitableRibbonElement);
            return this;
        }

        protected override void WriteChildren(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("Controls");
            writer.WriteAttributeString("Id", Id+".ControlsContainer");
            _suitableElements.ToList().ForEach(se=>
                                                   {
                                                       writer.WriteStartElement(se.TagName);
                                                       se.WriteXml(writer);
                                                       writer.WriteEndElement();
                                                   });
            writer.WriteEndElement();

        }

        private void FireTemplateActionRequired()
        {
            if(TemplateActionRequired!=null)
                this.TemplateActionRequired(this, new TemplateActionRequiredEventArgs()
                                                      {
                                                          ControlTemplateAlias = String.Empty,
                                                          TemplateId = this.TemplateId
                                                      });
        }

        public Group SetTemplate(string templateId)
        {
            this._templateId = templateId;
            this.SetPropertyTo("Template", this.TemplateId);
            FireTemplateActionRequired();
            return this;
        }
    }
}