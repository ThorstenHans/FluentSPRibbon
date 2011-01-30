using DotNetRocks.FluentSPRibbon.Attributes;

namespace DotNetRocks.FluentSPRibbon
{
    public enum InsertTableProperty
    {
        [TextProvider]
        Alt,
        Command,
        CommandType,
        CommandPreview,
        CommandRevert,
        [TextProvider]
        MenuSectionInitialTitle,
        [TextProvider]
        MenuSectionTitle,
        Sequence
    }
}