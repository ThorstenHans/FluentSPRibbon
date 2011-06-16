namespace DotNetRocks.FluentSPRibbon
{
    public class QAT : RibbonElement<QAT>
    {
        internal QAT() : this("NotSet") { }

        internal QAT(string id) : base(id) { }

        public static new QAT Create(string id)
        {
            return RibbonElement<QAT>.Create(id);
        }

        internal override bool IsIdProvider
        {
            get { return true; }
        }
    }
}