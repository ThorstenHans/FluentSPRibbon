using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class Group : RibbonElementBase, IRibbonElementContainer<Group,SuitableRibbonElement>
    {
        private readonly IList<SuitableRibbonElement> _suitableElements;
        private string _templateId;

        internal Group():this("NotSet")
        {
            
        }
        internal Group(string id) : base(id)
        {
            this._suitableElements= new List<SuitableRibbonElement>();
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

        
    }
}