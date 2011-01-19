using System;

namespace DotNetRocks.FluentSPRibbon
{
    public class TextBox : SuitableRibbonElement, IRibbonElement<TextBox>
    {
        internal TextBox() : this("NotSet")
        {
        }

        internal TextBox(string id) : base(id)
        {
        }

        internal override string TagName
        {
            get { return "TextBox"; }
        }

        public TextBox SetPropertyTo(string name, string value)
        {
            base.SetPropertyTo(name,value);
            return this;
        }
    }
}