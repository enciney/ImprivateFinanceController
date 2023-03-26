using System.Net.Http;
using ImprivateFinanceController.Api.Common;
using ImprivateFinanceController.Api.Contracts;
using Newtonsoft.Json;
using System.Linq;
using AutoMapper;
using ImprivateFinanceController.Api.Dtos;
using ImprivateFinanceController.Api.Common.Interfaces;

namespace ImprivateFinanceController.Api.Clients;

public class CommodityClient : BaseClient,ICommodityClient
{
    public CommodityClient(HttpClientFactory httpClientFactory)
    : base(httpClientFactory)
    {
        this.Host = "https://data-asg.goldprice.org/dbXRates/{0}";
    }

    public async Task<CommodityValueJson> GetCommoditiesByCurrency(Currency currency){
        return await Send<CommodityValueJson>(currency);
    }
}