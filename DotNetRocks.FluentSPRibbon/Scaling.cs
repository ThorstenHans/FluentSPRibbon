using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class Scaling : RibbonElement, IRibbonElementContainer<Scaling,MaxSize>,IRibbonElementContainer<Scaling,Scale>
    {

        private readonly IList<Scale> _scales;
        private readonly IList<MaxSize> _maxSizes;
        internal Scaling() : this("NotSet") { }

        internal Scaling(string id) : base(id) 
        { 
            _scales=new List<Scale>();
            _maxSizes = new List<MaxSize>();
        }


        MaxSize IRibbonElementContainer<Scaling, MaxSize>.this[string id]
        {
            get { return _maxSizes.FirstOrDefault(ms => ms.Id == id); }
        }

        public Scaling With(Func<Scale> expression)
        {
            var scale = expression.Invoke();
            scale.Parent = this;
            _scales.Add(scale);
            return this;
        }

        public Scaling With(Func<MaxSize> expression)
        {
            var maxSize = expression.Invoke();
            maxSize.Parent = this;
            _maxSizes.Add(maxSize);
            return this;
        }

        Scale IRibbonElementContainer<Scaling, Scale>.this[string id]
        {
            get { return _scales.FirstOrDefault(s => s.Id == id); }
        }
    }
}