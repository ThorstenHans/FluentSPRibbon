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

        internal Button(string id) : base(id)
        {
        }

        internal override string TagName
        {
            get { return "Button"; }
        }


        public Button ApplyProperty(String name, String value)
        {
            SetProperty(name, value);
            return this;
        }

        public Button ApplyProperties(Dictionary<String, String> properties)
        {
            foreach (var property in properties)
            {
               SetProperty(property.Key,property.Value);
            }
            return this;
        }

    }
}