using System;

namespace DotNetRocks.FluentSPRibbon
{
    public class Spinner : SuitableRibbonElement, IRibbonElement<Spinner>
    {
        internal Spinner() : this("NotSet")
        {

        }

        internal Spinner(String id) : base(id)
        {

        }

        internal override string TagName
        {
            get { return "Spinner"; }
        }

        public Spinner SetPropertyTo(string name, string value)
        {
            base.SetPropertyTo(name, value);
            return this;
        }
    }
}
