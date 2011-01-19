using System;
using System.Collections.Generic;
using System.Xml;

namespace DotNetRocks.FluentSPRibbon
{
    public interface IRibbonElementContainer
    {
 
    }
    public interface IRibbonElementContainer<TItemType, TChildElementType> : IRibbonElement<TItemType>, IRibbonElementContainer 
        where TChildElementType : IRibbonElement<TChildElementType> 
        where TItemType : IRibbonElement<TItemType>
    {
        
        TChildElementType this[String id] { get; }
        int ChildItemCount { get; }
        TItemType With(Func<TChildElementType> expression);
    }
}