using DotNetRocks.FluentSPRibbon.Attributes;

namespace DotNetRocks.FluentSPRibbon
{
    public enum MenuSectionProperty
    {
        [TextProvider]
        Title,
        Scrollable,
        Sequence,
        MaxHeight,
        DisplayMode
    }
}