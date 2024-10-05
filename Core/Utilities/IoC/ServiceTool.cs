using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.IoC
{
    public static class ServiceTool //Autofac'te yazdığımız injectionları istedğimiz her yerde kullanmamıza yarar.
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services) //IServiceCollection, DependencyInjection'dan gelir.
        {
            // IServiceCollection, bağımlılıkların eklendiği koleksiyonun kendisidir.
            ServiceProvider = services.BuildServiceProvider(); // BuildServiceProvider(): It is part of the ASP.NET Core framework and is used to construct an instance of the service provider, which is responsible for managing the dependency injection container and resolving dependencies for your application.
            return services;
        }
    }
}
