using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetRocks.FluentSPRibbon
{
    public class DropDown : SuitableRibbonElement, IRibbonElement<DropDown>
    {
        internal DropDown() : this("NotSet")
        {
            
        }

        internal DropDown(String id) :base(id)
        {
            
        }
        internal override string TagName
        {
            get { return "DropDown"; }
        }

        public DropDown SetPropertyTo(string name, string value)
        {
            base.SetPropertyTo(name, value);
            return this;
        }
    }
}
