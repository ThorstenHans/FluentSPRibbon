﻿using DotNetRocks.FluentSPRibbon.Attributes;

namespace DotNetRocks.FluentSPRibbon
{
    public enum RibbonProperty
    {
        Image32by32GroupPopupDefault,
        Image32by32GroupPopupDefaultClass,
        Image32by32GroupPopupDefaultLeft,
        Image32by32GroupPopupDefaultTop,
        ImageDownArrow,
        ImageDownArrowClass,
        ImageDownArrowLeft,
        ImageDownArrowTop,
        ImageSideArrow,
        ImageSideArrowClass,
        ImageSideArrowLeft,
        ImageSideArrowTop,
        ImageUpArrow,
        ImageUpArrowClass,
        ImageUpArrowLeft,
        ImageUpArrowTop,
        RootEventCommand,
        TabSwitchCommand,
        ScaleCommand,
        TextDirection,
        [TextProvider]
        ToolTipFooterText,
        [ImageProvider]
        ToolTipFooterImage16by16,
        ToolTipFooterImage16by16Class,
        ToolTipFooterImage16by16Left,
        ToolTipFooterImage16by16Top,
        ToolTipDisabledCommandImage16by16,
        ToolTipDisabledCommandImage16by16Class,
        ToolTipDisabledCommandImage16by16Left,
        ToolTipDisabledCommandImage16by16Top,
        [TextProvider]
        ToolTipDisabledCommandDescription,
        [TextProvider]
        ToolTipDisabledCommandTitle,
        ToolTipDisabledCommandHelpKey,
        ToolTipHelpCommand,
        ToolTipSelectedItemTitlePrefix,
        ShortcutKeyJumpToRibbon_Ctrl,
        ShortcutKeyJumpToRibbon_Alt,
        ShortcutKeyJumpToRibbon_Shift,
        ShortcutKeyJumpToRibbon_AccessKey,
        ShortcutKeyJumpToFirstControl_Ctrl,
        ShortcutKeyJumpToFirstControl_Alt,
        ShortcutKeyJumpToFirstControl_Shift,
        ShortcutKeyJumpToFirstControl_AccessKey,
        [TextProvider]
        ATContextualTabText,
        [TextProvider]
        ATTabPositionText,
        [TextProvider]
        NavigationHelpText
    }
}