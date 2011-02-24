using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class Group : RibbonElement<Group,GroupProperty>,
        IRibbonElementContainer<Group, Button>, IRibbonElementContainer<Group, CheckBox>,
        IRibbonElementContainer<Group, ComboBox>, IRibbonElementContainer<Group, DropDown>,
        IRibbonElementContainer<Group, FlyoutAnchor>, IRibbonElementContainer<Group, GalleryButton>,
        IRibbonElementContainer<Group, Label>, IRibbonElementContainer<Group, MRUSplitButton>,
        IRibbonElementContainer<Group, Spinner>, IRibbonElementContainer<Group, SplitButton>,
        IRibbonElementContainer<Group, TextBox>, IRibbonElementContainer<Group,ToggleButton>

    {
        internal readonly IList<IRibbonElement> _innerControls;
        private readonly Dictionary<String, String> _controlsProperties;
        private string _className;
        private Layout _layout;

        internal Group():this("NotSet")
        {
            
        }

        internal Group(string id) : base(id)
        {
            this._innerControls = new List<IRibbonElement>();
            this._controlsProperties = new Dictionary<string, string>();
        }

        public static new Group Create(String id)
        {
            return RibbonElement<Group>.Create(id);
        }
        
        public Group ApplyControlsProperty(String name, String value)
        {
            if (this._controlsProperties.ContainsKey(name))
                this._controlsProperties[name] = value;
            else
                this._controlsProperties.Add(name,value);
            return this;
        }

        public Group ApplyControlsProperties(Dictionary<String, String> properties)
        {
            foreach (var property in properties)
            {
                ApplyControlsProperty(property.Key, property.Value);
            }
            return this;
        }

        public int ChildItemCount
        {
            get { return _innerControls.Count; }
        }

        internal String ClassName
        {
            get { return _className; }
        }

        internal Layout Layout
        {
            get { return this._layout; }
        }

        

        public override Group Set(GroupProperty propertyName, string propertyValue)
        {
            AddOrUpdateProperty(propertyName,propertyValue);
            return this;
        }

        public override Group Set(Dictionary<GroupProperty, string> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key,property.Value);
            }
            return this;
        }

        protected override void WriteChildren(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("Controls");
            writer.WriteAttributeString("Id", Id+".ControlsContainer");
            foreach (var controlsProperty in _controlsProperties)
            {
                writer.WriteAttributeString(controlsProperty.Key,controlsProperty.Value);
            }
            _innerControls.ToList().ForEach(se=>
                                                   {
                                                       writer.WriteStartElement(se.XmlElementName);
                                                       se.WriteXml(writer);
                                                       writer.WriteEndElement();
                                                   });
            writer.WriteEndElement();

        }


        public String GetControlsProperty(string propertyName)
        {
            if (_controlsProperties.ContainsKey(propertyName))
                return _controlsProperties[propertyName];
            return String.Empty;
        }

        public Group With(Func<Button> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return AddChildControl(child);
        }

        private Group AddChildControl(IRibbonElement child)
        {
            
            this._innerControls.Add(child);
            return this;
        }

        public Group With(Func<CheckBox> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return AddChildControl(child);
        }

        public Group With(Func<ComboBox> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return AddChildControl(child);
        }

        public Group With(Func<DropDown> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return AddChildControl(child);
        }
        
        public Group With(Func<FlyoutAnchor> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return AddChildControl(child);
        }

        public Group With(Func<GalleryButton> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return AddChildControl(child);
        }

        public Group With(Func<Label> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return AddChildControl(child);
        }

        public Group With(Func<MRUSplitButton> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return AddChildControl(child);
        }

        public Group With(Func<Spinner> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return AddChildControl(child);
        }

        public Group With(Func<SplitButton> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return AddChildControl(child);
        }

        public Group With(Func<TextBox> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return AddChildControl(child);
        }

        public Group With(Func<ToggleButton> expression)
        {
            var child = expression.Invoke();
            child.Parent = this;
            return AddChildControl(child);
        }

        public Group SetClassTo(string className)
        {
            this._className = className;
            return this;
        }

        public Group SetLayout(Func<Layout> expression)
        {
            var layout = expression.Invoke();
            layout.Parent = this;
            this._layout = layout;
            return this;
        }
    }
}