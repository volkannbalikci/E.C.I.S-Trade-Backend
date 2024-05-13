using AutoMapper;
using ETradeBackend.Application.Features.CorporateAdverts.Commands.Create;
using ETradeBackend.Application.Features.CorporateAdverts.Commands.Delete;
using ETradeBackend.Application.Features.CorporateAdverts.Queries.GetByI;
using ETradeBackend.Application.Features.CorporateAdverts.Queries.GetById;
using ETradeBackend.Application.Features.CorporateAdverts.Queries.GetList;
using ETradeBackend.Application.Features.IndividualAdverts.Commands.Create;
using ETradeBackend.Application.Features.IndividualAdverts.Commands.Delete;
using ETradeBackend.Application.Features.IndividualAdverts.Commands.Update;
using ETradeBackend.Application.Features.IndividualAdverts.Queries.GetList;
using ETradeBackend.Domain.Entities;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateAdverts.Profiles;

public class CorporateAdvertProfiles : Profile
{
    public CorporateAdvertProfiles()
    {
        CreateMap<CorporateAdvert, CreateCorporateAdvertCommand>().ReverseMap();
        CreateMap<CreateCorporateAdvertCommand, CreatedCorporateAdvertResponse>().ReverseMap();
        CreateMap<Advert, CreateCorporateAdvertCommand>().ReverseMap();
        CreateMap<CorporateAdvert, CreatedCorporateAdvertResponse>().ReverseMap();
        CreateMap<Advert, CreatedCorporateAdvertResponse>().ReverseMap();
        CreateMap<CorporateAdvert, DeleteCorporateAdvertCommand>().ReverseMap();
        CreateMap<CorporateAdvert, DeletedCorporateAdvertResponse>().ReverseMap();

        CreateMap<Paginate<CorporateAdvert>, GetListResponse<GetListCorporateAdvertListItemDto>>().ReverseMap();
        CreateMap<CorporateAdvert, GetListCorporateAdvertListItemDto>()
                        .ForMember(destinationMember: i => i.CorporateAdvertId, memberOptions: opt => opt.MapFrom(i => i.Id))
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
            .ForMember(destinationMember: i => i.CorporateUserId, memberOptions: opt => opt.MapFrom(i => i.CorporateUser.Id))
            .ForMember(destinationMember: i => i.CorporateUserUserId, memberOptions: opt => opt.MapFrom(i => i.CorporateUser.UserId))
            .ForMember(destinationMember: i => i.CorporateUserCompanyName, memberOptions: opt => opt.MapFrom(i => i.CorporateUser.CompanyName))
            .ForMember(destinationMember: i => i.CorporateUserTaxIdentityNumber, memberOptions: opt => opt.MapFrom(i => i.CorporateUser.TaxIdentityNumber))
            .ForMember(destinationMember: i => i.UnitPrice, memberOptions: opt => opt.MapFrom(i => i.UnitPrice))
            .ForMember(destinationMember: i => i.StockAmount, memberOptions: opt => opt.MapFrom(i => i.StockAmount)).ReverseMap();
        
        CreateMap<CorporateAdvert, GetByIdCorporateAdvertResponse>()
                                    .ForMember(destinationMember: i => i.CorporateAdvertId, memberOptions: opt => opt.MapFrom(i => i.Id))
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
            .ForMember(destinationMember: i => i.CorporateUserId, memberOptions: opt => opt.MapFrom(i => i.CorporateUser.Id))
            .ForMember(destinationMember: i => i.CorporateUserUserId, memberOptions: opt => opt.MapFrom(i => i.CorporateUser.UserId))
            .ForMember(destinationMember: i => i.CorporateUserCompanyName, memberOptions: opt => opt.MapFrom(i => i.CorporateUser.CompanyName))
            .ForMember(destinationMember: i => i.CorporateUserTaxIdentityNumber, memberOptions: opt => opt.MapFrom(i => i.CorporateUser.TaxIdentityNumber))
            .ForMember(destinationMember: i => i.UnitPrice, memberOptions: opt => opt.MapFrom(i => i.UnitPrice))
            .ForMember(destinationMember: i => i.StockAmount, memberOptions: opt => opt.MapFrom(i => i.StockAmount)).ReverseMap();
    }
}
