using ImprivateFinanceController.Api.Contracts;
using ImprivateFinanceController.Api.Dtos;

namespace ImprivateFinanceController.Api.Common.Interfaces;

public interface IAssetClient : IClient
{
    Task<Dictionary<string,ExchangeValue>> GetAssetsByCurrency(Currency currency);
}