using System;

namespace DotNetRocks.FluentSPRibbon
{
    public interface ITemplateConsumer<T>
    {
        T SetTemplateAlias(String templateAliasId);
    }
}