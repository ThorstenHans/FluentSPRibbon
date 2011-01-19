using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetRocks.FluentSPRibbon
{
    public class MRUSplitButton : SuitableRibbonElement, IRibbonElement<MRUSplitButton>
    {
        internal MRUSplitButton()  : this("NotSet")
        {
            
        }

        internal MRUSplitButton(String id)
            : base(id)
        {
            
        }

        internal override string TagName
        {
            get { return "MRUSplitButton"; }
        }

        public MRUSplitButton SetPropertyTo(string name, string value)
        {
            base.SetPropertyTo(name, value);
            return this;
        }
    }
}
