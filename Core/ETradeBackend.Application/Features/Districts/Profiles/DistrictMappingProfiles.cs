using AutoMapper;
using ETradeBackend.Application.Features.Cities.Queries.GetList;
using ETradeBackend.Application.Features.Districts.Commands.Create;
using ETradeBackend.Application.Features.Districts.Commands.Delete;
using ETradeBackend.Application.Features.Districts.Commands.Update;
using ETradeBackend.Application.Features.Districts.Queries.GetById;
using ETradeBackend.Application.Features.Districts.Queries.GetList;
using ETradeBackend.Domain.Entities;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Districts.Profiles;

public class DistrictMappingProfiles : Profile
{
    public DistrictMappingProfiles()
    {
        CreateMap<District, CreateDistrictCommand>().ReverseMap();
        CreateMap<District, CreatedDistrictResponse>().ReverseMap();
        CreateMap<District, DeleteDistrictCommand>().ReverseMap();
        CreateMap<District, DeletedDistrictResponse>().ReverseMap();
        CreateMap<District, UpdateDistrictCommand>().ReverseMap();
        CreateMap<District, UpdatedDistrictResponse>().ReverseMap();

        CreateMap<Paginate<District>, GetListResponse<GetListDistrictListItemDto>>().ReverseMap();
        CreateMap<District, GetListDistrictListItemDto>()
            .ForMember(destinationMember: a => a.Id, memberOptions: opt => opt.MapFrom(a => a.Id))
            .ForMember(destinationMember: a => a.CityId, memberOptions: opt => opt.MapFrom(a => a.City.Id))
            .ForMember(destinationMember: a => a.CityName, memberOptions: opt => opt.MapFrom(a => a.City.Name))
            .ForMember(destinationMember: a => a.DistrictName, memberOptions: opt => opt.MapFrom(a => a.Name)).ReverseMap();
        CreateMap<District, GetByIdDistrictResponse>().ReverseMap();
    }
}
