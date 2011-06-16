namespace DotNetRocks.FluentSPRibbon
{
    public class Tabs : RibbonElement<Tabs>
    {
        internal Tabs() : this("NotSet") { }

        internal Tabs(string id) : base(id) { }

        public static new Tabs Create(string id)
        {
            return RibbonElement<Tabs>.Create(id);
        }

        internal override bool IsIdProvider
        {
            get { return true; }
        }
    }
}