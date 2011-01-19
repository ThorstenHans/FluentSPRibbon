using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetRocks.FluentSPRibbon
{
    public class SplitButton : SuitableRibbonElement, IRibbonElement<SplitButton>
    {
        internal SplitButton() : this("NotSet")
        {
            
        }

        internal SplitButton(String id) : base(id)
        {
            
        }

        internal override string TagName
        {
            get { return "SplitButton"; }
        }

        public SplitButton SetPropertyTo(string name, string value)
        {
            base.SetPropertyTo(name,value);
            return this;
        }

       
    }
}
