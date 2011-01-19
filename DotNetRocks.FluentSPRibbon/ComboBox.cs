using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetRocks.FluentSPRibbon
{
    public class ComboBox : SuitableRibbonElement, IRibbonElement<ComboBox>
    {
        internal ComboBox() : this("NotSet")
        {
            
        }

        internal ComboBox(String id) : base(id)
        {
            
        }

        internal override string TagName
        {
            get { return "ComboBox"; }
        }

        public ComboBox SetPropertyTo(string name, string value)
        {
            base.SetPropertyTo(name, value);
            return this;
        }
    }
}
