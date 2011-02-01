using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class ColorPicker 
        : InteractiveRibbonElement<ColorPicker,ColorPickerProperty,ColorPickerDisplayMode>, 
        IRibbonElementContainer<ColorPicker,Color>
    {
        internal readonly IList<Color> _colors;

        internal ColorPicker():this("NotSet") { }

        internal ColorPicker(String id) : base(id)
        {
            _colors=new List<Color>();
        }
 
        public override ColorPicker SetDisplayMode(ColorPickerDisplayMode displayMode)
        {
            SetDisplayModeTo(displayMode);
            return this;
        }

        public override ColorPicker Set(ColorPickerProperty propertyName, String propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

        public override ColorPicker Set(Dictionary<ColorPickerProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
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
