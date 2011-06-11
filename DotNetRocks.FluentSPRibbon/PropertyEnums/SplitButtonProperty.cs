

namespace DotNetRocks.FluentSPRibbon
{
    public enum SplitButtonProperty
    {
        [TextProvider]
        Alt,
        CacheMenuVersions,
        Command,
        CommandMenuOpen,
        CommandMenuClose,
        CommandType,
        [ImageProvider, UrlProvider]
        Image32by32,
        Image32by32Class,
        Image32by32Left,
        Image32by32Top,
        [ImageProvider, UrlProvider]
        Image16by16,
        Image16by16Class,
        Image16by16Left,
        Image16by16Top,
        [TextProvider]
        LabelText,
        [TextProvider]
        MenuAlt,
        MenuCommand,
        PopulateDynamically,
        PopulateQueryCommand,
        PopulateOnlyOnce,
        Sequence,
        TemplateAlias,
        [ImageProvider, UrlProvider]
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
        [TextProvider]
        ToolTipSelectedItemTitle,
        ToolTipShortcutKey
    }
}