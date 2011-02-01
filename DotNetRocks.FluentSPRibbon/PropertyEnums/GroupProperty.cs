using DotNetRocks.FluentSPRibbon.Attributes;

namespace DotNetRocks.FluentSPRibbon
{
    public enum GroupProperty
    {
        Command,
        [TextProvider]
        Description,
        [ImageProvider]
        Image32by32Popup,
        Image32by32PopupClass,
        Image32by32PopupLeft,
        Image32by32PopupTop,
        Sequence,
        Template,
        [TextProvider]
        Title
    }
}