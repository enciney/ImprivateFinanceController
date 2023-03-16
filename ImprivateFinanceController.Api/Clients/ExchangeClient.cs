using System.Net.Http;
using ImprivateFinanceController.Api.Common;
using ImprivateFinanceController.Api.Contracts;
using Newtonsoft.Json;
using System.Linq;

namespace ImprivateFinanceController.Api.Clients;

public class ExchangeClient
{
    //https://www.iban.com/exchange-rates-api
    public const string Host = "http://www.floatrates.com/daily/{0}.json";
    private readonly HttpClientFactory httpClientFactory;

    public ExchangeClient(HttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<IList<ExchangeValue>> Send(){

        List<ExchangeValue> exchangeVaues = new ();
        foreach(var currency in Enum.GetValues<Currency>())
        {
            if(currency == Currency.AUX){
                continue;
            }
            var client = httpClientFactory.GetClient(string.Format(Host, currency.ToString()));
            var response = await client.SendAsync(new HttpRequestMessage(){ Method = HttpMethod.Get });
            var result = await response.Content.ReadAsStringAsync();
            var exchanges = JsonConvert.DeserializeObject<Dictionary<string,ExchangeValue>>(result);
            exchangeVaues.AddRange(
                exchanges.Where(s => Enum.GetNames<Currency>().Contains(s.Key, StringComparer.CurrentCultureIgnoreCase))
                .Select(s => new ExchangeValue() 
                { 
                    Code= s.Value.Code,
                    Rate= s.Value.Rate,
                    SourceCurreny= currency.ToString(),
                })
            );
        }
        return exchangeVaues;
    }
}