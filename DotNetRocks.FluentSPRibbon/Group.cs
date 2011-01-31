using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class Group : InteractiveRibbonElement, IRibbonElementContainer<Group,InteractiveRibbonElement>
    {
        internal readonly IList<InteractiveRibbonElement> _interactiveRibbonElements;
        private readonly Dictionary<String, String> _controlsProperties;

        internal Group():this("NotSet")
        {
            
        }

        internal Group(string id) : base(id)
        {
            this._interactiveRibbonElements= new List<InteractiveRibbonElement>();
            this._controlsProperties = new Dictionary<string, string>();
        }

   
        public String Get(GroupProperty propertyKey)
        {
            return GetPropertyValue(propertyKey);
        }

        public Group Set(GroupProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey, value);
            return this;
        }

        public Group Set(Dictionary<GroupProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
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
                ApplyControlsProperty(property.Key, property.Value);
            }
            return this;
        }

        public InteractiveRibbonElement this[string id]
        {
            get { return _interactiveRibbonElements.FirstOrDefault(t => t.OriginalId == id); }
        }

        public int ChildItemCount
        {
            get { return _interactiveRibbonElements.Count; }
        }

        public Group With(Func<InteractiveRibbonElement> expression)
        {
            var suitableRibbonElement = expression.Invoke();
            suitableRibbonElement.Parent = this;
            this._interactiveRibbonElements.Add(suitableRibbonElement);
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
            _interactiveRibbonElements.ToList().ForEach(se=>
                                                   {
                                                       writer.WriteStartElement(se.XmlElementName);
                                                       se.WriteXml(writer);
                                                       writer.WriteEndElement();
                                                   });
            writer.WriteEndElement();

        }


        public String GetControlsProperty(string propertyName)
        {
            if (_controlsProperties.ContainsKey(propertyName))
                return _controlsProperties[propertyName];
            return String.Empty;
        }
    }
}