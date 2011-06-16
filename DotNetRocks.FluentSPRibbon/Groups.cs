namespace DotNetRocks.FluentSPRibbon
{
    public class Groups : RibbonElement<Groups>
    {
        internal Groups() : this("NotSet") { }

        internal Groups(string id) : base(id)
        {
        }

        public static new Groups Create(string id)
        {
            return RibbonElement<Groups>.Create(id);
        }

        internal override bool IsIdProvider
        {
            get { return true; }
        }
    }
}