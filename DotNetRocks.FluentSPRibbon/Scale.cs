using System;

namespace DotNetRocks.FluentSPRibbon
{
    public class Scale : RibbonElement
    {
        internal Scale() : this("NotSet") { }

        internal Scale(String id) : base(id) { }
    }
}