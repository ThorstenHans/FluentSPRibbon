using System;

namespace DotNetRocks.FluentSPRibbon
{
    public interface IRibbonElementContainer<TContainer, TChildControls>
    {
        TChildControls this[String id] { get; }
        TContainer With(Func<TChildControls> expression);
    }
}