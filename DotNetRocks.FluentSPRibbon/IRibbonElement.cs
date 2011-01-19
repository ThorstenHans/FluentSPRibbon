using System;

namespace DotNetRocks.FluentSPRibbon
{
    public interface IRibbonElement<T> 
    {
        T SetPropertyTo(String name, String value);
        
    }

  
}