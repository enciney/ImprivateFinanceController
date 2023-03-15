
using ImprivateFinanceController.Api.Contracts;
namespace ImprivateFinanceController.Api;

public interface IConverter
{   
    public Money Convert(Money money, Currency targetCurrency);
}

public class Converter : IConverter
{
    public Converter()
    {
    }
    // http://www.floatrates.com/daily/usd.json
    // https://goldprice.org/best-gold-price
    public Money Convert(Money money, Currency targetCurrency)
    {
        return null;
    }
}
