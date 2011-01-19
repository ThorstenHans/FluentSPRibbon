using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetRocks.FluentSPRibbon
{
    public class FlyoutAnchor : SuitableRibbonElement, IRibbonElement<FlyoutAnchor>
    {
        internal FlyoutAnchor() : this("NotSet")
        {

        }

        internal FlyoutAnchor(String id) : base(id)
        {

        }

        internal override string TagName
        {
            get { return "FlyoutAnchor"; }
        }

        public FlyoutAnchor SetPropertyTo(string name, string value)
        {
            base.SetPropertyTo(name, value);
            return this;
        }
    }
}
