using System.Net.Http;
using ImprivateFinanceController.Api.Common;
using ImprivateFinanceController.Api.Contracts;
using Newtonsoft.Json;
using System.Linq;
using AutoMapper;
using ImprivateFinanceController.Api.Dtos;

namespace ImprivateFinanceController.Api.Clients;

public class CommodityClient : BaseClient
{
    public CommodityClient(HttpClientFactory httpClientFactory, IMapper mapper)
    : base(httpClientFactory, mapper)
    {
        this.Host = "https://data-asg.goldprice.org/dbXRates/{0}";
    }

    public async Task<IEnumerable<ExchangeValueDto>> Send(){

        List<CommodityValue> exchangeValues = new ();
        foreach(var currency in Enum.GetValues<Currency>())
        {
            if(currency == Currency.AUX)
            {
                continue;
            }
            var client = httpClientFactory.GetClient(string.Format(Host, currency.ToString()));
            var response = await client.SendAsync(new HttpRequestMessage(){ Method = HttpMethod.Get });
            var result = await response.Content.ReadAsStringAsync();
            var exchanges = JsonConvert.DeserializeObject<CommodityValueJson>(result);
            exchangeValues.Add(exchanges.Items.First());
        }
        return exchangeValues.Select(exVal=> mapper.Map<ExchangeValueDto>(exVal));
    }
}