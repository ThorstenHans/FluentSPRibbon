using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class MRUSplitButton : InteractiveRibbonElement<MRUSplitButton,MRUProperty,MRUDisplayMode>,
        IRibbonElementContainer<MRUSplitButton,Menu>
    {
        internal Menu _menu;

        internal MRUSplitButton()  : this("NotSet")
        {
        }

        internal MRUSplitButton(String id)
            : base(id)
        {
        }

        public new static MRUSplitButton Create(String id)
        {
            return RibbonElement<MRUSplitButton>.Create(id);
        }

        public override MRUSplitButton SetDisplayMode(MRUDisplayMode displayMode)
        {
            SetDisplayModeTo(displayMode);
            return this;
        }

        public override MRUSplitButton Set(MRUProperty propertyName, String propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

        public override MRUSplitButton Set(Dictionary<MRUProperty, String> properties)
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

        public MRUSplitButton With(Func<Menu> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            this._menu = child;
            return this;
        }
    }
}
