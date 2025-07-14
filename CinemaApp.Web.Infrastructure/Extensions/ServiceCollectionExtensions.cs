using CinemaApp.Services.Core;
using CinemaApp.Services.Core.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Web.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private static readonly string ServiceInterfacePrefix = "I";    

        private const string ServiceTypeSuffix = "Service";
        public static IServiceCollection AddUserDefinedServices(this IServiceCollection serviceCollection, Assembly serviceAssembly)
        {
            Type[] serviceClasses = serviceAssembly
                .GetTypes()
                .Where(t => !t.IsInterface &&
                             t.Name.EndsWith(ServiceTypeSuffix))
                .ToArray();

            foreach (Type serviceClass in serviceClasses)
            {
                Type[] serviceClassInterfaces = serviceClass
                    .GetInterfaces();
                if (serviceClassInterfaces.Length == 1 &&
                    serviceClassInterfaces.First().Name.StartsWith(ServiceInterfacePrefix) &&
                    serviceClassInterfaces.First().Name.EndsWith(ServiceTypeSuffix))
                {
                    Type serviceClassInterface = serviceClassInterfaces[0];

                    serviceCollection.AddScoped(serviceClassInterface, serviceClass);
                }
            }

            return serviceCollection;
        }
    }
}
