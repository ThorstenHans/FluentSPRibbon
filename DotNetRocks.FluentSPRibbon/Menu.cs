using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class Menu :RibbonElement, IRibbonElementContainer<Menu,MenuSection>
    {
        internal readonly IList<MenuSection> _menuSections;
        internal Menu() :this("NotSet")
        {

        }

        internal Menu(String id) : base(id)
        {
            _menuSections=new List<MenuSection>();
        }

        public String GetProperty(MenuProperty propertyKey)
        {
            return GetPropertyValue(propertyKey);
        }

        public Menu SetWidthTo(String value)
        {
            AddOrUpdateProperty(MenuProperty.MaxWidth, value);
            return this;
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
    }
}
