using CinemaApp.Data.Repository;
using CinemaApp.Data.Repository.Interfaces;
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
using static CinemaApp.GCommon.ExceptionMessages;

namespace CinemaApp.Web.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private static readonly string ProjectInterfacePrefix = "I";
        private static readonly string RepositoryTypeSuffix = "Repository";
        private static readonly string ServiceTypeSuffix = "Service";
        public static IServiceCollection AddUserDefinedServices(this IServiceCollection serviceCollection, Assembly serviceAssembly)
        {
            Type[] serviceClasses = serviceAssembly
                .GetTypes()
                .Where(t => !t.IsInterface &&
                             t.Name.EndsWith(ServiceTypeSuffix))
                .ToArray();

            foreach (Type serviceClass in serviceClasses)
            {
                Type? serviceInterface = serviceClass
                    .GetInterfaces()
                    .FirstOrDefault(i => i.Name == $"{ProjectInterfacePrefix}{serviceClass.Name}");
                if (serviceInterface == null)
                {
                    throw new ArgumentException(string.Format(InterfaceNotFoundMessage, serviceClass.Name));

                }

                serviceCollection.AddScoped(serviceInterface, serviceClass);
            }

            return serviceCollection;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection,
            Assembly repositoryAssembly)
        {
            Type[] repositoryClasses = repositoryAssembly
                .GetTypes()
                .Where(t => !t.IsInterface &&
                            !t.IsAbstract &&
                             t.Name.EndsWith(RepositoryTypeSuffix))
                .ToArray();

            foreach (Type repositoryClass in repositoryClasses)
            {
                Type? repositoryInterface = repositoryClass
                    .GetInterfaces()
                    .FirstOrDefault(i => i.Name == $"{ProjectInterfacePrefix}{repositoryClass.Name}");
                if (repositoryInterface == null)
                {
                    throw new ArgumentException(string.Format(InterfaceNotFoundMessage, repositoryClass.Name));
                }

                serviceCollection.AddScoped(repositoryInterface, repositoryClass);
            }

            return serviceCollection;
        }
    }
}
