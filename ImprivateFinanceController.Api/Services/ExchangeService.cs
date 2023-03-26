using AutoMapper;
using ImprivateFinanceController.Api.Common.Interfaces;
using ImprivateFinanceController.Api.Contracts;
using ImprivateFinanceController.Api.Dtos;

namespace ImprivateFinanceController.Api.Services;

public class ExchangeService
{
    private readonly IAssetClient assetClient ;
    private readonly ICommodityClient commodityClient ;
    private readonly IMapper mapper ;


    public ExchangeService(IAssetClient assetClient, ICommodityClient commodityClient, IMapper mapper)
    {
        this.assetClient = assetClient;
        this.commodityClient = commodityClient;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<ExchangeValueDto>> GetExchangeRates()
    {
        var assets = await GetAssets();
        var commodities = await GetCommodities();
        // TO DO cache below value
        var allExchangeValues = assets.Concat(commodities);
        return allExchangeValues;
    }

    private async Task<IEnumerable<ExchangeValueDto>> GetAssets()
    {
        List<ExchangeValue> exchangeValues = new ();
        foreach(var currency in Enum.GetValues<Currency>())
        {
            if(currency == Currency.AUX){
                continue;
            }
            var exchanges = await assetClient.GetAssetsByCurrency(currency);
            exchangeValues.AddRange(
                exchanges.Where(s => Enum.GetNames<Currency>().Contains(s.Key, StringComparer.CurrentCultureIgnoreCase))
                .Select(s => new ExchangeValue() 
                { 
                    Code= s.Value.Code,
                    Rate= s.Value.Rate,
                    SourceCurreny= currency.ToString(),
                })
            );
        }
        return exchangeValues.Select( exVal => mapper.Map<ExchangeValueDto>(exVal));
    }

    private async Task<IEnumerable<ExchangeValueDto>> GetCommodities()
    {
        List<CommodityValue> exchangeValues = new ();
        foreach(var currency in Enum.GetValues<Currency>())
        {
            if(currency == Currency.AUX)
            {
                continue;
            }
            var commodities = await commodityClient.GetCommoditiesByCurrency(currency);
            exchangeValues.Add(commodities.Items.First());
        }
        return exchangeValues.Select(exVal=> mapper.Map<ExchangeValueDto>(exVal));
    }
}