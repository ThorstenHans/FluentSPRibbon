using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DotNetRocks.FluentSPRibbon
{
    public abstract class RibbonElement<T> : IRibbonElement, IIdSetter
    {
        protected String _originalId;
        protected Dictionary<Enum, String> _properties;

        protected static T Create(String id) 
        {
            var type = typeof(T);
            var constructor = type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy, null, new Type[] { typeof(String) }, null);
            return (T)constructor.Invoke(BindingFlags.NonPublic, null, new[] { id }, Thread.CurrentThread.CurrentCulture);
            
        }

        

        public virtual String XmlElementName
        {
            get { return GetType().Name; }
        }

        internal virtual bool IsIdProvider
        {
            get { return true; }
        }

        internal RibbonElement(String id)
        {
            _originalId = id;
            _properties = new Dictionary<Enum, string>();
        }

        internal IRibbonElement Parent { get; set; }

     
        public String Id
        {
            get { return ResolveId(_originalId); }
             
        }

        internal string OriginalId
        {
            get { return this._originalId; }
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

        public void WriteTo(String path)
        {
            File.WriteAllText(Path.Combine(@"..\..\", path), ToXml());
        }

        public void WriteTo(CustomPath customPath)
        {
            WriteTo(customPath.Path);
        }

        public Stream WriteTo(Stream stream)
        {
            var ribbonXml = ToXml();
            var ribbonXmlAsBytes = System.Text.Encoding.UTF8.GetBytes(ribbonXml);
            stream.Write(ribbonXmlAsBytes,0,ribbonXmlAsBytes.Length);

            return stream;
        }

        public void WriteXml(XmlWriter writer)
        {
            if (IsIdProvider)
                writer.WriteAttributeString("Id", Id);

            foreach (var transformedProperty in  _properties
                    .Select(RibbonSettings.ApplyResourceLink)
                    .Select(RibbonSettings.ApplyImagesFolder)
                    .Select(RibbonSettings.ApplyUrlEncoding)
                    .Select(RibbonSettings.ApplyHtmlEncoding))
            {
                writer.WriteAttributeString(transformedProperty.Key.ToString(),
                    transformedProperty.Value);
            }
            WriteChildren(writer);
        }

        protected virtual void WriteChildren(XmlWriter writer)
        {

        }

        public void SetIdTo(string newId)
        {
            this._originalId = newId;
        }
    }

    public abstract class RibbonElement<T, TPropertyEnum>: RibbonElement<T>
    {
        internal RibbonElement(String id):base(id)
        {
        
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
            return _properties.ContainsKey(name) ? _properties[name] : String.Empty;
        }

        public abstract T Set(TPropertyEnum propertyName, String propertyValue);
        public abstract T Set(Dictionary<TPropertyEnum, String> properties);

        public String Get(TPropertyEnum propertyName)
        {
            if(propertyName is Enum)
            {
                if (this._properties.ContainsKey((propertyName as Enum)))
                   return this._properties[(propertyName as Enum)];
            }
            return String.Empty;

        }
    
     
        

    }
}
