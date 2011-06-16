namespace DotNetRocks.FluentSPRibbon
{
    public class Controls : RibbonElement<Controls>
    {
        internal Controls() : this("NotSet") { }

        internal Controls(string id) : base(id) { }

        public static new Controls Create(string id)
        {
            return RibbonElement<Controls>.Create(id);
        }

        internal override bool IsIdProvider
        {
            get { return true; }
        }
    }
}