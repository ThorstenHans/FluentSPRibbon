using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetRocks.FluentSPRibbon
{
    public abstract class SuitableRibbonElement : RibbonElementBase,IRibbonElement<SuitableRibbonElement>, ITemplateConsumer<SuitableRibbonElement>
    {
        internal event EventHandler<TemplateActionRequiredEventArgs> TemplateActionRequired;
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

        public virtual SuitableRibbonElement SetTemplateAlias(string templateAliasId)
        {
            return this;
        }

        protected void DoSetTemplateAlias(String templateAliasId)
        {
            SetPropertyTo("TemplateAlias", templateAliasId);
        }

        private void FireTemplateActionRequired(String templateId, String controlTemplateAliasId)
        {
            if(TemplateActionRequired!= null)
                TemplateActionRequired(this, new TemplateActionRequiredEventArgs()
                                                 {
                                                     TemplateId = templateId,
                                                     ControlTemplateAlias = controlTemplateAliasId
                                                });
        }
    }

     
}
