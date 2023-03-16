using ImprivateFinanceController.Api.Clients;
using ImprivateFinanceController.Api.Common;

namespace ImprivateFinanceController.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddScoped<HttpClientFactory>();
        services.AddScoped<ExchangeClient>();
        services.AddScoped<CommodityClient>();
        services.AddScoped<IConverter,Converter>();
        return services;
        
    }
}