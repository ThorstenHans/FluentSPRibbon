using System;

namespace DotNetRocks.FluentSPRibbon
{
    public class ControlRef : RibbonElement
    {
        internal ControlRef() : this("NotSet") { }

        internal ControlRef(String id) : base(id) { }
    }
}