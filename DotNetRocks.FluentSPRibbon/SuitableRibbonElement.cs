using System;

namespace DotNetRocks.FluentSPRibbon
{
    public abstract class SuitableRibbonElement : RibbonElementBase,IRibbonElement<SuitableRibbonElement>
    {
        internal SuitableRibbonElement() : this("NotSet")
        {
    
        }

        internal SuitableRibbonElement(String id) : base(id)
        {
            
        }

        internal abstract String TagName { get; }

        public virtual SuitableRibbonElement SetPropertyTo(string name, string value)
        {
            base.SetPropertyTo(name,value);
            return this;
        }


    }

     
}
