using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Xml;
using System.Xml.Schema;

namespace DotNetRocks.FluentSPRibbon
{
    public abstract class TemplateElement<T, TPropertyEnum, TDisplayModeEnum>:IRibbonElement
    {
        protected readonly Dictionary<Enum, String> _properties;

        protected const String DisplayModeKey = "DisplayMode";
        private String _id;
        internal TemplateElement() :this("NotSet")
        {
            
        }

        internal TemplateElement(String id)
        {
            _id = id;
            _properties = new Dictionary<Enum, String>();

        }

        protected static T Create(String id)
        {
            var type = typeof(T);
            var constructor = type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy, null, new Type[] { typeof(String) }, null);
            return (T)constructor.Invoke(BindingFlags.NonPublic, null, new[] { id }, Thread.CurrentThread.CurrentCulture);

        }


        public abstract T Set(TPropertyEnum propertyName, String propertyValue);
        public abstract T Set(Dictionary<TPropertyEnum, String> properties);
        public abstract T SetDisplayMode(TDisplayModeEnum displayMode);
        public abstract TDisplayModeEnum GetDisplayMode();

        protected void AddOrUpdateProperty(TPropertyEnum propertyName, String propertyValue)
        {
            if (propertyName is Enum)
            {
                if(this._properties.ContainsKey(propertyName as Enum))
                    this._properties[(propertyName as Enum)] = propertyValue;
                else
                    this._properties.Add((propertyName as Enum),propertyValue   );
            }
        }
        public String GetProperty(TPropertyEnum propertName)
        {
            if (propertName is Enum)
            {
                if (_properties.ContainsKey((propertName as Enum)))
                    return this._properties[propertName as Enum];
            }
            return String.Empty;
        }


        protected void SetDisplayModeTo(String displayMode)
        {
            if (this._properties.ContainsKey(TemplateProperty.DisplayMode))
                this._properties[TemplateProperty.DisplayMode] = displayMode.ToString();
            else
                this._properties.Add(TemplateProperty.DisplayMode,displayMode.ToString());
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
            
        }

        public string Id
        {
            get { return this._id; }
        }

        public virtual String XmlElementName
        {
            get { return GetType().Name; }
        }


        public string ToXml()
        {
            return String.Empty;
        }
    }
}
