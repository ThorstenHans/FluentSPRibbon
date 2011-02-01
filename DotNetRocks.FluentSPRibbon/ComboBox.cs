using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DotNetRocks.FluentSPRibbon
{
    public class ComboBox : InteractiveRibbonElement<ComboBox,ComboBoxProperty,ComboBoxDisplayMode>, 
        IRibbonElementContainer<ComboBox,Menu>
    {
        private Menu _menu;

        internal ComboBox() : this("NotSet"){ }

        internal ComboBox(String id) : base(id){ }
 
        public override ComboBox SetDisplayMode(ComboBoxDisplayMode displayMode)
        {
            SetDisplayModeTo(displayMode);
            return this;
        }

        public override ComboBox Set(ComboBoxProperty propertyName, String propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

        [XmlElement("Menu")]
        public Menu Menu
        {
            get { return this._menu; }
        }

        public override ComboBox Set(Dictionary<ComboBoxProperty,String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }

        public ComboBox With(Func<Menu> expression)
        {
            var menu = expression.Invoke();
            menu.Parent = this;
            this._menu = menu;
            return this;
        }
        protected override void WriteChildren(System.Xml.XmlWriter writer)
        {
            if (this._menu != null)
            {
                writer.WriteStartElement("Menu");
                this._menu.WriteXml(writer);
                writer.WriteEndElement();


            }
        }
    }
}
