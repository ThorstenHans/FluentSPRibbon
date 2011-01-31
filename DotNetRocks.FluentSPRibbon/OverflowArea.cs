using System;

namespace DotNetRocks.FluentSPRibbon
{
    public class OverflowArea : RibbonElement
    {
        internal OverflowArea() : this("NotSet") { }

        internal OverflowArea(String id) : base(id) { }
    }
}