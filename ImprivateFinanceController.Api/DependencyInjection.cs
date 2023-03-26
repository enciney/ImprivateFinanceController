using ImprivateFinanceController.Api.Clients;
using ImprivateFinanceController.Api.Common;
using ImprivateFinanceController.Api.Common.Interfaces;
using ImprivateFinanceController.Api.Services;

namespace ImprivateFinanceController.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddScoped<HttpClientFactory>();
        services.AddScoped<IAssetClient,AssetClient>();
        services.AddScoped<ICommodityClient,CommodityClient>();
        services.AddScoped<ExchangeService>();
        return services;
        
    }
}