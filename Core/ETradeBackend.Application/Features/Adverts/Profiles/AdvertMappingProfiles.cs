using AutoMapper;
using ETradeBackend.Application.Features.Adverts.Commands.Create;
using ETradeBackend.Application.Features.Adverts.Commands.Delete;
using ETradeBackend.Application.Features.Adverts.Commands.Update;
using ETradeBackend.Application.Features.Adverts.Queries.GetById;
using ETradeBackend.Application.Features.Adverts.Queries.GetList;
using ETradeBackend.Domain.Entities;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Adverts.Profiles;

public class AdvertMappingProfiles : Profile
{
    public AdvertMappingProfiles()
    {
        CreateMap<Advert, CreateAdvertCommand>().ReverseMap();
        CreateMap<Advert, CreatedAdvertResponse>().ReverseMap();
        CreateMap<Advert, DeleteAdvertCommand>().ReverseMap();
        CreateMap<Advert, DeletedAdvertResponse>().ReverseMap();
        CreateMap<Advert, UpdateAdvertCommand>().ReverseMap();
        CreateMap<Advert, UpdatedAdvertResponse>().ReverseMap();

        CreateMap<Paginate<Advert>, GetListResponse<GetListAdvertListItemDto>>().ReverseMap();
        CreateMap<Advert, GetListAdvertListItemDto>()
            .ForMember(destinationMember: a => a.CountryName, memberOptions: opt => opt.MapFrom(a => a.Address.Country.Name))
            .ForMember(destinationMember: a => a.CityName, memberOptions: opt => opt.MapFrom(a => a.Address.City.Name))
            .ForMember(destinationMember: a => a.DistrictName, memberOptions: opt => opt.MapFrom(a => a.Address.District.Name))
            .ForMember(destinationMember: a => a.NeighbourhoodName, memberOptions: opt => opt.MapFrom(a => a.Address.Neighbourhood.Name))
            .ForMember(destinationMember: a => a.ProductName, memberOptions: opt => opt.MapFrom(a => a.Product.Name))
            .ForMember(destinationMember: a => a.BrandName, memberOptions: opt => opt.MapFrom(a => a.Product.Brand.Name))
            .ForMember(destinationMember: a => a.CategoryName, memberOptions: opt => opt.MapFrom(a => a.Product.Category.Name)).ReverseMap();

        CreateMap<Advert, GetByIdAdvertResponse>()
            .ForMember(destinationMember: a => a.CountryName, memberOptions: opt => opt.MapFrom(a => a.Address.Country.Name))
            .ForMember(destinationMember: a => a.CityName, memberOptions: opt => opt.MapFrom(a => a.Address.City.Name))
            .ForMember(destinationMember: a => a.DistrictName, memberOptions: opt => opt.MapFrom(a => a.Address.District.Name))
            .ForMember(destinationMember: a => a.NeighbourhoodName, memberOptions: opt => opt.MapFrom(a => a.Address.Neighbourhood.Name))
            .ForMember(destinationMember: a => a.ProductName, memberOptions: opt => opt.MapFrom(a => a.Product.Name))
            .ForMember(destinationMember: a => a.BrandName, memberOptions: opt => opt.MapFrom(a => a.Product.Brand.Name))
            .ForMember(destinationMember: a => a.CategoryName, memberOptions: opt => opt.MapFrom(a => a.Product.Category.Name)).ReverseMap();
    }
}
