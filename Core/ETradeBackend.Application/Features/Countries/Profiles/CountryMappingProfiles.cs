using AutoMapper;
using ETradeBackend.Application.Features.Countries.Commands.Create;
using ETradeBackend.Application.Features.Countries.Commands.Delete;
using ETradeBackend.Application.Features.Countries.Commands.Update;
using ETradeBackend.Application.Features.Countries.Queries.GetById;
using ETradeBackend.Application.Features.Countries.Queries.GetList;
using ETradeBackend.Domain.Entities;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Countries.Profiles;

public class CountryMappingProfiles : Profile
{
    public CountryMappingProfiles()
    {
        CreateMap<Country, CreateCountryCommand>().ReverseMap();
        CreateMap<Country, CreatedCountryResponse>().ReverseMap();
        CreateMap<Country, DeleteCountryCommand>().ReverseMap();
        CreateMap<Country, DeletedCountryResponse>().ReverseMap();
        CreateMap<Country, UpdateCountryCommand>().ReverseMap();
        CreateMap<Country, UpdatedCountryResponse>().ReverseMap();

        CreateMap<Country, GetListCountryListItemDto>().ReverseMap();
        CreateMap<Paginate<Country>, GetListResponse<GetListCountryListItemDto>>().ReverseMap();
        CreateMap<Country, GetByIdCountryResponse>().ReverseMap();
    }
}
