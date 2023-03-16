
using ImprivateFinanceController.Api.Clients;
using ImprivateFinanceController.Api.Common;
using ImprivateFinanceController.Api.Contracts;
namespace ImprivateFinanceController.Api;

public interface IConverter
{   
    public List<ExchangeValue> Convert(Money money, Currency targetCurrency);
}

public class Converter : IConverter
{
    private readonly ExchangeClient exchangeClient;
    public Converter(ExchangeClient exchangeClient)
    {
        this.exchangeClient = exchangeClient;
    }
    // https://goldprice.org/best-gold-price
    public List<ExchangeValue> Convert(Money money, Currency targetCurrency)
    {
        return null;
        // return exchangeClient.Send().GetAwaiter().GetResult();
    }
}
