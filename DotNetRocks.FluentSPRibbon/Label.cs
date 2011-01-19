using System;

namespace DotNetRocks.FluentSPRibbon
{
    public class Label : RibbonElementBase, IRibbonElement<Label>
    {
        internal Label(string id) : base(id)
        {
        }

        public Label SetPropertyTo(string name, string value)
        {
            base.SetPropertyTo(name,value);
            return this;
        }
    }
}