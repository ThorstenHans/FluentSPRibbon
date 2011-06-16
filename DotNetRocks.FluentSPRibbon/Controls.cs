using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class Controls : RibbonElement<Controls, ControlsProperty>,
        IRibbonElementContainer<Controls, Button>,
        IRibbonElementContainer<Controls, CheckBox>,
        IRibbonElementContainer<Controls, ComboBox>,
        IRibbonElementContainer<Controls, DropDown>,
        IRibbonElementContainer<Controls, FlyoutAnchor>,
        IRibbonElementContainer<Controls, GalleryButton>,
        IRibbonElementContainer<Controls, Label>,
        IRibbonElementContainer<Controls, MRUSplitButton>,
        IRibbonElementContainer<Controls, Spinner>,
        IRibbonElementContainer<Controls, SplitButton>,
        IRibbonElementContainer<Controls, TextBox>,
        IRibbonElementContainer<Controls, ToggleButton>
    {

        private readonly IList<IRibbonElement> _children;

        internal Controls() : this("NotSet") { }

        internal Controls(string id) : base(id)
        {
            this._children = new List<IRibbonElement>();
        }

        public static new Controls Create(string id)
        {
            return RibbonElement<Controls>.Create(id);
        }

        internal override bool IsIdProvider
        {
            get { return true; }
        }

        private Controls With(IRibbonElement ribbonElement)
        {
            this._children.Add(ribbonElement);
            return this;
        }
        public Controls With(Func<Button> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public Controls With(Func<CheckBox> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public Controls With(Func<ComboBox> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public Controls With(Func<DropDown> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public Controls With(Func<FlyoutAnchor> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public Controls With(Func<GalleryButton> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public Controls With(Func<Label> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public Controls With(Func<MRUSplitButton> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public Controls With(Func<Spinner> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public Controls With(Func<SplitButton> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public Controls With(Func<TextBox> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public Controls With(Func<ToggleButton> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public override Controls Set(ControlsProperty propertyName, string propertyValue)
        {
            AddOrUpdateProperty(propertyName,propertyValue);
            return this;
        }

        public override Controls Set(Dictionary<ControlsProperty, string> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}