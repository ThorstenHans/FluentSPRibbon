using System;

namespace DotNetRocks.FluentSPRibbon
{
    public class MenuSection : RibbonElementBase, IRibbonElement<MenuSection>
    {
        internal MenuSection() 
            : this("NotSet")
        {

        }

        internal MenuSection(String id) 
            : base(id)
        {

        }
        public MenuSection SetPropertyTo(string name, string value)
        {
            base.SetPropertyTo(name,value);
            return this;
        }
    }
}