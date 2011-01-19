using System;
using System.Reflection;
using System.Threading;

namespace DotNetRocks.FluentSPRibbon
{
    public class Create<T> where T: class, IRibbonElement<T> 
    {
        public static T Instance(String id)
        {
            var type = typeof (T);
            var constructor = type.GetConstructor(BindingFlags.NonPublic| BindingFlags.Instance | BindingFlags.FlattenHierarchy, null, new Type[] {typeof(String)}, null);
            return (T) constructor.Invoke(BindingFlags.NonPublic,null, new[]{id}, Thread.CurrentThread.CurrentCulture);
        }
    }
}