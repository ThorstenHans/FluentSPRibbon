using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class Layout : RibbonElement<Layout,LayoutProperty>, IRibbonElementContainer<Layout, Section>, IRibbonElementContainer<Layout, OverflowSection>
    {
        internal readonly IList<Section> _sections;
        internal readonly IList<OverflowSection> _overflowSections;

        internal Layout() : this("NotSet") { }

        internal Layout(String id)
            : base(id)
        {
            this._sections = new List<Section>();
            this._overflowSections = new List<OverflowSection>();
        }

        public Layout With(Func<Section> expression)
        {
            var section = expression.Invoke();
            section.Parent = this;
            _sections.Add(section);
            return this;
        }

        public Layout With(Func<OverflowSection> expression)
        {
            var overflowSection = expression.Invoke();
            _overflowSections.Add(overflowSection);
            return this;
        }

        public override Layout Set(LayoutProperty propertyName, string propertyValue)
        {
            AddOrUpdateProperty(propertyName,propertyValue);
            return this;
        }

        public override Layout Set(Dictionary<LayoutProperty, string> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key,property.Value);
            }
            return this;
        }
    }
}