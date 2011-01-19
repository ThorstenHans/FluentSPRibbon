using System;

namespace DotNetRocks.FluentSPRibbon
{
    public class TemplateActionRequiredEventArgs : EventArgs
    {
        public String ControlTemplateAlias { get; set; }
        public String TemplateId { get; set; }
    }
}