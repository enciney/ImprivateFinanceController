using AutoMapper;
using ImprivateFinanceController.Api.Common;

namespace ImprivateFinanceController.Api.Clients;

public abstract class BaseClient
{
    public string Host { get; init; }
    protected readonly HttpClientFactory httpClientFactory;
    protected readonly IMapper mapper;

    public BaseClient(HttpClientFactory httpClientFactory, IMapper mapper)
    {
        this.httpClientFactory = httpClientFactory;
        this.mapper = mapper;
    }

    // public TTarget Map<TSource,TTarget>(TSource data)
    // {
    //     return mapper.Map<TTarget>(data);
    // }
}