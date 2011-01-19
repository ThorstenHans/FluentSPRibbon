using System;

namespace DotNetRocks.FluentSPRibbon
{
    public interface ITemplateProvider<T>
    {
        T SetTemplate(String templateId);
    }
}