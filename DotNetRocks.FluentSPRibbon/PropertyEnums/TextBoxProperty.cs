using System.ComponentModel;


namespace DotNetRocks.FluentSPRibbon
{
    public enum TextBoxProperty
    {
        Command,
        ImeEnabled,
        MaxLength,
        QueryCommand,
        Sequence,
        ShowAsLabel,
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
        ToolTipShortcutKey,
        Width
    }
}