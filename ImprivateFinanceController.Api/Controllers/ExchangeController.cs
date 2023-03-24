using Microsoft.AspNetCore.Mvc;
using ImprivateFinanceController.Api.Contracts;
using ImprivateFinanceController.Api.Clients;
using ImprivateFinanceController.Api.Dtos;

namespace ImprivateFinanceController.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ExchangeController : ControllerBase
{
    private readonly ExchangeClient exchangeClient;
    private readonly CommodityClient commodityClient;

    public ExchangeController(ExchangeClient exchangeClient, CommodityClient commodityClient)
    {
        this.exchangeClient = exchangeClient;
        this.commodityClient = commodityClient;
    }

    [HttpGet("exchanges")]
    public IEnumerable<ExchangeValueDto> GetExchanges()
    {
        var exchangeValues = exchangeClient.Send().GetAwaiter().GetResult();
        var commodityValues = commodityClient.Send().GetAwaiter().GetResult();
        return exchangeValues.Union(commodityValues);
    }

}
