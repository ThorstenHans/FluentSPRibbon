using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class InteractiveRibbonElement : RibbonElement
    {
        internal readonly Dictionary<String, String> _templateProperties;

        public InteractiveRibbonElement() : this("NotSet")
        {
            
        }

        public InteractiveRibbonElement(string id) :base(id)
        {
            this._templateProperties=new Dictionary<string, string>();
            
        }

        internal void SetDisplayModeTo(DisplayMode displayMode)
        {
            if (this._templateProperties.ContainsKey("DisplayMode"))
                this._templateProperties["DisplayMode"] = displayMode.ToString();
            else
                this._templateProperties.Add("DisplayMode",displayMode.ToString());
        }
    }
}
