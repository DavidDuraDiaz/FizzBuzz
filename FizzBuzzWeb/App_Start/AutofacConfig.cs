using Autofac;
using Autofac.Integration.WebApi;
using FizzBuzzService.Interfaces;
using System.Reflection;
using System.Web.Http;

namespace FizzBuzzWeb
{
    public class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<FizzBuzzService.Services.FizzBuzzService>().As<IFizzBuzzService>().InstancePerDependency();


            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}