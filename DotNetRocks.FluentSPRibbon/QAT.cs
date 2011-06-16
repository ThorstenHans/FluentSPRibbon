using System;
using System.Collections.Generic;

namespace DotNetRocks.FluentSPRibbon
{
    public class QAT : RibbonElement<QAT, QATProperty>, IRibbonElementContainer<QAT, Controls>
    {
        private Controls _controls;

        internal QAT() : this("NotSet") { }

        internal QAT(string id) : base(id) { }

        public static new QAT Create(string id)
        {
            return RibbonElement<QAT>.Create(id);
        }

        internal override bool IsIdProvider
        {
            get { return true; }
        }

        public QAT With(Func<Controls> expression)
        {
            if(_controls != null)
                throw new ArgumentOutOfRangeException("Only one Controls element allowed on QAT");

            var child = expression.Invoke();
            child.Parent = this;
            this._controls = child;
            return this;
        }

        public override QAT Set(QATProperty propertyName, string propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

        public override QAT Set(Dictionary<QATProperty, string> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }
    }
}