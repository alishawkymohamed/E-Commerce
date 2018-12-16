using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IBusinessServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;

namespace EnterpriseApplication
{
    public static partial class IServiceCollectionExtenstions
    {
        private static void AddBusinessServicesClasses(this IServiceCollection services, IEnumerable<Assembly> assembliesToScan)
        {
            assembliesToScan = assembliesToScan as Assembly[] ?? assembliesToScan.ToArray();

            var allTypes = assembliesToScan.SelectMany(a => { try { return a.ExportedTypes; } catch { return new List<System.Type>(); } }).ToArray();

            var businessServices =
            allTypes
                .Where(t => t.GetInterfaces().Contains(typeof(_IBusinessService)))
                .Where(t => !t.GetTypeInfo().IsAbstract);

            foreach (var businessService in businessServices)
            {
                foreach (var businessServiceInterface in businessService.GetInterfaces().Except(businessService.GetTypeInfo().BaseType.GetInterfaces()))
                {
                    services.AddScoped(businessServiceInterface, businessService);
                }
            }
        }
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddBusinessServices(DependencyContext.Default);
        }

        public static void AddBusinessServices(this IServiceCollection services, DependencyContext dependencyContext)
        {
            services.AddBusinessServicesClasses(dependencyContext.RuntimeLibraries
                .SelectMany(lib => lib.GetDefaultAssemblyNames(dependencyContext).Select(Assembly.Load)));
        }
    }
}
