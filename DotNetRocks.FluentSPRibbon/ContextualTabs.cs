namespace DotNetRocks.FluentSPRibbon
{
    public class ContextualTabs : RibbonElement<ContextualTabs>
    {
        internal ContextualTabs() : this("NotSet") { }

        internal ContextualTabs(string id) : base(id)
        {
            
        }

        public static new ContextualTabs Create(string id)
        {
            return RibbonElement<ContextualTabs>.Create(id);
        }

        internal override bool IsIdProvider
        {
            get { return true; }
        }
    }
}