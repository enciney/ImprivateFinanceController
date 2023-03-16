using Microsoft.AspNetCore.Mvc;
using ImprivateFinanceController.Api.Contracts;
using ImprivateFinanceController.Api.Clients;

namespace ImprivateFinanceController.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ExchangeController : ControllerBase
{
    
    private readonly ExchangeClient exchangeClient;

    public ExchangeController(ExchangeClient exchangeClient)
    {
        this.exchangeClient = exchangeClient;
    }

    [HttpGet("get")]
    public IList<ExchangeValue> GetExchanges()
    {
        return exchangeClient.Send().GetAwaiter().GetResult();
    }

}
