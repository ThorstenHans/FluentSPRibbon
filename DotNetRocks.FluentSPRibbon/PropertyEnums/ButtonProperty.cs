﻿

namespace DotNetRocks.FluentSPRibbon
{
    public enum ButtonProperty
    {
        [TextProvider]
        Alt,
        Command,
        CommandType,
        CommandValueId,
        [TextProvider]
        Description,
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
        LabelCss,
        [TextProvider]
        LabelText,
        MenuItemId,
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
        ToolTipShortcutKey
    }
}