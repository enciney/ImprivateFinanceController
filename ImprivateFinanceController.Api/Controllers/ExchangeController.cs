using Microsoft.AspNetCore.Mvc;
using ImprivateFinanceController.Api.Contracts;
using ImprivateFinanceController.Api.Clients;

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
    public IList<ExchangeValue> GetExchanges()
    {
        return exchangeClient.Send().GetAwaiter().GetResult();
    }

    [HttpGet("commodityExchanges")]
    public IList<CommodityValue> GetCommodity()
    {
        return commodityClient.Send().GetAwaiter().GetResult();
    }

}
