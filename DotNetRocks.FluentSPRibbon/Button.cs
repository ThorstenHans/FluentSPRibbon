using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class Button : InteractiveRibbonElement
    {
        public static class Property
        {
            public const String LabelText = "LabelText";
        }

        internal Button():this("NotSet"){}

        internal Button(string id) : base(id) { }

        public Button ApplyProperty(String name, String value)
        {
            SetProperty(name, value);
            return this;
        }

        public Button ApplyProperties(Dictionary<String, String> properties)
        {
            SetProperties(properties);
            return this;
        }

    }
}