using AutoMapper;
using ETradeBackend.Application.Features.IndividualAdverts.Commands.Create;
using ETradeBackend.Application.Features.SwapAdverts.Commands.Create;
using ETradeBackend.Application.Features.SwapAdverts.Commands.Delete;
using ETradeBackend.Application.Features.SwapForCategoryAdverts.Commands.Create;
using ETradeBackend.Application.Features.SwapForCategoryAdverts.Commands.Delete;
using ETradeBackend.Application.Features.SwapForCategoryAdverts.Commands.Update;
using ETradeBackend.Application.Features.SwapForCategoryAdverts.Queries.GetById;
using ETradeBackend.Application.Features.SwapForCategoryAdverts.Queries.GetList;
using ETradeBackend.Domain.Entities;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.SwapForCategoryAdverts.Profiles;

public class SwapForCategoryAdvertMappingProfiles : Profile
{
    public SwapForCategoryAdvertMappingProfiles()
    {
        CreateMap<SwapForCategoryAdvert, CreateSwapForCategoryAdvertCommand>().ReverseMap();
        CreateMap<SwapAdvert, CreateSwapForCategoryAdvertCommand>().ReverseMap();
        CreateMap<Advert, CreateSwapForCategoryAdvertCommand>().ReverseMap();
        CreateMap<SwapForCategoryAdvert, CreatedSwapForCategoryAdvertResponse>()
             .ForMember(destinationMember: s => s.SwapForCategoryAdvertId, memberOptions: opt => opt.MapFrom(s => s.Id)).ReverseMap();

        CreateMap<SwapForCategoryAdvert, DeletedSwapForCategoryAdvertResponse>().ReverseMap();

        CreateMap<GetListResponse<GetListSwapForCategoryAdvertListItemDto>, Paginate<SwapForCategoryAdvert>>().ReverseMap();
        CreateMap<SwapForCategoryAdvert, GetListSwapForCategoryAdvertListItemDto>()
            .ForMember(destinationMember: s => s.SwapForCategoryAdvertId, memberOptions: opt => opt.MapFrom(s => s.Id))
            .ForMember(destinationMember: s => s.SwapAdvertId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvertId))
            .ForMember(destinationMember: s => s.AdvertId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.AdvertId))
            .ForMember(destinationMember: s => s.AddressId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.AddressId))
            .ForMember(destinationMember: s => s.CountryName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Address.Country.Name))
            .ForMember(destinationMember: s => s.CityName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Address.City.Name))
            .ForMember(destinationMember: s => s.DistrictName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Address.District.Name))
            .ForMember(destinationMember: s => s.NeighbourhoodName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Address.Neighbourhood.Name))
            .ForMember(destinationMember: s => s.PostalCode, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Address.PostalCode))
            .ForMember(destinationMember: s => s.AddressDetails, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Address.AddressDetails))
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
           .ForMember(destinationMember: s => s.DesiredCategoryId, memberOptions: opt => opt.MapFrom(s => s.DesiredCategory.Id))
            .ForMember(destinationMember: s => s.DesiredCategoryName, memberOptions: opt => opt.MapFrom(s => s.DesiredCategory.Name))
            .ForMember(destinationMember: s => s.DesiredCategoryDescription, memberOptions: opt => opt.MapFrom(s => s.DesiredCategory.Description)).ReverseMap();

        CreateMap<SwapForCategoryAdvert, GetByIdSwapForCategoryAdvertResponse>()
            .ForMember(destinationMember: s => s.SwapForCategoryAdvertId, memberOptions: opt => opt.MapFrom(s => s.Id))
            .ForMember(destinationMember: s => s.SwapAdvertId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvertId))
            .ForMember(destinationMember: s => s.AdvertId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.AdvertId))
            .ForMember(destinationMember: s => s.AddressId, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.AddressId))
            .ForMember(destinationMember: s => s.CountryName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Address.Country.Name))
            .ForMember(destinationMember: s => s.CityName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Address.City.Name))
            .ForMember(destinationMember: s => s.DistrictName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Address.District.Name))
            .ForMember(destinationMember: s => s.NeighbourhoodName, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Address.Neighbourhood.Name))
            .ForMember(destinationMember: s => s.PostalCode, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Address.PostalCode))
            .ForMember(destinationMember: s => s.AddressDetails, memberOptions: opt => opt.MapFrom(s => s.SwapAdvert.Advert.Address.AddressDetails))
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
           .ForMember(destinationMember: s => s.DesiredCategoryId, memberOptions: opt => opt.MapFrom(s => s.DesiredCategory.Id))
            .ForMember(destinationMember: s => s.DesiredCategoryName, memberOptions: opt => opt.MapFrom(s => s.DesiredCategory.Name))
            .ForMember(destinationMember: s => s.DesiredCategoryDescription, memberOptions: opt => opt.MapFrom(s => s.DesiredCategory.Description)).ReverseMap();
    }
}
