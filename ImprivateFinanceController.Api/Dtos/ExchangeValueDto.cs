using ImprivateFinanceController.Api.Contracts;
using Newtonsoft.Json;

namespace ImprivateFinanceController.Api.Dtos;

public class ExchangeValueDto
{
    
    public string SourceCurrenyName => SourceCurreny.ToString();
    public string TargetCurrencyName => TargetCurrency.ToString();

    [JsonIgnore]
    public Currency SourceCurreny{get; set;}

    [JsonIgnore]
    public Currency TargetCurrency { get; set; }
    public double Amount { get; set; }
   
}