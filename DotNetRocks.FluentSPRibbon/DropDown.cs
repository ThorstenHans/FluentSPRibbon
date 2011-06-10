using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class DropDown : InteractiveRibbonElement<DropDown,DropDownProperty,DropDownDisplayMode>,
        IRibbonElementContainer<DropDown,Menu>
    {
        internal Menu _menu;

        internal DropDown() : this("NotSet") { }

        internal DropDown(String id) :base(id) { }

        public new static DropDown Create(String id)
        {
            return RibbonElement<DropDown>.Create(id);
        }

        public override  DropDown SetDisplayMode(DropDownDisplayMode displayMode)
        {
            SetDisplayModeTo(displayMode);
            return this;
        }

        public override DropDown Set(DropDownProperty propertyName, String propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

        public override DropDown Set(Dictionary<DropDownProperty,String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }

        public Menu GetMenu()
        {
            return this._menu;
        }

        public DropDown With(Func<Menu> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            this._menu = child;
            return this;
        }
    }
}
