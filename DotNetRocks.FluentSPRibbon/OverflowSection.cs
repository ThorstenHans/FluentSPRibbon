using System;

namespace DotNetRocks.FluentSPRibbon
{
    public class OverflowSection : RibbonElement
    {
        internal OverflowSection() : this("NotSet") { }

        internal OverflowSection(String id)
            : base(id)
        {
        }
        public OverflowSection SetDisplayMode(DisplayMode displayMode)
        {
            AddOrUpdateProperty(OverflowSectionProperty.DisplayMode, displayMode.ToString());
            return this;
        }

        public OverflowSection HasDividerBefore(bool hasDividerBefore)
        {
            AddOrUpdateProperty(OverflowSectionProperty.DividerBefore, hasDividerBefore.ToString().ToUpper());
            return this;
        }

        public OverflowSection HasDividerAfter(bool hasDividerAfter)
        {
            AddOrUpdateProperty(OverflowSectionProperty.DividerAfter, hasDividerAfter.ToString().ToUpper());
            return this;
        }

        public OverflowSection SetLayoutType(OverflowLayoutType overflowLayoutType)
        {
            AddOrUpdateProperty(OverflowSectionProperty.Type, overflowLayoutType.ToString());
            return this;
        }
    }
}