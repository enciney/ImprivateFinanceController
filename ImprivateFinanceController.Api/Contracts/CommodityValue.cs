using Newtonsoft.Json;

namespace ImprivateFinanceController.Api.Contracts;

public class CommodityValue
{
    private const double OuncetoGram = 31.1034768d;

    [JsonIgnore]
    public string SourceCurreny => Currency.AUX.ToString();

    [JsonProperty("curr")]
    public string Code { get; set; } = null!;

    [JsonProperty("xauPrice")]
    public double RateOunce { get; set; }

    [JsonIgnore]
    public double RateGram => RateOunce / OuncetoGram;
   
}

public class CommodityValueJson
{
    public string Date { get; set; } = null!;
    public List<CommodityValue> Items { get; set; }
}