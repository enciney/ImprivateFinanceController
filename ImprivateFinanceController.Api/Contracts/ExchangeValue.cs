using Newtonsoft.Json;

namespace ImprivateFinanceController.Api.Contracts;

public class ExchangeValue
{
     [JsonIgnore]
    public string SourceCurreny{get; set;} = null!;
    public string Code { get; set; } = null!;
    public double Rate { get; set; }
   
}