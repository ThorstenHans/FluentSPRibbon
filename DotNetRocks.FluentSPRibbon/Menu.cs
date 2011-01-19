using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetRocks.FluentSPRibbon
{
    public class Menu :RibbonElementBase, IRibbonElement<Menu>
    {
        internal Menu() :this("NotSet")
        {

        }

        internal Menu(String id) : base(id)
        {

        }
        
        public Menu SetPropertyTo(string name, string value)
        {
            base.SetPropertyTo(name,value);
            return this;
        }

    }
}
