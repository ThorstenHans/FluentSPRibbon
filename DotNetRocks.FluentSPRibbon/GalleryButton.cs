namespace DotNetRocks.FluentSPRibbon
{
    public class GalleryButton : SuitableRibbonElement, IRibbonElement<GalleryButton>
    {
        internal GalleryButton() : this("NotSet")
        {

        }

        internal GalleryButton(string id) : base(id)
        {

        }
        internal override string TagName
        {
            get { return "GalleryButton"; }
        }

        public GalleryButton SetPropertyTo(string name, string value)
        {
            base.SetPropertyTo(name, value);
            return this;

        }
    }
}
