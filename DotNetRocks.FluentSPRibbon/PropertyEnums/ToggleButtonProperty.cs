using DotNetRocks.FluentSPRibbon.Attributes;

namespace DotNetRocks.FluentSPRibbon
{
    public enum ToggleButtonProperty
    {
        [TextProvider]
        Alt,
        Command,
        CommandValueId,
        [TextProvider]
        Description,
        LabelCss,
        [TextProvider]
        LabelText,
        [ImageProvider]
        Image32by32,
        Image32by32Class,
        Image32by32Left,
        Image32by32Top,
        [ImageProvider]
        Image16by16,
        Image16by16Class,
        Image16by16Left,
        Image16by16Top,
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
        [TextProvider]
        ToolTipHelpKeyWord,
        ToolTipShortcutKey
    }
}