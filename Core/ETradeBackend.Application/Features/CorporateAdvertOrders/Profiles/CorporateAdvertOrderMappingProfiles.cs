using AutoMapper;
using ETradeBackend.Application.Features.CorporateAdvertOrderItems.Commands.Create;
using ETradeBackend.Application.Features.CorporateAdvertOrders.Commands.Create;
using ETradeBackend.Application.Features.CorporateAdvertOrders.Commands.Delete;
using ETradeBackend.Application.Features.CorporateAdvertOrders.Queries.GetById;
using ETradeBackend.Application.Features.CorporateAdvertOrders.Queries.GetList;
using ETradeBackend.Domain.Entities;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateAdvertOrders.Profiles;

public class CorporateAdvertOrderMappingProfiles : Profile
{
    public CorporateAdvertOrderMappingProfiles()
    {
        CreateMap<CorporateAdvertOrder, CreateCorporateAdvertOrderCommand>().ReverseMap();
        CreateMap<CreateCorporateAdvertOrderItemCommand, CreatedCorporateAdvertOrderItemResponse
>().ReverseMap();
        CreateMap<CorporateAdvertOrder, CreatedCorporateAdvertOrderResponse>()
            .ForMember(destinationMember: c => c.CorporateAdvertOrderId, memberOptions: opt => opt.MapFrom(c => c.Id)).ReverseMap();

        CreateMap<CorporateAdvertOrder, DeletedCorporateAdvertOrderResponse>().ReverseMap();

        CreateMap<Paginate<CorporateAdvertOrder>, GetListResponse<GetListCorporateAdvertOrderListItemDto>>().ReverseMap();
        CreateMap<CorporateAdvertOrder, GetListCorporateAdvertOrderListItemDto>()
    .ForMember(destinationMember: c => c.CorporateAdvertOrderId, memberOptions: opt => opt.MapFrom(c => c.Id))
    .ForMember(destinationMember: c => c.IndividualUserId, memberOptions: opt => opt.MapFrom(c => c.IndividualUserId))
    .ForMember(destinationMember: c => c.IndividualUserUserId, memberOptions: opt => opt.MapFrom(c => c.IndividualUser.UserId))
    .ForMember(destinationMember: c => c.IndividualUserFirstName, memberOptions: opt => opt.MapFrom(c => c.IndividualUser.FirstName))
    .ForMember(destinationMember: c => c.IndividualUserLastName, memberOptions: opt => opt.MapFrom(c => c.IndividualUser.LastName))
    .ForMember(destinationMember: c => c.IndividualUserUserName, memberOptions: opt => opt.MapFrom(c => c.IndividualUser.UserName))
    .ForMember(destinationMember: c => c.UserAddressId, memberOptions: opt => opt.MapFrom(c => c.UserAddressId))
    .ForMember(destinationMember: c => c.UserAddressUserId, memberOptions: opt => opt.MapFrom(c => c.UserAddress.UserId))
    .ForMember(destinationMember: c => c.UserAddressAddressId, memberOptions: opt => opt.MapFrom(c => c.UserAddress.AddressId))
    .ForMember(destinationMember: c => c.UserAddressAddressCountryId, memberOptions: opt => opt.MapFrom(c => c.UserAddress.Address.CountryId))
    .ForMember(destinationMember: c => c.UserAddressAddressCountryName, memberOptions: opt => opt.MapFrom(c => c.UserAddress.Address.Country.Name))
    .ForMember(destinationMember: c => c.UserAddressAddressCityId, memberOptions: opt => opt.MapFrom(c => c.UserAddress.Address.CityId))
    .ForMember(destinationMember: c => c.UserAddressAddressCityName, memberOptions: opt => opt.MapFrom(c => c.UserAddress.Address.City.Name))
    .ForMember(destinationMember: c => c.UserAddressAddressDistrictId, memberOptions: opt => opt.MapFrom(c => c.UserAddress.Address.DistrictId))
    .ForMember(destinationMember: c => c.UserAddressAddressDistrictName, memberOptions: opt => opt.MapFrom(c => c.UserAddress.Address.District.Name))
    .ForMember(destinationMember: c => c.UserAddressAddressNeighbourhoodId, memberOptions: opt => opt.MapFrom(c => c.UserAddress.Address.NeighbourhoodId))
    .ForMember(destinationMember: c => c.UserAddressAddressNeighbourhoodName, memberOptions: opt => opt.MapFrom(c => c.UserAddress.Address.Neighbourhood.Name))
    .ForMember(destinationMember: c => c.UserAddressAddressPostalCode, memberOptions: opt => opt.MapFrom(c => c.UserAddress.Address.PostalCode))
    .ForMember(destinationMember: c => c.UserAddressAddressAddressDetails, memberOptions: opt => opt.MapFrom(c => c.UserAddress.Address.AddressDetails))
    .ForMember(destinationMember: c => c.UserAddressIsMain, memberOptions: opt => opt.MapFrom(c => c.UserAddress.IsMain))
    .ForMember(destinationMember: c => c.Description, memberOptions: opt => opt.MapFrom(c => c.Description))
    .ForMember(destinationMember: c => c.Code, memberOptions: opt => opt.MapFrom(c => c.Code))
    .ForMember(destinationMember: c => c.TotalPrice, memberOptions: opt => opt.MapFrom(c => c.TotalPrice)).ReverseMap();

        CreateMap<CorporateAdvertOrder, GetByIdCorporateAdvertOrderResponse>()
                .ForMember(destinationMember: c => c.CorporateAdvertOrderId, memberOptions: opt => opt.MapFrom(c => c.Id))
    .ForMember(destinationMember: c => c.IndividualUserId, memberOptions: opt => opt.MapFrom(c => c.IndividualUserId))
    .ForMember(destinationMember: c => c.IndividualUserUserId, memberOptions: opt => opt.MapFrom(c => c.IndividualUser.UserId))
    .ForMember(destinationMember: c => c.IndividualUserFirstName, memberOptions: opt => opt.MapFrom(c => c.IndividualUser.FirstName))
    .ForMember(destinationMember: c => c.IndividualUserLastName, memberOptions: opt => opt.MapFrom(c => c.IndividualUser.LastName))
    .ForMember(destinationMember: c => c.IndividualUserUserName, memberOptions: opt => opt.MapFrom(c => c.IndividualUser.UserName))
    .ForMember(destinationMember: c => c.UserAddressId, memberOptions: opt => opt.MapFrom(c => c.UserAddressId))
    .ForMember(destinationMember: c => c.UserAddressUserId, memberOptions: opt => opt.MapFrom(c => c.UserAddress.UserId))
    .ForMember(destinationMember: c => c.UserAddressAddressId, memberOptions: opt => opt.MapFrom(c => c.UserAddress.AddressId))
    .ForMember(destinationMember: c => c.UserAddressAddressCountryId, memberOptions: opt => opt.MapFrom(c => c.UserAddress.Address.CountryId))
    .ForMember(destinationMember: c => c.UserAddressAddressCountryName, memberOptions: opt => opt.MapFrom(c => c.UserAddress.Address.Country.Name))
    .ForMember(destinationMember: c => c.UserAddressAddressCityId, memberOptions: opt => opt.MapFrom(c => c.UserAddress.Address.CityId))
    .ForMember(destinationMember: c => c.UserAddressAddressCityName, memberOptions: opt => opt.MapFrom(c => c.UserAddress.Address.City.Name))
    .ForMember(destinationMember: c => c.UserAddressAddressDistrictId, memberOptions: opt => opt.MapFrom(c => c.UserAddress.Address.DistrictId))
    .ForMember(destinationMember: c => c.UserAddressAddressDistrictName, memberOptions: opt => opt.MapFrom(c => c.UserAddress.Address.District.Name))
    .ForMember(destinationMember: c => c.UserAddressAddressNeighbourhoodId, memberOptions: opt => opt.MapFrom(c => c.UserAddress.Address.NeighbourhoodId))
    .ForMember(destinationMember: c => c.UserAddressAddressNeighbourhoodName, memberOptions: opt => opt.MapFrom(c => c.UserAddress.Address.Neighbourhood.Name))
    .ForMember(destinationMember: c => c.UserAddressAddressPostalCode, memberOptions: opt => opt.MapFrom(c => c.UserAddress.Address.PostalCode))
    .ForMember(destinationMember: c => c.UserAddressAddressAddressDetails, memberOptions: opt => opt.MapFrom(c => c.UserAddress.Address.AddressDetails))
    .ForMember(destinationMember: c => c.UserAddressIsMain, memberOptions: opt => opt.MapFrom(c => c.UserAddress.IsMain))
    .ForMember(destinationMember: c => c.Description, memberOptions: opt => opt.MapFrom(c => c.Description))
    .ForMember(destinationMember: c => c.Code, memberOptions: opt => opt.MapFrom(c => c.Code))
    .ForMember(destinationMember: c => c.TotalPrice, memberOptions: opt => opt.MapFrom(c => c.TotalPrice)).ReverseMap();
    }
}
