using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocflowApp.Models.Autofac
{
    public class AutofacLocatorImpl : ILocatorImpl
    {
        private IContainer container;

        public AutofacLocatorImpl(IContainer container)
        {
            this.container = container;
        }

        public object GetService(Type type)
        {
            object instance = null;
            container.TryResolve(type, out instance);
            return instance;
        }
    }
}
