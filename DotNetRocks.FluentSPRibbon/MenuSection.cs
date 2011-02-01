using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace DotNetRocks.FluentSPRibbon
{
    public class MenuSection : RibbonElement<MenuSection,MenuSectionProperty>, 
        IRibbonElementContainer<MenuSection,ToggleButton>,
        IRibbonElementContainer<MenuSection, Button>,
        IRibbonElementContainer<MenuSection, ColorPicker>,
        IRibbonElementContainer<MenuSection, FlyoutAnchor>
    {
        internal readonly IList<ToggleButton> _toggleButtons;
        internal readonly IList<Button> _buttons;
        internal readonly IList<ColorPicker> _colorPickers;
        internal readonly IList<FlyoutAnchor> _flyoutAnchors;
        internal InsertTable _insertTable;

        internal MenuSection() : this("NotSet") { }

        internal MenuSection(String id) : base(id)
        {
            _toggleButtons = new List<ToggleButton>();
            _buttons = new List<Button>();
            _colorPickers = new List<ColorPicker>();
            _flyoutAnchors = new List<FlyoutAnchor>();
        } 

        public InsertTable InsertTable
        {
            get { return _insertTable; }
            private set { this._insertTable = value; }
        }

        public override  MenuSection Set(MenuSectionProperty propertyName, String propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

        public override MenuSection Set(Dictionary<MenuSectionProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key,property.Value);
            }
            return this;
        }

        public MenuSection With(Func<InsertTable> expression)
        {
            var insertTable = expression.Invoke();
            insertTable.Parent = this;
            this.InsertTable = insertTable;
            return this;
        }
         
        public MenuSection With(Func<FlyoutAnchor> expression)
        {
            var flyoutAnchor = expression.Invoke();
            flyoutAnchor.Parent = this;
            _flyoutAnchors.Add(flyoutAnchor);
            return this;
        }
         
        public MenuSection With(Func<ColorPicker> expression)
        {
            var colorPicker = expression.Invoke();
            colorPicker.Parent = this;
            _colorPickers.Add(colorPicker);
            return this;
        }         

        public MenuSection With(Func<Button> expression)
        {
            var button = expression.Invoke();
            button.Parent = this;
            _buttons.Add(button);
            return this;
        }

        public MenuSection With(Func<ToggleButton> expression)
        {
            var toggleButton = expression.Invoke();
            toggleButton.Parent = this;
            _toggleButtons.Add(toggleButton);
            return this;
        }

        public Button GetButton(String id)
        {
            return _buttons.FirstOrDefault(b => b.OriginalId == id);
        }

        public ToggleButton GetToggleButton(String id)
        {
            return _toggleButtons.FirstOrDefault(tb => tb.OriginalId == id);
        }

        public FlyoutAnchor GetFlyoutAnchor(String id)
        {
            return _flyoutAnchors.FirstOrDefault(fa => fa.OriginalId == id);
        }

        public ColorPicker GetColorPicker(String id)
        {
            return _colorPickers.FirstOrDefault(cp => cp.OriginalId == id);
        }

        protected override void WriteChildren(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("Controls");
            writer.WriteAttributeString("Id", String.Format("{0}.Controls", this.Id));
            foreach (var child in _buttons)
            {

                WriteInnerElement(writer, child);
            }

            foreach (var child in _colorPickers)
            {
                WriteInnerElement(writer, child);
            }

            foreach (var child in _flyoutAnchors)
            {
                WriteInnerElement(writer, child);
            }

            foreach (var child in _toggleButtons)
            {
                WriteInnerElement(writer, child);
            }
            writer.WriteEndElement();
        }

        private void WriteInnerElement(XmlWriter writer, IRibbonElement child)
        {
            writer.WriteStartElement(child.XmlElementName);
            child.WriteXml(writer);
            writer.WriteEndElement();
        }
    }
}
