using System;

namespace DotNetRocks.FluentSPRibbon
{
    public class TextBox : RibbonElementBase, IRibbonElement<TextBox>
    {
        internal TextBox(string id) : base(id)
        {
        }

        public TextBox SetPropertyTo(string name, string value)
        {
            base.SetPropertyTo(name,value);
            return this;
        }
    }
}