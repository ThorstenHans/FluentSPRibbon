

namespace DotNetRocks.FluentSPRibbon
{
    public enum DropDownProperty
    {
        [TextProvider]
        AltArrow,
        [TextProvider]
        Alt,
        CacheMenuVersions,
        Command,
        CommandMenuOpen,
        CommandMenuClose,
        CommandPreview,
        CommandPreviewRevert,
        InitialItem,
        PopulateDynamically,
        PopulateQueryCommand,
        PopulateOnlyOnce,
        QueryCommand,
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
        ToolTipShortcutKey,
        [TextProvider]
        ToolTipSelectedItemTitle,
        Width,
        SelectedItemDisplayMode
    }
}