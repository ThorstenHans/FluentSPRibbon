using System;

namespace DotNetRocks.FluentSPRibbon
{
    public class CheckBox : SuitableRibbonElement, IRibbonElement<CheckBox>
    {
        internal CheckBox() : this("NotSet")
        {
        }

        internal CheckBox(string id) : base(id)
        {
        }

        internal override string TagName
        {
            get { return "CheckBox"; }
        }

        public CheckBox SetPropertyTo(string name, string value)
        {
            base.SetPropertyTo(name,value);
            return this;
        }
        
    }
}