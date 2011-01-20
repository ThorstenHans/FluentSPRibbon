using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DotNetRocks.FluentSPRibbon
{
    public abstract class RibbonElementBase : IXmlSerializable
    {
        private readonly Dictionary<string, string> _properties;

        private readonly string _originalId;
        private RibbonElementBase _parent;

        internal RibbonElementBase()
            : this("NotSet")
        {

        }

        internal RibbonElementBase(String id)
        {
            _originalId = id;
            _properties = new Dictionary<string, string>();

        }

        internal Ribbon Ribbon
        {
            get
            {
                var parent = Parent;
                while (parent != null && parent as Ribbon == null)
                {
                    parent = parent.Parent;
                }
                if (parent == null)
                    return null;
                return parent as Ribbon;
            }
        }

        internal RibbonElementBase Parent
        {
            get { return _parent; }
            set
            {
                _parent = value;

            }
        }

        internal String OriginalId
        {
            get
            {
                return this._originalId;
            }
        }


        private string ResolveId(string id)
        {
            if (Parent != null)
                return String.Format("{0}.{1}", Parent.Id, id);
            return id;
        }


        public String Id
        {
            get { return ResolveId(_originalId); }
        }

        protected void SetPropertyTo(string name, string value)
        {
            if (_properties.ContainsKey(name))
                _properties[name] = value;
            else
                _properties.Add(name, value);
        }

        public string GetProperty(string name)
        {
            if (!_properties.ContainsKey(name))
                return String.Empty;
            return _properties[name];
        }

        public String ToXml()
        {
            var serializer = new XmlSerializer(this.GetType());
            String elementAsXml = String.Empty;
            using (var stream = new MemoryStream())
            {
                serializer.Serialize(stream,this);
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    elementAsXml = reader.ReadToEnd();
                }
            }
            
            return elementAsXml;
        }


        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
           
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Id", Id);
            foreach (var property in _properties)
            {
                var transformedProperty = RibbonSettings.ApplyResourceLink(property);
                transformedProperty = RibbonSettings.ApplyImagesFolder(transformedProperty);
                writer.WriteAttributeString(transformedProperty.Key, transformedProperty.Value);
            }
            WriteChildren(writer);
        }

        protected virtual void WriteChildren(XmlWriter writer)
        {

        }
    }
}