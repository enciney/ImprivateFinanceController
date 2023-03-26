using AutoMapper;
using ImprivateFinanceController.Api.Common;
using ImprivateFinanceController.Api.Common.Interfaces;
using ImprivateFinanceController.Api.Contracts;
using Newtonsoft.Json;

namespace ImprivateFinanceController.Api.Clients;

public abstract class BaseClient
{
    public string Host { get; init; }
    protected readonly HttpClientFactory httpClientFactory;
    public BaseClient(HttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public virtual async Task<TTarget> Send<TTarget>(Currency currency)
    {
        var client = httpClientFactory.GetClient(string.Format(Host, currency.ToString()));
        var response = await client.SendAsync(new HttpRequestMessage(){ Method = HttpMethod.Get });
        var result = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<TTarget>(result);
    }
}