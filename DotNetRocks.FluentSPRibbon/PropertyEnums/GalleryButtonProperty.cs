using DotNetRocks.FluentSPRibbon.Attributes;

namespace DotNetRocks.FluentSPRibbon
{
    public enum GalleryButtonProperty
    {
        [TextProvider]
        Alt,
        Command,
        CommandPreview,
        CommandRevert,
        CommandType,
        CommandValueId,
        ElementDimensions,
        [ImageProvider]
        Image,
        ImageClass,
        ImageLeft,
        ImageTop,
        InnerHTML,
        MenuItemId,
        QueryCommand,
        Sequence,
        TemplateAlias,
        [ImageProvider]
        ToolTipImage32by32,
        ToolTipImage32by32Class,
        ToolTipImage32by32Left,
        ToolTipImage32by32Top,
        [TextProvider]
        ToolTipTitle,
        [TextProvider]
        ToolTipDescription,
        ToolTipHelpKeyWord,
        ToolTipShortcutKey
    }
}