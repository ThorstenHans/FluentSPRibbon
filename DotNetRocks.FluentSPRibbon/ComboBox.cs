using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class ComboBox : InteractiveRibbonElement, IRibbonElementContainer<ComboBox,Menu>
    {
        private Menu _menu;

        internal ComboBox() : this("NotSet"){ }

        internal ComboBox(String id) : base(id){ }
 
        public String Get(ComboBoxProperty propertyKey)
        {
            return GetPropertyValue(propertyKey);
        }
        public ComboBox SetDisplayMode(DisplayMode displayMode)
        {
            SetDisplayModeTo(displayMode);
            return this;
        }

        public ComboBox Set(ComboBoxProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey,value);
            return this;
        }

        public Menu Menu
        {
            get { return this._menu; }
        }

        public ComboBox Set(Dictionary<ComboBoxProperty,String> properties)
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
    }
}
