using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class SplitButton : InteractiveRibbonElement<SplitButton,SplitButtonProperty,SplitButtonDisplayMode>,
        IRibbonElementContainer<SplitButton,Menu>
    {
        internal Menu _menu;

        internal SplitButton() : this("NotSet")
        {
            
        }

        internal SplitButton(String id) : base(id)
        {
            
        }
        public override SplitButton SetDisplayMode(SplitButtonDisplayMode displayMode)
        {
            SetDisplayModeTo(displayMode);
            return this;
        }

        public override SplitButton Set(SplitButtonProperty propertyName, String propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

        public override SplitButton Set(Dictionary<SplitButtonProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
        
        public Menu GetMenu()
        {
            return _menu;
        }

        public SplitButton With(Func<Menu> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            this._menu = child;
            return this;
        }
    }
}
