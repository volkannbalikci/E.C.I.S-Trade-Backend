using AutoMapper;
using ETradeBackend.Application.Features.Adverts.Commands.Create;
using ETradeBackend.Application.Features.Adverts.Commands.Delete;
using ETradeBackend.Application.Features.Adverts.Commands.Update;
using ETradeBackend.Application.Features.Adverts.Queries.GetList;
using ETradeBackend.Application.Features.IndividualAdverts.Commands.Create;
using ETradeBackend.Application.Features.IndividualAdverts.Commands.Delete;
using ETradeBackend.Application.Features.IndividualAdverts.Commands.Update;
using ETradeBackend.Application.Features.IndividualAdverts.Queries.GetById;
using ETradeBackend.Application.Features.IndividualAdverts.Queries.GetList;
using ETradeBackend.Domain.Entities;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.IndividualAdverts.Profiles;

public class IndividualAdvertMappingProfiles : Profile
{
    public IndividualAdvertMappingProfiles()
    {
        CreateMap<IndividualAdvert, CreateIndividualAdvertCommand>().ReverseMap();
        CreateMap<CreateIndividualAdvertCommand, CreatedIndividualAdvertResponse>().ReverseMap();
        CreateMap<Advert, CreateIndividualAdvertCommand>().ReverseMap();
        CreateMap<IndividualAdvert, CreatedIndividualAdvertResponse>().ReverseMap();
        CreateMap<Advert, CreatedIndividualAdvertResponse>().ReverseMap();
        CreateMap<IndividualAdvert, DeleteIndividualAdvertCommand>().ReverseMap();
        CreateMap<IndividualAdvert, DeletedIndividualAdvertResponse>().ReverseMap();
        CreateMap<IndividualAdvert, UpdateIndividualAdvertCommand>()
            .ForMember(destinationMember: i => i.Bargain, memberOptions: opt => opt.MapFrom(i => i.Bargain))
            .ForMember(destinationMember: i => i.Price, memberOptions: opt => opt.MapFrom(i => i.Price)).ReverseMap();
        CreateMap<Advert, UpdateIndividualAdvertCommand>()
        .ForMember(destinationMember: i => i.Title, memberOptions: opt => opt.MapFrom(i => i.Title))
        .ForMember(destinationMember: i => i.Description, memberOptions: opt => opt.MapFrom(i => i.Description))
        .ForMember(destinationMember: i => i.AddressId, memberOptions: opt => opt.MapFrom(i => i.AddressId)).ReverseMap();


        CreateMap<IndividualAdvert, UpdatedIndividualAdvertResponse>()
              .ForMember(destinationMember: i => i.IndividualAdvertId, memberOptions: opt => opt.MapFrom(i => i.Id))
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
            .ForMember(destinationMember: i => i.IndividualUserUserName, memberOptions: opt => opt.MapFrom(i => i.IndividualUser.UserName))
            .ForMember(destinationMember: i => i.Bargain, memberOptions: opt => opt.MapFrom(i => i.Bargain))
            .ForMember(destinationMember: i => i.Price, memberOptions: opt => opt.MapFrom(i => i.Price)).ReverseMap();

        CreateMap<Paginate<IndividualAdvert>, GetListResponse<GetListIndividualAdvertListItemDto>>().ReverseMap();
        CreateMap<IndividualAdvert, GetListIndividualAdvertListItemDto>()
            .ForMember(destinationMember: i => i.IndividualAdvertId, memberOptions: opt => opt.MapFrom(i => i.Id))
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
            .ForMember(destinationMember: i => i.IndividualUserUserName, memberOptions: opt => opt.MapFrom(i => i.IndividualUser.UserName))
            .ForMember(destinationMember: i => i.Bargain, memberOptions: opt => opt.MapFrom(i => i.Bargain))
            .ForMember(destinationMember: i => i.Price, memberOptions: opt => opt.MapFrom(i => i.Price)).ReverseMap();

        CreateMap<IndividualAdvert, GetByIdIndividualAdvertResponse>()
            .ForMember(destinationMember: i => i.IndividualAdvertId, memberOptions: opt => opt.MapFrom(i => i.Id))
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
            .ForMember(destinationMember: i => i.IndividualUserUserName, memberOptions: opt => opt.MapFrom(i => i.IndividualUser.UserName))
            .ForMember(destinationMember: i => i.Bargain, memberOptions: opt => opt.MapFrom(i => i.Bargain))
            .ForMember(destinationMember: i => i.Price, memberOptions: opt => opt.MapFrom(i => i.Price)).ReverseMap();
    }
}
