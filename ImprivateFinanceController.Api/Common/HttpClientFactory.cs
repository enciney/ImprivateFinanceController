using System.Net.Http;
namespace ImprivateFinanceController.Api.Common;

public class HttpClientFactory
{
    private readonly IHttpClientFactory httpClientFactory;

    public HttpClientFactory(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public HttpClient GetClient(string host )
    {
        var client =  httpClientFactory.CreateClient();
        client.BaseAddress = new UriBuilder(host).Uri;
        return client;
    }
}