using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public abstract class InteractiveRibbonElement<T,TPropertyEnum, TDisplayModeEnum> : RibbonElement<T,TPropertyEnum>
    {
        private const String DisplayModeProperty = "DisplayMode";
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
                (ControlRefDisplayMode)Enum.Parse(typeof(ControlRefDisplayMode), _templateProperties[DisplayModeProperty]));
            return controlRef;
        }

        protected void SetDisplayModeTo(TDisplayModeEnum displayModeValue)
        {
            if (this._templateProperties.ContainsKey(DisplayModeProperty))
                this._templateProperties[DisplayModeProperty] = displayModeValue.ToString();
            else
                this._templateProperties.Add(DisplayModeProperty, displayModeValue.ToString());
        }

        internal String GetDisplayMode()
        {
            if (this._templateProperties.ContainsKey(DisplayModeProperty))
                return this._templateProperties[DisplayModeProperty];
            return String.Empty;
        }
    }
}
