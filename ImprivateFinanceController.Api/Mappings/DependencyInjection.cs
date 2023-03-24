using System.Reflection;
namespace ImprivateFinanceController.Api.Mappings;

public static class DependencyInjection
{
    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly()); 
        return services;
    }
}