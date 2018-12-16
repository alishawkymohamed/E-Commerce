using AutoMapper;
using AutoMapper.Configuration;
using IBusinessServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EnterpriseApplication
{
    public static partial class IServiceCollectionExtenstions
    {
        private static void AddAutoMapperClasses(this IServiceCollection services, IEnumerable<Assembly> assembliesToScan)
        {
            assembliesToScan = assembliesToScan as Assembly[] ?? assembliesToScan.ToArray();

            var allTypes = assembliesToScan.SelectMany(a => { try { return a.ExportedTypes; } catch { return new List<System.Type>(); } }).ToArray();

            var profiles =
            allTypes
                .Where(t => typeof(Profile).GetTypeInfo().IsAssignableFrom(t.GetTypeInfo()))
                .Where(t => !t.GetTypeInfo().IsAbstract);
            var mapperConfigurationExpression = new MapperConfigurationExpression();
            //create maps based on existing profiles
            foreach (var profile in profiles)
            {
                mapperConfigurationExpression.AddProfile(profile);
            }
            var config = new MapperConfiguration(mapperConfigurationExpression);
            //create maps based on generic business services
            var businessServices =
            allTypes
                .Where(t => t.GetInterfaces().Contains(typeof(_IBusinessService)))
                .Where(t => !t.GetTypeInfo().IsAbstract);
            foreach (var businessService in businessServices)
            {
                foreach (Type SourceType in businessService.GetTypeInfo().BaseType.GenericTypeArguments)
                {
                    foreach (Type DestinationType in businessService.GetTypeInfo().BaseType.GenericTypeArguments)
                    {
                        if (config.FindTypeMapFor(SourceType, DestinationType) == null)
                        {
                            mapperConfigurationExpression.CreateProfile(SourceType.FullName.Replace('.', '_') + '_' + DestinationType.FullName.Replace('.', '_'), (profileConfig) =>
                            {
                                profileConfig.CreateMap(SourceType, DestinationType);
                            });
                        }
                        else
                        {

                        }
                    }
                }
            }
            //other configuration
            //mapperConfigurationExpression.CreateMissingTypeMaps = true;
            //mapperConfigurationExpression.ForAllMaps((a, b) => {
            //   foreach(prop)
            //});
            config = new MapperConfiguration(mapperConfigurationExpression);
            services.AddSingleton(sp => config.CreateMapper());
        }
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(DependencyContext.Default);
        }

        public static void AddAutoMapper(this IServiceCollection services, DependencyContext dependencyContext)
        {
            services.AddAutoMapperClasses(dependencyContext.RuntimeLibraries
                .SelectMany(lib => lib.GetDefaultAssemblyNames(dependencyContext).Select(Assembly.Load)));
        }
    }
}
