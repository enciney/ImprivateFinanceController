using System.Net.Http;
using ImprivateFinanceController.Api.Common;
using ImprivateFinanceController.Api.Contracts;
using Newtonsoft.Json;
using System.Linq;

namespace ImprivateFinanceController.Api.Clients;

public class CommodityClient
{
    public const string Host = "https://data-asg.goldprice.org/dbXRates/{0}";
    
    private readonly HttpClientFactory httpClientFactory;

    public CommodityClient(HttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<IList<CommodityValue>> Send(){

        List<CommodityValue> exchangeVaues = new ();
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
            exchangeVaues.Add(exchanges.Items.First());
        }
        return exchangeVaues;
    }
}