using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class Menu :RibbonElement<Menu,MenuProperty>, IRibbonElementContainer<Menu,MenuSection>
    {
        internal readonly IList<MenuSection> _menuSections;
        internal Menu() :this("NotSet")
        {

        }

        internal Menu(String id) : base(id)
        {
            _menuSections=new List<MenuSection>();
        }

    

        public MenuSection this[string id]
        {
            get { return _menuSections.FirstOrDefault(ms => ms.OriginalId == id); }
        }

        public Menu With(Func<MenuSection> expression)
        {
            var menuSection = expression.Invoke();
            menuSection.Parent = this;
            this._menuSections.Add(menuSection);
            return this;
        }

        public override Menu Set(MenuProperty propertyName, string propertyValue)
        {
            AddOrUpdateProperty(propertyName,propertyValue);
            return this;
        }

        public override Menu Set(Dictionary<MenuProperty, string> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key,property.Value);
            }
            return this;
        }

        protected override void WriteChildren(System.Xml.XmlWriter writer)
        {
            foreach (var menuSection in _menuSections)
            {
                writer.WriteStartElement(menuSection.XmlElementName);
                menuSection.WriteXml(writer);
                writer.WriteEndElement();
            }
        }
    }
}
