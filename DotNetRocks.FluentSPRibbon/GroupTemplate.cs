using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class GroupTemplate : RibbonElement<GroupTemplate,GroupTemplateProperty>, IRibbonElementContainer<GroupTemplate, Layout>
    {
        internal readonly IList<Layout> _layouts;

        internal GroupTemplate() : this("NotSet") { }

        internal GroupTemplate(String id)
            : base(id)
        {
            this._layouts = new List<Layout>();
        }

        public new static GroupTemplate Create(String id)
        {
            return RibbonElement<GroupTemplate>.Create(id);
        }

        public Layout GetLayout(String id)
        {
            return _layouts.FirstOrDefault(l => l.OriginalId == id);
        }
        public GroupTemplate With(Func<Layout> expression)
        {
            var layout = expression.Invoke();
            layout.Parent = this;
            _layouts.Add(layout);
            return this;
        }

        public override GroupTemplate Set(GroupTemplateProperty propertyName, string propertyValue)
        {
            AddOrUpdateProperty(propertyName,propertyValue);
            return this;
        }

        public override GroupTemplate Set(Dictionary<GroupTemplateProperty, string> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key,property.Value);
            }
            return this;
        }
    }
}
