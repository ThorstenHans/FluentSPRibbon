using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class CommandUIDefinition : RibbonElement<CommandUIDefinition,CommandUIDefinitionProperty>, 
        IRibbonElementContainer<CommandUIDefinition,Button>,
        IRibbonElementContainer<CommandUIDefinition,CheckBox>,
        IRibbonElementContainer<CommandUIDefinition,ComboBox>,
        IRibbonElementContainer<CommandUIDefinition,ColorPicker>,
        IRibbonElementContainer<CommandUIDefinition,ContextualGroup>,
        IRibbonElementContainer<CommandUIDefinition,ContextualTabs>,
        IRibbonElementContainer<CommandUIDefinition,Controls>,
        IRibbonElementContainer<CommandUIDefinition,DropDown>,
        IRibbonElementContainer<CommandUIDefinition,FlyoutAnchor>,
        IRibbonElementContainer<CommandUIDefinition,Gallery>,
        IRibbonElementContainer<CommandUIDefinition,GalleryButton>,
        IRibbonElementContainer<CommandUIDefinition,GroupTemplate>,
        IRibbonElementContainer<CommandUIDefinition,Group>,
        IRibbonElementContainer<CommandUIDefinition,Groups>,
        IRibbonElementContainer<CommandUIDefinition,InsertTable>,
        IRibbonElementContainer<CommandUIDefinition,Label>,
        IRibbonElementContainer<CommandUIDefinition,MRUSplitButton>,
        IRibbonElementContainer<CommandUIDefinition,MaxSize>,
        IRibbonElementContainer<CommandUIDefinition,Menu>,
        IRibbonElementContainer<CommandUIDefinition,MenuSection>,
        IRibbonElementContainer<CommandUIDefinition,QAT>,
        IRibbonElementContainer<CommandUIDefinition,Ribbon>,
        IRibbonElementContainer<CommandUIDefinition,Scale>,
        IRibbonElementContainer<CommandUIDefinition,Scaling>,
        IRibbonElementContainer<CommandUIDefinition,Spinner>,
        IRibbonElementContainer<CommandUIDefinition,SplitButton>,
        IRibbonElementContainer<CommandUIDefinition,Tab>,
        IRibbonElementContainer<CommandUIDefinition,Tabs>,
        IRibbonElementContainer<CommandUIDefinition,TextBox>,
        IRibbonElementContainer<CommandUIDefinition,ToggleButton>
    {

        internal IRibbonElement _child;

         internal CommandUIDefinition() : this("NotSet") { }

         internal CommandUIDefinition(string id)
             : base(id)
        {
        }

        public static new CommandUIDefinition Create()
        {
            return RibbonElement<CommandUIDefinition>.Create("NotSet");
        }

        internal override bool IsIdProvider
        {
            get { return false; }
        }

         public override CommandUIDefinition Set(CommandUIDefinitionProperty propertyName, string propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

         public override CommandUIDefinition Set(Dictionary<CommandUIDefinitionProperty, string> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }

        private CommandUIDefinition With(IRibbonElement ribbonElement)
        {
            this._child = ribbonElement;
            return this;
        }

        public CommandUIDefinition With(Func<Button> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<CheckBox> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<ComboBox> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<ColorPicker> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<ContextualGroup> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<ContextualTabs> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<Controls> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<DropDown> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<FlyoutAnchor> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<Gallery> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<GalleryButton> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<GroupTemplate> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<Group> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<Groups> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<InsertTable> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<Label> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<MRUSplitButton> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<MaxSize> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<Menu> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<MenuSection> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<QAT> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<Ribbon> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<Scale> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<Scaling> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<Spinner> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<SplitButton> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<Tab> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<Tabs> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<TextBox> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }

        public CommandUIDefinition With(Func<ToggleButton> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return With(child);
        }
        }
}