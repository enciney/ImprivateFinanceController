using Microsoft.AspNetCore.Mvc;
using ImprivateFinanceController.Api.Dtos;
using ImprivateFinanceController.Api.Services;
using Microsoft.AspNetCore.Cors;

namespace ImprivateFinanceController.Api.Controllers;

[ApiController]
[Route("[controller]")]
[EnableCors("AllowAll")]
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
