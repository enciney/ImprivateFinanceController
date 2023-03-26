using System.Net.Http;
using ImprivateFinanceController.Api.Common;
using ImprivateFinanceController.Api.Contracts;
using Newtonsoft.Json;
using System.Linq;
using AutoMapper;
using ImprivateFinanceController.Api.Dtos;
using ImprivateFinanceController.Api.Common.Interfaces;

namespace ImprivateFinanceController.Api.Clients;

public class AssetClient : BaseClient, IAssetClient
{
    public AssetClient(HttpClientFactory httpClientFactory)
    : base(httpClientFactory)
    {
        //https://www.iban.com/exchange-rates-api
        this.Host = "http://www.floatrates.com/daily/{0}.json";
    }

    public async Task<Dictionary<string,ExchangeValue>> GetAssetsByCurrency(Currency currency)
    {
        return await Send<Dictionary<string,ExchangeValue>>(currency);
    }
}