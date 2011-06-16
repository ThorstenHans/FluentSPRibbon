namespace DotNetRocks.FluentSPRibbon
{
    public enum ControlsProperty
    {
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
        ToolTipShortcutKey
    }
}