using Microsoft.AspNetCore.Mvc;

namespace ImprivateFinanceController.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AssetController : ControllerBase
{
    private static readonly List<AssetRow> assets = new();

    [HttpGet("get")]
    public IList<AssetRow> GetAssets()
    {
        return assets;
    }

    [HttpPost("add")]
    public void AddAsset( AssetRow asset)
    {
        assets.Add(asset);
    }
}
