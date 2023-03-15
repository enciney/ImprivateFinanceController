namespace ImprivateFinanceController.Api.Contracts;
public class AssetRow
{
    public Money Money { get; set; }
    public string Description { get; set; } = null!;
}

public class Money
{
    public double Amount { get; set; }
    public Currency CurrencyType { get; set; }
    public string Currency => CurrencyType.ToString();
}
