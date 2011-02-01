using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public abstract class TemplateElement<T, TPropertyEnum, TDisplayModeEnum>
    {
        protected readonly Dictionary<Enum, String> _properties;

        protected const String DisplayModeKey = "DisplayMode";

        public TemplateElement()
        {
            _properties=new Dictionary<Enum, String>();
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
    }
}
