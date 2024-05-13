using AutoMapper;
using ETradeBackend.Application.Features.Districts.Commands.Create;
using ETradeBackend.Application.Features.Districts.Commands.Delete;
using ETradeBackend.Application.Features.Districts.Commands.Update;
using ETradeBackend.Application.Features.Districts.Queries.GetById;
using ETradeBackend.Application.Features.Districts.Queries.GetList;
using ETradeBackend.Application.Features.Neighbourhoods.Commands.Create;
using ETradeBackend.Application.Features.Neighbourhoods.Commands.Delete;
using ETradeBackend.Application.Features.Neighbourhoods.Commands.Update;
using ETradeBackend.Application.Features.Neighbourhoods.Queries.GetById;
using ETradeBackend.Application.Features.Neighbourhoods.Queries.GetList;
using ETradeBackend.Domain.Entities;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Neighbourhoods.Profiles;

public class NeighbourhoodMappingProfiles : Profile
{
    public NeighbourhoodMappingProfiles()
    {
        CreateMap<Neighbourhood, CreateNeighbourhoodCommand>().ReverseMap();
        CreateMap<Neighbourhood, CreatedNeighbourhoodResponse>().ReverseMap();
        CreateMap<Neighbourhood, DeleteNeighbourhoodCommand>().ReverseMap();
        CreateMap<Neighbourhood, DeletedNeighbourhoodResponse>().ReverseMap();
        CreateMap<Neighbourhood, UpdateNeighbourhoodCommand>().ReverseMap();
        CreateMap<Neighbourhood, UpdatedNeighbourhoodResponse>().ReverseMap();

        CreateMap<Paginate<Neighbourhood>, GetListResponse<GetListNeighbourhoodListItemDto>>().ReverseMap();
        CreateMap<District, GetListNeighbourhoodListItemDto>()
            .ForMember(destinationMember: a => a.DistrictName, memberOptions: opt => opt.MapFrom(a => a.Name));
        CreateMap<Neighbourhood, GetListNeighbourhoodListItemDto>().ReverseMap();
        CreateMap<Neighbourhood, GetByIdNeighbourhoodResponse>().ReverseMap();
    }
}