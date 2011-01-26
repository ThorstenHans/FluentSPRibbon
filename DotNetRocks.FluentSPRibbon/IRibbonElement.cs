using System;
using System.Xml.Serialization;

namespace DotNetRocks.FluentSPRibbon
{
    public interface IRibbonElement : IXmlSerializable
    {
        String Id { get; }
        String ToXml();
    }
}