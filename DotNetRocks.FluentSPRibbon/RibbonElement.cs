using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DotNetRocks.FluentSPRibbon
{
    public class RibbonElement : IRibbonElement
    {
        private readonly String _originalId;
        private Dictionary<String, String> _properties;

        internal RibbonElement():this("NotSet")
        {
            
        }

        internal RibbonElement(String id)
        {
            _originalId = id;
            _properties = new Dictionary<string, string>();
        }

        public String Id
        {
            get { return ResolveId(_originalId); }
        }

        internal RibbonElement Parent { get; set; }

        internal virtual String XmlElementName
        {
            get { return GetType().Name; }
        }

        internal string OriginalId
        {
            get { return this._originalId; }
        }

        internal void SetProperty(String name, String value)
        {
            if (_properties.ContainsKey(name))
                _properties[name] = value;
            else
                _properties.Add(name,value);
        }

        internal String GetProperty(String name)
        {
            if (_properties.ContainsKey(name))
                return _properties[name];
            return String.Empty;
        }

        private string ResolveId(string id)
        {
            return Parent != null ? String.Format("{0}.{1}", Parent.Id, id) : id;
        }

        public String ToXml()
        {
            var serializer = new XmlSerializer(GetType());
            String elementAsXml;
            using (var stream = new MemoryStream())
            {
                serializer.Serialize(stream, this);
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
            return;
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Id", Id);
            foreach (var transformedProperty in
                _properties.Select(RibbonSettings.ApplyResourceLink)
                    .Select(RibbonSettings.ApplyImagesFolder))
            {
                writer.WriteAttributeString(transformedProperty.Key, transformedProperty.Value);
            }
            WriteChildren(writer);
        }

        protected virtual void WriteChildren(XmlWriter writer)
        {

        }

        internal void SetProperties(Dictionary<String, String> properties)
        {
            this._properties = properties.Concat(this._properties).ToDictionary(e=>e.Key, e=>e.Value);
        }
    }
}
