using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.FluentSPRibbon
{
    public class Scaling : RibbonElement<Scaling,ScalingProperty>, IRibbonElementContainer<Scaling,MaxSize>,IRibbonElementContainer<Scaling,Scale>
    {

        internal readonly IList<Scale> _scales;
        internal readonly IList<MaxSize> _maxSizes;
        internal Scaling() : this("NotSet") { }

        internal Scaling(string id) : base(id) 
        { 
            _scales=new List<Scale>();
            _maxSizes = new List<MaxSize>();
        }

        public new static Scaling Create(String id)
        {
            return RibbonElement<Scaling>.Create(id);
        }

        public MaxSize GetMaxSize(String id)
        {
            return _maxSizes.FirstOrDefault(ms => ms.OriginalId == id); 
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

        public Scale GetScale(String id)
        {
            return _scales.FirstOrDefault(s => s.OriginalId == id); 
        }

        public override Scaling Set(ScalingProperty propertyName, string propertyValue)
        {
            AddOrUpdateProperty(propertyName,propertyValue);
            return this;
        }

        public override Scaling Set(Dictionary<ScalingProperty, string> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key,property.Value);
            }
            return this;
        }
    }
}