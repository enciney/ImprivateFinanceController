namespace ImprivateFinanceController.Api;

public class AssetRow
{
    public double Amount { get; set; }
    public string Description { get; set; } = null!;
    public Currency CurrencyType { get; set; }
    public string Currency => CurrencyType.ToString();
}
