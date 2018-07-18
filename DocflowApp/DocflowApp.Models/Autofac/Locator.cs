using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocflowApp.Models.Autofac
{
    public static class Locator
    {
        private static ILocatorImpl impl;

        public static object GetService(Type type)
        {
            return impl.GetService(type);
        }

        public static T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }

        public static void SetImpl(ILocatorImpl locatorImpl)
        {
            impl = locatorImpl;
        }
    }
}
