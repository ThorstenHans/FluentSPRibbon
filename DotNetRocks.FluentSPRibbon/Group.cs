using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class Group : InteractiveRibbonElement, IRibbonElementContainer<Group,InteractiveRibbonElement>
    {
        private readonly IList<InteractiveRibbonElement> _suitableElements;
        private readonly Dictionary<String, String> _controlsProperties;

        internal Group():this("NotSet")
        {
            
        }

        internal Group(string id) : base(id)
        {
            this._suitableElements= new List<InteractiveRibbonElement>();
            this._controlsProperties = new Dictionary<string, string>();
        }

   

        public Group ApplyProperty(String name, String value)
        {
            SetProperty(name, value);
            return this;
        }

        public Group ApplyProperties(Dictionary<String, String> properties)
        {
            SetProperties(properties);
            return this;
        }
        
        public Group ApplyControlsProperty(String name, String value)
        {
            if (this._controlsProperties.ContainsKey(name))
                this._controlsProperties[name] = value;
            else
                this._controlsProperties.Add(name,value);
            return this;
        }

        public Group ApplyControlsProperties(Dictionary<String, String> properties)
        {
            foreach (var property in properties)
            {
                ApplyProperty(property.Key, property.Value);
            }
            return this;
        }

        public InteractiveRibbonElement this[string id]
        {
            get { return _suitableElements.FirstOrDefault(t => t.OriginalId == id); }
        }

        public int ChildItemCount
        {
            get { return _suitableElements.Count; }
        }

        public Group With(Func<InteractiveRibbonElement> expression)
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
            foreach (var controlsProperty in _controlsProperties)
            {
                writer.WriteAttributeString(controlsProperty.Key,controlsProperty.Value);
            }
            _suitableElements.ToList().ForEach(se=>
                                                   {
                                                       writer.WriteStartElement(se.XmlElementName);
                                                       se.WriteXml(writer);
                                                       writer.WriteEndElement();
                                                   });
            writer.WriteEndElement();

        }

        
    }
}