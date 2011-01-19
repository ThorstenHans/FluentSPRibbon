using System;
using System.Collections.Generic;
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
        internal Ribbon Ribbon
        {
            get { 
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
            set { 
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
        internal RibbonElementBase():this("NotSet")
        {
            
        }
        internal RibbonElementBase(String id)
        {
            _originalId = id;
            _properties=new Dictionary<string, string>();
          
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


        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Id",Id);
            foreach (var property in _properties)
            {
                writer.WriteAttributeString(property.Key,property.Value);
            }
            WriteChildren(writer);
        }

        protected virtual void WriteChildren(XmlWriter writer)
        {
            
        }
    }
}