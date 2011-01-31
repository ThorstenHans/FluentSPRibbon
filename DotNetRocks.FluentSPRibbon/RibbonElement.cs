using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DotNetRocks.FluentSPRibbon
{
    public class RibbonElement: IRibbonElement 
    {
        private readonly String _originalId;
        private Dictionary<Enum, String> _properties;

        internal RibbonElement():this("NotSet")
        {
            
        }

        internal RibbonElement(String id)
        {
            _originalId = id;
            _properties = new Dictionary<Enum, string>();
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

        internal virtual bool IsIdProvider
        {
            get { return true; }
        }

        internal string OriginalId
        {
            get { return this._originalId; }
        }


        internal void AddOrUpdateProperty(Enum name, String value)
        {
            if (_properties.ContainsKey(name))
                _properties[name] = value;
            else
                _properties.Add(name,value);
        }

        internal String GetPropertyValue(Enum name)
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

        }

        public void WriteXml(XmlWriter writer)
        {
            if(IsIdProvider)
                writer.WriteAttributeString("Id", Id);
            foreach (var transformedProperty in
                _properties.Select(RibbonSettings.ApplyResourceLink)
                    .Select(RibbonSettings.ApplyImagesFolder))
            {
                writer.WriteAttributeString(transformedProperty.Key.ToString(), 
                    transformedProperty.Value);
            }
            WriteChildren(writer);
        }

        protected virtual void WriteChildren(XmlWriter writer)
        {

        }        

    }
}
