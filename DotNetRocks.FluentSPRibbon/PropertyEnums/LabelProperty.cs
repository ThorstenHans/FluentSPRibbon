

namespace DotNetRocks.FluentSPRibbon
{
    public enum LabelProperty
    {
        ForId,
        [TextProvider]
        LabelText,
        [ImageProvider]
        Image16by16,
        Image16by16Class,
        Image16by16Left,
        Image16by16Top,
        Sequence,
        TemplateAlias,
        QueryCommand,
        Command
    }
}