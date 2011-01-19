using System;

namespace DotNetRocks.FluentSPRibbon
{
    public class ToggleButton: RibbonElementBase, IRibbonElement<ToggleButton>
    {
        internal ToggleButton(string id) : base(id)
        {
        }

        public ToggleButton SetPropertyTo(string name, string value)
        {
            base.SetPropertyTo(name,value);
            return this;
        }
    }
}