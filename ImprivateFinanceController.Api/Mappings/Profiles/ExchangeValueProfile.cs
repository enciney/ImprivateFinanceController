using AutoMapper;
using ImprivateFinanceController.Api.Contracts;
using ImprivateFinanceController.Api.Dtos;

namespace ImprivateFinanceController.Api.Mappings.Profiles;

public class ExchangeValueProfile : Profile
{
    public ExchangeValueProfile()
    {
        CreateMap<ExchangeValue, ExchangeValueDto>()
        .ForMember(x => x.SourceCurreny, y => y.MapFrom(s => CastToEnum(s.SourceCurreny)))
        .ForMember(x => x.TargetCurrency, y => y.MapFrom(s => CastToEnum(s.Code)))
        .ForMember(x => x.Amount, y => y.MapFrom(s => s.Rate));
                CreateMap<CommodityValue, ExchangeValueDto>()
        .ForMember(x => x.SourceCurreny, y => y.MapFrom(s => CastToEnum(s.SourceCurreny)))
        .ForMember(x => x.TargetCurrency, y => y.MapFrom(s => CastToEnum(s.Code)))
        .ForMember(x => x.Amount, y => y.MapFrom(s => s.RateGram));
    }

    private Currency CastToEnum(string value)
    {
        return Enum.Parse<Currency>(value);

    }
}