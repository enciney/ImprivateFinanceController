using ImprivateFinanceController.Api.Contracts;
using ImprivateFinanceController.Api.Dtos;

namespace ImprivateFinanceController.Api.Common.Interfaces;

public interface ICommodityClient : IClient
{
    Task<CommodityValueJson> GetCommoditiesByCurrency(Currency currency);
}