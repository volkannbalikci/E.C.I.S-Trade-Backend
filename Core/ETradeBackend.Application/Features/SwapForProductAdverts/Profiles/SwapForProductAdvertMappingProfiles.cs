using AutoMapper;
using ETradeBackend.Application.Features.SwapAdverts.Commands.Update;
using ETradeBackend.Application.Features.SwapForProductAdverts.Commands.Create;
using ETradeBackend.Application.Features.SwapForProductAdverts.Commands.Delete;
using ETradeBackend.Application.Features.SwapForProductAdverts.Commands.Update;
using ETradeBackend.Application.Features.SwapForProductAdverts.Queries.GetById;
using ETradeBackend.Application.Features.SwapForProductAdverts.Queries.GetList;
using ETradeBackend.Domain.Entities;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.SwapForProductAdverts.Profiles;

public class SwapForProductAdvertMappingProfiles : Profile
{
    public SwapForProductAdvertMappingProfiles()
    {
        CreateMap<Advert, CreateSwapForProductAdvertCommand>().ReverseMap();
        CreateMap<SwapAdvert, CreateSwapForProductAdvertCommand>().ReverseMap();
        CreateMap<SwapForProductAdvert, CreateSwapForProductAdvertCommand>().ReverseMap();
        CreateMap<SwapForProductAdvert, CreatedSwapForProductAdvertResponse>()
            .ForMember(destinationMember: s => s.SwapForProductAdvertId, memberOptions: opt => opt.MapFrom(s => s.Id)).ReverseMap();

        CreateMap<SwapForProductAdvert, DeletedSwapForProductAdvertResponse>().ReverseMap();

        CreateMap<SwapForProductAdvert, UpdateSwapForProductAdvertCommand>().ReverseMap();
        CreateMap<SwapAdvert, UpdateSwapForProductAdvertCommand>().ReverseMap();
        CreateMap<Advert, UpdateSwapForProductAdvertCommand>().ReverseMap();
        CreateMap<SwapForProductAdvert, UpdatedSwapForProductAdvertResponse>()
            .ForMember(destinationMember: s => s.SwapForProductAdvertId, memberOptions: opt => opt.MapFrom(s => s.Id))
            .ForMember(destinationMember: s => s.SwapAdvertId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvertId))
            .ForMember(destinationMember: s => s.AdvertId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.AdvertId))
            .ForMember(destinationMember: s => s.AddressId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.AddressId))
            .ForMember(destinationMember: s => s.CountryName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Address.Country.Name))
            .ForMember(destinationMember: s => s.CityName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Address.City.Name))
            .ForMember(destinationMember: s => s.DistrictName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Address.District.Name))
            .ForMember(destinationMember: s => s.NeighbourhoodName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Address.Neighbourhood.Name))
            .ForMember(destinationMember: s => s.AdvertProductId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.ProductId))
            .ForMember(destinationMember: s => s.AdvertProductName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Product.Name))
            .ForMember(destinationMember: s => s.AdvertsProductBrandId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Product.BrandId))
            .ForMember(destinationMember: s => s.AdvertsProductBrandName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Product.Brand.Name))
            .ForMember(destinationMember: s => s.AdvertsProductCategoryId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Product.CategoryId))
            .ForMember(destinationMember: s => s.AdvertsProductCategoryName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Product.Category.Name))
            .ForMember(destinationMember: s => s.Title, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Title))
            .ForMember(destinationMember: s => s.Description, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Description))
            .ForMember(destinationMember: s => s.IndividualUserId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.IndividualUserId))
            .ForMember(destinationMember: s => s.IndividualUserUserId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.IndividualUser.UserId))
            .ForMember(destinationMember: s => s.IndividualUserFirstName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.IndividualUser.FirstName))
            .ForMember(destinationMember: s => s.IndividualUserLastName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.IndividualUser.LastName))
            .ForMember(destinationMember: s => s.IndividualUserUserName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.IndividualUser.UserName))
            .ForMember(destinationMember: s => s.DesiredProductId, memberOptions: opt => opt.MapFrom(s => s.DesiredProductId))
            .ForMember(destinationMember: s => s.DesiredProductName, memberOptions: opt => opt.MapFrom(s => s.DesiredProduct.Name))
            .ForMember(destinationMember: s => s.DesiredProductBrandId, memberOptions: opt => opt.MapFrom(s => s.DesiredProduct.BrandId))
            .ForMember(destinationMember: s => s.DesiredProductBrandName, memberOptions: opt => opt.MapFrom(s => s.DesiredProduct.Brand.Name))
            .ForMember(destinationMember: s => s.DesiredProductCategoryId, memberOptions: opt => opt.MapFrom(s => s.DesiredProduct.CategoryId))
            .ForMember(destinationMember: s => s.DesiredProductCategoryName, memberOptions: opt => opt.MapFrom(s => s.DesiredProduct.Category.Name)).ReverseMap();

        CreateMap<Paginate<SwapForProductAdvert>, GetListResponse<GetListSwapForProductAdvertListItemDto>>().ReverseMap();
        CreateMap<SwapForProductAdvert, GetListSwapForProductAdvertListItemDto>()
                        .ForMember(destinationMember: s => s.SwapForProductAdvertId, memberOptions: opt => opt.MapFrom(s => s.Id))
            .ForMember(destinationMember: s => s.SwapAdvertId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvertId))
            .ForMember(destinationMember: s => s.AdvertId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.AdvertId))
            .ForMember(destinationMember: s => s.AddressId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.AddressId))
            .ForMember(destinationMember: s => s.CountryName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Address.Country.Name))
            .ForMember(destinationMember: s => s.CityName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Address.City.Name))
            .ForMember(destinationMember: s => s.DistrictName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Address.District.Name))
            .ForMember(destinationMember: s => s.NeighbourhoodName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Address.Neighbourhood.Name))
            .ForMember(destinationMember: s => s.AdvertProductId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.ProductId))
            .ForMember(destinationMember: s => s.AdvertProductName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Product.Name))
            .ForMember(destinationMember: s => s.AdvertsProductBrandId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Product.BrandId))
            .ForMember(destinationMember: s => s.AdvertsProductBrandName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Product.Brand.Name))
            .ForMember(destinationMember: s => s.AdvertsProductCategoryId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Product.CategoryId))
            .ForMember(destinationMember: s => s.AdvertsProductCategoryName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Product.Category.Name))
            .ForMember(destinationMember: s => s.Title, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Title))
            .ForMember(destinationMember: s => s.Description, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Description))
            .ForMember(destinationMember: s => s.IndividualUserId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.IndividualUserId))
            .ForMember(destinationMember: s => s.IndividualUserUserId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.IndividualUser.UserId))
            .ForMember(destinationMember: s => s.IndividualUserFirstName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.IndividualUser.FirstName))
            .ForMember(destinationMember: s => s.IndividualUserLastName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.IndividualUser.LastName))
            .ForMember(destinationMember: s => s.IndividualUserUserName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.IndividualUser.UserName))
            .ForMember(destinationMember: s => s.DesiredProductId, memberOptions: opt => opt.MapFrom(s => s.DesiredProductId))
            .ForMember(destinationMember: s => s.DesiredProductName, memberOptions: opt => opt.MapFrom(s => s.DesiredProduct.Name))
            .ForMember(destinationMember: s => s.DesiredProductBrandId, memberOptions: opt => opt.MapFrom(s => s.DesiredProduct.BrandId))
            .ForMember(destinationMember: s => s.DesiredProductBrandName, memberOptions: opt => opt.MapFrom(s => s.DesiredProduct.Brand.Name))
            .ForMember(destinationMember: s => s.DesiredProductCategoryId, memberOptions: opt => opt.MapFrom(s => s.DesiredProduct.CategoryId))
            .ForMember(destinationMember: s => s.DesiredProductCategoryName, memberOptions: opt => opt.MapFrom(s => s.DesiredProduct.Category.Name)).ReverseMap();

        CreateMap<SwapForProductAdvert, GetByIdSwapForProductAdvertResponse>()
            .ForMember(destinationMember: s => s.SwapForProductAdvertId, memberOptions: opt => opt.MapFrom(s => s.Id))
            .ForMember(destinationMember: s => s.SwapAdvertId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvertId))
            .ForMember(destinationMember: s => s.AdvertId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.AdvertId))
            .ForMember(destinationMember: s => s.AddressId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.AddressId))
            .ForMember(destinationMember: s => s.CountryName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Address.Country.Name))
            .ForMember(destinationMember: s => s.CityName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Address.City.Name))
            .ForMember(destinationMember: s => s.DistrictName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Address.District.Name))
            .ForMember(destinationMember: s => s.NeighbourhoodName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Address.Neighbourhood.Name))
            .ForMember(destinationMember: s => s.AdvertProductId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.ProductId))
            .ForMember(destinationMember: s => s.AdvertProductName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Product.Name))
            .ForMember(destinationMember: s => s.AdvertsProductBrandId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Product.BrandId))
            .ForMember(destinationMember: s => s.AdvertsProductBrandName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Product.Brand.Name))
            .ForMember(destinationMember: s => s.AdvertsProductCategoryId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Product.CategoryId))
            .ForMember(destinationMember: s => s.AdvertsProductCategoryName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Product.Category.Name))
            .ForMember(destinationMember: s => s.Title, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Title))
            .ForMember(destinationMember: s => s.Description, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Description))
            .ForMember(destinationMember: s => s.IndividualUserId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.IndividualUserId))
            .ForMember(destinationMember: s => s.IndividualUserUserId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.IndividualUser.UserId))
            .ForMember(destinationMember: s => s.IndividualUserFirstName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.IndividualUser.FirstName))
            .ForMember(destinationMember: s => s.IndividualUserLastName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.IndividualUser.LastName))
            .ForMember(destinationMember: s => s.IndividualUserUserName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.IndividualUser.UserName))
            .ForMember(destinationMember: s => s.DesiredProductId, memberOptions: opt => opt.MapFrom(s => s.DesiredProductId))
            .ForMember(destinationMember: s => s.DesiredProductName, memberOptions: opt => opt.MapFrom(s => s.DesiredProduct.Name))
            .ForMember(destinationMember: s => s.DesiredProductBrandId, memberOptions: opt => opt.MapFrom(s => s.DesiredProduct.BrandId))
            .ForMember(destinationMember: s => s.DesiredProductBrandName, memberOptions: opt => opt.MapFrom(s => s.DesiredProduct.Brand.Name))
            .ForMember(destinationMember: s => s.DesiredProductCategoryId, memberOptions: opt => opt.MapFrom(s => s.DesiredProduct.CategoryId))
            .ForMember(destinationMember: s => s.DesiredProductCategoryName, memberOptions: opt => opt.MapFrom(s => s.DesiredProduct.Category.Name)).ReverseMap();

    }
}
