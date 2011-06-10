using System;

namespace DotNetRocks.FluentSPRibbon
{
    public interface IRibbonElementContainer<TContainer, TChildControl>
    {
        TContainer With(Func<TChildControl> expression);
        
    }
}