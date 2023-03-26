using Microsoft.AspNetCore.Mvc;
using ImprivateFinanceController.Api.Contracts;
using ImprivateFinanceController.Api.Clients;
using ImprivateFinanceController.Api.Dtos;
using ImprivateFinanceController.Api.Services;

namespace ImprivateFinanceController.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ExchangeController : ControllerBase
{
    // TO DO create a inerface for this service
    private readonly ExchangeService exchangeService;

    public ExchangeController(ExchangeService exchangeService)
    {
        this.exchangeService = exchangeService;
    }

    [HttpGet("exchanges")]
    public async Task<IEnumerable<ExchangeValueDto>> GetExchanges()
    {
        return await exchangeService.GetExchangeRates();
    }

}
