using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IHelperServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;

namespace EnterpriseApplication
{
    public static partial class IServiceCollectionExtenstions
    {
        private static void AddHelperServicesClasses(this IServiceCollection services, IEnumerable<Assembly> assembliesToScan)
        {
            assembliesToScan = assembliesToScan as Assembly[] ?? assembliesToScan.ToArray();

            var allTypes = assembliesToScan.SelectMany(a => { try { return a.ExportedTypes; } catch { return new List<System.Type>(); } }).ToArray();

            var HelperServices =
            allTypes
                .Where(t => t.GetInterfaces().Contains(typeof(_IHelperService)))
                .Where(t => !t.GetTypeInfo().IsAbstract);

            foreach (var HelperService in HelperServices)
            {
                foreach (var HelperServiceInterface in HelperService.GetInterfaces().Except(HelperService.GetTypeInfo().BaseType.GetInterfaces()))
                {
                    services.AddSingleton(HelperServiceInterface, HelperService);
                }
            }
        }
        public static void AddHelperServices(this IServiceCollection services)
        {
            services.AddHelperServices(DependencyContext.Default);
        }

        public static void AddHelperServices(this IServiceCollection services, DependencyContext dependencyContext)
        {
            services.AddHelperServicesClasses(dependencyContext.RuntimeLibraries
                .SelectMany(lib => lib.GetDefaultAssemblyNames(dependencyContext).Select(Assembly.Load)));
        }
    }
}
