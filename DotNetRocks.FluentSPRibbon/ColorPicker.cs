using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class ColorPicker 
        : InteractiveRibbonElement, IRibbonElementContainer<ColorPicker,Color>
    {
        private readonly IList<Color> _colors;
        internal ColorPicker():this("NotSet") { }

        internal ColorPicker(String id) : base(id)
        {
            _colors=new List<Color>();
        }

        public String GetProperty(ColorPickerProperty propertyKey)
        {
            return GetProperty(propertyKey.ToString());
        }

        public ColorPicker ApplyProperty(ColorPickerProperty propertyKey, String value)
        {
            SetProperty(propertyKey.ToString(),value);
            return this;
        }

        public ColorPicker ApplyProperties(Dictionary<ColorPickerProperty, String> properties)
        {
            SetProperties(properties.ToDictionary(e=>e.Key.ToString(),e=>e.Value));
            return this;
        }

        public Color this[string id]
        {
            get { return _colors.FirstOrDefault(c => c.OriginalId == id); }
        }

        public ColorPicker With(Func<Color> expression)
        {
            var color = expression.Invoke();
            color.Parent = this;
            this._colors.Add(color);
            return this;
        }

        protected override void WriteChildren(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("Colors");
            _colors.ToList().ForEach(color =>
            {
                writer.WriteStartElement(color.XmlElementName);
                color.WriteXml(writer);
                writer.WriteEndElement();
            });
            writer.WriteEndElement();
        }
    }
}
