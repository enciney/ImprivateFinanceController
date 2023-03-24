using System.Net.Http;
using ImprivateFinanceController.Api.Common;
using ImprivateFinanceController.Api.Contracts;
using Newtonsoft.Json;
using System.Linq;
using AutoMapper;
using ImprivateFinanceController.Api.Dtos;

namespace ImprivateFinanceController.Api.Clients;

public class ExchangeClient : BaseClient
{
    
    public ExchangeClient(HttpClientFactory httpClientFactory, IMapper mapper)
    : base(httpClientFactory, mapper)
    {
        //https://www.iban.com/exchange-rates-api
        this.Host = "http://www.floatrates.com/daily/{0}.json";
    }

    public async Task<IEnumerable<ExchangeValueDto>> Send(){

        List<ExchangeValue> exchangeValues = new ();
        foreach(var currency in Enum.GetValues<Currency>())
        {
            if(currency == Currency.AUX){
                continue;
            }
            var client = httpClientFactory.GetClient(string.Format(Host, currency.ToString()));
            var response = await client.SendAsync(new HttpRequestMessage(){ Method = HttpMethod.Get });
            var result = await response.Content.ReadAsStringAsync();
            var exchanges = JsonConvert.DeserializeObject<Dictionary<string,ExchangeValue>>(result);
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
}