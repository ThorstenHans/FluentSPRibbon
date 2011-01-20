using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetRocks.FluentSPRibbon
{
    public class Property<T> where T: RibbonElementBase
    {
        private T _currentItem;
        private String _propertyName; 
        internal Property(T currentItem, String propertyName)
        {
            _currentItem = currentItem;
            _propertyName = propertyName;
        }

        public T To(String value)
        {
            _currentItem.SetPropertyTo(_propertyName,value);
            return _currentItem;
        }
    }
}
