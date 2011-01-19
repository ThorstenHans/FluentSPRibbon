namespace DotNetRocks.FluentSPRibbon
{
    public class CheckBox : RibbonElementBase, IRibbonElement<CheckBox>
    {
        internal CheckBox(string id) : base(id)
        {
        }

        public CheckBox SetPropertyTo(string name, string value)
        {
            base.SetPropertyTo(name,value);
            return this;
        }
        
    }
}