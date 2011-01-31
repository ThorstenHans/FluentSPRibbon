using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class GroupTemplate : RibbonElement, IRibbonElementContainer<GroupTemplate, Layout>
    {
        internal readonly IList<Layout> _layouts;

        internal GroupTemplate() : this("NotSet") { }

        internal GroupTemplate(String id)
            : base(id)
        {
            this._layouts = new List<Layout>();
        }

        public GroupTemplate SetCssClass(String cssClassSelector)
        {
            AddOrUpdateProperty(GroupTemplateProperty.ClassName, cssClassSelector);
            return this;
        }

        public String GetCssClassSelector()
        {
            return GetPropertyValue(GroupTemplateProperty.ClassName);
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
    }
}
