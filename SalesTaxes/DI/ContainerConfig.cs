using Autofac;
using SalesTaxes.Application.DomainService;
using SalesTaxes.Application.Helpers;

namespace SalesTaxes.DI
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ApplicationRunner>().As<IApplicationRunner>();
            builder.RegisterType<BusinessLogic>().As<IBusinessLogic>();
            builder.RegisterType<Rounding>().As<IRounding>();
            return builder.Build();
        }
    }
}
