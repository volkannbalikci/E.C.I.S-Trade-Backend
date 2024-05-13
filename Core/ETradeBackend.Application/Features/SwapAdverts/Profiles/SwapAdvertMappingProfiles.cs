using AutoMapper;
using ETradeBackend.Application.Features.IndividualAdverts.Commands.Create;
using ETradeBackend.Application.Features.IndividualAdverts.Commands.Delete;
using ETradeBackend.Application.Features.IndividualAdverts.Commands.Update;
using ETradeBackend.Application.Features.IndividualAdverts.Queries.GetById;
using ETradeBackend.Application.Features.IndividualAdverts.Queries.GetList;
using ETradeBackend.Application.Features.SwapAdverts.Commands.Create;
using ETradeBackend.Application.Features.SwapAdverts.Commands.Delete;
using ETradeBackend.Application.Features.SwapAdverts.Commands.Update;
using ETradeBackend.Application.Features.SwapAdverts.Queries.GetById;
using ETradeBackend.Application.Features.SwapAdverts.Queries.GetList;
using ETradeBackend.Domain.Entities;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.SwapAdverts.Profiles;

public class SwapAdvertMappingProfiles : Profile
{
    public SwapAdvertMappingProfiles()
    {
        CreateMap<SwapAdvert, CreateSwapAdvertCommand>().ReverseMap();
        CreateMap<CreateSwapAdvertCommand, CreatedSwapAdvertResponse>().ReverseMap();
        CreateMap<SwapAdvert, CreateSwapAdvertCommand>().ReverseMap();
        CreateMap<SwapAdvert, CreatedIndividualAdvertResponse>().ReverseMap();
        CreateMap<Advert, CreatedIndividualAdvertResponse>().ReverseMap();
        CreateMap<SwapAdvert, DeleteSwapAdvertCommand>().ReverseMap();
        CreateMap<SwapAdvert, DeletedSwapAdvertResponse>().ReverseMap();
        CreateMap<DeleteSwapAdvertCommand, DeletedSwapAdvertResponse>().ReverseMap();

        CreateMap<Advert, UpdateSwapAdvertCommand>()
            .ForMember(destinationMember: i => i.Title, memberOptions: opt => opt.MapFrom(i => i.Title))
            .ForMember(destinationMember: i => i.Description, memberOptions: opt => opt.MapFrom(i => i.Description))
            .ForMember(destinationMember: i => i.AddressId, memberOptions: opt => opt.MapFrom(i => i.AddressId)).ReverseMap();


        CreateMap<SwapAdvert, UpdatedSwapAdvertResponse>()
                  .ForMember(destinationMember: i => i.SwapAdvertId, memberOptions: opt => opt.MapFrom(i => i.Id))
                  .ForMember(destinationMember: i => i.AdvertId, memberOptions: opt => opt.MapFrom(i => i.AdvertId))
                .ForMember(destinationMember: i => i.AddressId, memberOptions: opt => opt.MapFrom(i => i.Advert.Address.Id))
                .ForMember(destinationMember: i => i.CountryName, memberOptions: opt => opt.MapFrom(i => i.Advert.Address.Country.Name))
                .ForMember(destinationMember: i => i.CityName, memberOptions: opt => opt.MapFrom(i => i.Advert.Address.City.Name))
                .ForMember(destinationMember: i => i.DistrictName, memberOptions: opt => opt.MapFrom(i => i.Advert.Address.District.Name))
                .ForMember(destinationMember: i => i.NeighbourhoodName, memberOptions: opt => opt.MapFrom(i => i.Advert.Address.Neighbourhood.Name))
                .ForMember(destinationMember: i => i.AdvertId, memberOptions: opt => opt.MapFrom(i => i.Advert.Id))
                .ForMember(destinationMember: i => i.ProductName, memberOptions: opt => opt.MapFrom(i => i.Advert.Product.Name))
                .ForMember(destinationMember: i => i.CategoryName, memberOptions: opt => opt.MapFrom(i => i.Advert.Product.Category.Name))
                .ForMember(destinationMember: i => i.BrandName, memberOptions: opt => opt.MapFrom(i => i.Advert.Product.Brand.Name))
                .ForMember(destinationMember: i => i.Title, memberOptions: opt => opt.MapFrom(i => i.Advert.Title))
                .ForMember(destinationMember: i => i.Description, memberOptions: opt => opt.MapFrom(i => i.Advert.Description))
                .ForMember(destinationMember: i => i.IndividualUserId, memberOptions: opt => opt.MapFrom(i => i.IndividualUser.Id))
                .ForMember(destinationMember: i => i.IndividualUserId, memberOptions: opt => opt.MapFrom(i => i.IndividualUser.Id))
                .ForMember(destinationMember: i => i.IndividualUserUserId, memberOptions: opt => opt.MapFrom(i => i.IndividualUser.UserId))
                .ForMember(destinationMember: i => i.IndividualUserFirstName, memberOptions: opt => opt.MapFrom(i => i.IndividualUser.FirstName))
                .ForMember(destinationMember: i => i.IndividualUserLastName, memberOptions: opt => opt.MapFrom(i => i.IndividualUser.LastName))
                .ForMember(destinationMember: i => i.IndividualUserUserName, memberOptions: opt => opt.MapFrom(i => i.IndividualUser.UserName)).ReverseMap();

        CreateMap<Paginate<SwapAdvert>, GetListResponse<GetListSwapAdvertListItemDto>>().ReverseMap();
        CreateMap<SwapAdvert, GetListSwapAdvertListItemDto>()
                .ForMember(destinationMember: i => i.SwapAdvertId, memberOptions: opt => opt.MapFrom(i => i.Id))
                .ForMember(destinationMember: i => i.AdvertId, memberOptions: opt => opt.MapFrom(i => i.AdvertId))
                .ForMember(destinationMember: i => i.AddressId, memberOptions: opt => opt.MapFrom(i => i.Advert.Address.Id))
                .ForMember(destinationMember: i => i.CountryName, memberOptions: opt => opt.MapFrom(i => i.Advert.Address.Country.Name))
                .ForMember(destinationMember: i => i.CityName, memberOptions: opt => opt.MapFrom(i => i.Advert.Address.City.Name))
                .ForMember(destinationMember: i => i.DistrictName, memberOptions: opt => opt.MapFrom(i => i.Advert.Address.District.Name))
                .ForMember(destinationMember: i => i.NeighbourhoodName, memberOptions: opt => opt.MapFrom(i => i.Advert.Address.Neighbourhood.Name))
                .ForMember(destinationMember: i => i.AdvertId, memberOptions: opt => opt.MapFrom(i => i.Advert.Id))
                .ForMember(destinationMember: i => i.ProductId, memberOptions: opt => opt.MapFrom(i => i.Advert.Product.Id))
                .ForMember(destinationMember: i => i.ProductName, memberOptions: opt => opt.MapFrom(i => i.Advert.Product.Name))
                .ForMember(destinationMember: i => i.CategoryName, memberOptions: opt => opt.MapFrom(i => i.Advert.Product.Category.Name))
                .ForMember(destinationMember: i => i.BrandName, memberOptions: opt => opt.MapFrom(i => i.Advert.Product.Brand.Name))
                .ForMember(destinationMember: i => i.Title, memberOptions: opt => opt.MapFrom(i => i.Advert.Title))
                .ForMember(destinationMember: i => i.Description, memberOptions: opt => opt.MapFrom(i => i.Advert.Description))
                .ForMember(destinationMember: i => i.IndividualUserId, memberOptions: opt => opt.MapFrom(i => i.IndividualUser.Id))
                .ForMember(destinationMember: i => i.IndividualUserId, memberOptions: opt => opt.MapFrom(i => i.IndividualUser.Id))
                .ForMember(destinationMember: i => i.IndividualUserUserId, memberOptions: opt => opt.MapFrom(i => i.IndividualUser.UserId))
                .ForMember(destinationMember: i => i.IndividualUserFirstName, memberOptions: opt => opt.MapFrom(i => i.IndividualUser.FirstName))
                .ForMember(destinationMember: i => i.IndividualUserLastName, memberOptions: opt => opt.MapFrom(i => i.IndividualUser.LastName))
                .ForMember(destinationMember: i => i.IndividualUserUserName, memberOptions: opt => opt.MapFrom(i => i.IndividualUser.UserName)).ReverseMap();

        CreateMap<SwapAdvert, GetByIdSwapAdvertResponse>()
                .ForMember(destinationMember: i => i.SwapAdvertId, memberOptions: opt => opt.MapFrom(i => i.Id))
                .ForMember(destinationMember: i => i.AdvertId, memberOptions: opt => opt.MapFrom(i => i.AdvertId))
                .ForMember(destinationMember: i => i.AddressId, memberOptions: opt => opt.MapFrom(i => i.Advert.Address.Id))
                .ForMember(destinationMember: i => i.CountryName, memberOptions: opt => opt.MapFrom(i => i.Advert.Address.Country.Name))
                .ForMember(destinationMember: i => i.CityName, memberOptions: opt => opt.MapFrom(i => i.Advert.Address.City.Name))
                .ForMember(destinationMember: i => i.DistrictName, memberOptions: opt => opt.MapFrom(i => i.Advert.Address.District.Name))
                .ForMember(destinationMember: i => i.NeighbourhoodName, memberOptions: opt => opt.MapFrom(i => i.Advert.Address.Neighbourhood.Name))
                .ForMember(destinationMember: i => i.AdvertId, memberOptions: opt => opt.MapFrom(i => i.Advert.Id))
                .ForMember(destinationMember: i => i.ProductId, memberOptions: opt => opt.MapFrom(i => i.Advert.Product.Id))
                .ForMember(destinationMember: i => i.ProductName, memberOptions: opt => opt.MapFrom(i => i.Advert.Product.Name))
                .ForMember(destinationMember: i => i.CategoryName, memberOptions: opt => opt.MapFrom(i => i.Advert.Product.Category.Name))
                .ForMember(destinationMember: i => i.BrandName, memberOptions: opt => opt.MapFrom(i => i.Advert.Product.Brand.Name))
                .ForMember(destinationMember: i => i.Title, memberOptions: opt => opt.MapFrom(i => i.Advert.Title))
                .ForMember(destinationMember: i => i.Description, memberOptions: opt => opt.MapFrom(i => i.Advert.Description))
                .ForMember(destinationMember: i => i.IndividualUserId, memberOptions: opt => opt.MapFrom(i => i.IndividualUser.Id))
                .ForMember(destinationMember: i => i.IndividualUserId, memberOptions: opt => opt.MapFrom(i => i.IndividualUser.Id))
                .ForMember(destinationMember: i => i.IndividualUserUserId, memberOptions: opt => opt.MapFrom(i => i.IndividualUser.UserId))
                .ForMember(destinationMember: i => i.IndividualUserFirstName, memberOptions: opt => opt.MapFrom(i => i.IndividualUser.FirstName))
                .ForMember(destinationMember: i => i.IndividualUserLastName, memberOptions: opt => opt.MapFrom(i => i.IndividualUser.LastName))
                .ForMember(destinationMember: i => i.IndividualUserUserName, memberOptions: opt => opt.MapFrom(i => i.IndividualUser.UserName)).ReverseMap();
    }
}
