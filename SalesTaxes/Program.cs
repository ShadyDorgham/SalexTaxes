using System;
using Autofac;
using SalesTaxes.DI;

namespace SalesTaxes
{
    public  class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplicationRunner>();
                app.run();
            }

            Console.ReadLine();
        }
    }
}
