using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public abstract class InteractiveRibbonElement<T,TPropertyEnum, TDisplayModeEnum> : RibbonElement<T,TPropertyEnum>
    {
        internal readonly Dictionary<String, String> _templateProperties;

        public InteractiveRibbonElement() : this("NotSet")
        {
            
        }

        public InteractiveRibbonElement(string id) :base(id)
        {
            this._templateProperties=new Dictionary<string, string>();
            
        }
        
        public abstract T SetDisplayMode(TDisplayModeEnum displayMode);

        public ControlRef GetControlRef()
        {
            var controlRef = new ControlRef();
            controlRef.Set(ControlRefProperty.TemplateAlias, Id);

            controlRef.SetDisplayMode(
                (ControlRefDisplayMode) Enum.Parse(typeof (ControlRefDisplayMode), _templateProperties["DisplayMode"]));
            return controlRef;
        }

        protected void SetDisplayModeTo(TDisplayModeEnum displayModeValue)
        {
            if (this._templateProperties.ContainsKey("DisplayMode"))
                this._templateProperties["DisplayMode"] = displayModeValue.ToString();
            else
                this._templateProperties.Add("DisplayMode",displayModeValue.ToString());
        }
    }
}
