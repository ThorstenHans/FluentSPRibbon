using System;


namespace DotNetRocks.FluentSPRibbon
{
    public enum ComboBoxProperty 
    {
        AllowFreeForm,
        [TextProvider]
        AltArrow,
        [TextProvider]
        Alt,
        AutoComplete,
        AutoCompleteDelay,
        CacheMenuVersions,
        Command,
        CommandMenuOpen,
        CommandMenuClose,
        CommandPreview,
        CommandPreviewRevert,
        ImeEnabled,
        InitialItem,
        QueryCommand,
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
        ToolTipSelectedItemTitle,
        ToolTipShortcutKey,
        Width
    }
}