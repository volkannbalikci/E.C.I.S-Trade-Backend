using AutoMapper;
using ETradeBackend.Application.Features.Cities.Commands.Create;
using ETradeBackend.Application.Features.Cities.Commands.Delete;
using ETradeBackend.Application.Features.Cities.Commands.Update;
using ETradeBackend.Application.Features.Cities.Queries.GetById;
using ETradeBackend.Application.Features.Cities.Queries.GetList;
using ETradeBackend.Domain.Entities;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Cities.Profiles;

public class CityMappingProfiles : Profile
{
    public CityMappingProfiles()
    {
        CreateMap<City, CreateCityCommand>().ReverseMap();
        CreateMap<City, CreatedCityResponse>().ReverseMap();
        CreateMap<City, DeleteCityCommand>().ReverseMap();
        CreateMap<City, DeletedCityResponse>().ReverseMap();
        CreateMap<City, UpdateCityCommand>().ReverseMap();
        CreateMap<City, UpdatedCityResponse>().ReverseMap();

        CreateMap<Paginate<City>, GetListResponse<GetListCityListItemDto>>().ReverseMap();
        CreateMap<City, GetListCityListItemDto>()
            .ForMember(destinationMember: a => a.CityId, memberOptions: opt => opt.MapFrom(a => a.Id))
            .ForMember(destinationMember: a => a.CityName, memberOptions: opt => opt.MapFrom(a => a.Name))
            .ForMember(destinationMember: a => a.CountryId, memberOptions: opt => opt.MapFrom(a => a.Country.Id))
            .ForMember(destinationMember: a => a.CountryName, memberOptions: opt => opt.MapFrom(a => a.Country.Name))
            .ForMember(destinationMember: a => a.CountryShortName, memberOptions: opt => opt.MapFrom(a => a.Country.ShortName)).ReverseMap();

        CreateMap<City, GetByIdCityResponse>()
            .ForMember(destinationMember: a => a.CountryName, memberOptions: opt => opt.MapFrom(a => a.Country.Name))
            .ForMember(destinationMember: a => a.CountryShortName, memberOptions: opt => opt.MapFrom(a => a.Country.ShortName)).ReverseMap();

    }
}
