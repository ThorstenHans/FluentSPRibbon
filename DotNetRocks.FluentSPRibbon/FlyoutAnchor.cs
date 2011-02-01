using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class FlyoutAnchor : InteractiveRibbonElement<FlyoutAnchor,FlyoutAnchorProperty,FlyoutAnchorDisplayMode>,
        IRibbonElementContainer<FlyoutAnchor,Menu>
    {
        internal Menu _menu;

        internal FlyoutAnchor() : this("NotSet") { }

        internal FlyoutAnchor(String id) : base(id) { }

        public override FlyoutAnchor SetDisplayMode(FlyoutAnchorDisplayMode displayMode)
        {
            SetDisplayModeTo(displayMode);
            return this;
        }

        public override FlyoutAnchor Set(FlyoutAnchorProperty propertyName, String propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

        public override FlyoutAnchor Set(Dictionary<FlyoutAnchorProperty,String> properties)
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

        public FlyoutAnchor With(Func<Menu> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            this._menu = child;
            return this;
        }
    }
}
