using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var build = new ContainerBuilder();
            build.RegisterType<EmailSender>();
            build.RegisterType<AddressService>().SingleInstance();
            var container = build.Build();

            var emailSender = container.Resolve<EmailSender>();
            var addressService = container.Resolve<AddressService>();
            Console.ReadKey();
        }
    }
}
