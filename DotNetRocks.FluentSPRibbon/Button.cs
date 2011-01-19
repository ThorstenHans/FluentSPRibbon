using System;

namespace DotNetRocks.FluentSPRibbon
{
    public class Button : SuitableRibbonElement,IRibbonElement<Button>
    {
        internal Button():this("NotSet"){}

        internal Button(string id) : base(id)
        {
        }

        internal override string TagName
        {
            get { return "Button"; }
        }


        public Button SetPropertyTo(string name, string value)
        {
            base.SetPropertyTo(name, value);
            return this;
        }

        public  Button SetTemplateAlias(string templateAliasId)
        {
            base.SetTemplateAlias(templateAliasId);
            return this;
        }
    }
}