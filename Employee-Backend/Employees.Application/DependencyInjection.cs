using System.Reflection;
using Employees.Application.Mappings;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Employees.Application;

public static class DependencyInjection
{
   public static IServiceCollection AddApplication(this IServiceCollection services)
   {
      services.AddMediatR(cf =>
      {
         cf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
      });
      
      MappingConfig.Configure();
      var config = TypeAdapterConfig.GlobalSettings;
      config.Scan(Assembly.GetExecutingAssembly());
      services.AddSingleton(config);

      return services;
   }
}