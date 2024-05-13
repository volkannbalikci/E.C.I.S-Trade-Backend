using AutoMapper;
using ETradeBackend.Application.Features.UserAddresses.Commands.Create;
using ETradeBackend.Application.Features.UserAddresses.Commands.Delete;
using ETradeBackend.Application.Features.UserAddresses.Commands.Update;
using ETradeBackend.Application.Features.UserAddresses.Queries.GetById;
using ETradeBackend.Application.Features.UserAddresses.Queries.GetList;
using ETradeBackend.Domain.Entities;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.UserAddresses.Profiles;

public class UserAddressMappingProfiles : Profile
{
    public UserAddressMappingProfiles()
    {
        CreateMap<UserAddress, CreateUserAddressCommand>().ReverseMap();
        CreateMap<Address, CreateUserAddressCommand>().ReverseMap();
        CreateMap<UserAddress, CreatedUserAddressResponse>().ReverseMap();
        CreateMap<UserAddress, DeleteUserAddressCommand>().ReverseMap();
        CreateMap<UserAddress, DeletedUserAddressResponse>().ReverseMap();
        CreateMap<DeleteUserAddressCommand, DeletedUserAddressResponse>().ReverseMap();
        CreateMap<UserAddress, UpdateUserAddressCommand>().ReverseMap();
        CreateMap<UserAddress, UpdatedUserAddressResponse>().ReverseMap();

        CreateMap<Paginate<UserAddress>, GetListResponse<GetListUserAddressListItemDto>>().ReverseMap();
        CreateMap<UserAddress, GetListUserAddressListItemDto>()
            .ForMember(destinationMember: u => u.UserId, memberOptions: opt => opt.MapFrom(u => u.UserId))
            .ForMember(destinationMember: u => u.CountryId, memberOptions: opt => opt.MapFrom(u => u.Address.CountryId))
            .ForMember(destinationMember: u => u.CityId, memberOptions: opt => opt.MapFrom(u => u.Address.CityId))
            .ForMember(destinationMember: u => u.DistrictId, memberOptions: opt => opt.MapFrom(u => u.Address.DistrictId))
            .ForMember(destinationMember: u => u.NeighbourhoodId, memberOptions: opt => opt.MapFrom(u => u.Address.NeighbourhoodId))
            .ForMember(destinationMember: u => u.CountryName, memberOptions: opt => opt.MapFrom(u => u.Address.Country.Name))
            .ForMember(destinationMember: u => u.CityName, memberOptions: opt => opt.MapFrom(u => u.Address.City.Name))
            .ForMember(destinationMember: u => u.DistrictName, memberOptions: opt => opt.MapFrom(u => u.Address.District.Name))
            .ForMember(destinationMember: u => u.NeighbourhoodName, memberOptions: opt => opt.MapFrom(u => u.Address.Neighbourhood.Name))
            .ForMember(destinationMember: u => u.AddressPostalCode, memberOptions: opt => opt.MapFrom(u => u.Address.PostalCode))
            .ForMember(destinationMember: u => u.AddressDetails, memberOptions: opt => opt.MapFrom(u => u.Address.AddressDetails))
            .ForMember(destinationMember: u => u.UserAddressIsMain, memberOptions: opt => opt.MapFrom(u => u.IsMain)).ReverseMap();

        CreateMap<UserAddress, GetByIdUserAddressResponse>()
            .ForMember(destinationMember: u => u.UserAddressId, memberOptions: opt => opt.MapFrom(u => u.Id))
            .ForMember(destinationMember: u => u.UserId, memberOptions: opt => opt.MapFrom(u => u.UserId))
            .ForMember(destinationMember: u => u.CountryId, memberOptions: opt => opt.MapFrom(u => u.Address.CountryId))
            .ForMember(destinationMember: u => u.CityId, memberOptions: opt => opt.MapFrom(u => u.Address.CityId))
            .ForMember(destinationMember: u => u.DistrictId, memberOptions: opt => opt.MapFrom(u => u.Address.DistrictId))
            .ForMember(destinationMember: u => u.AddressPostalCode, memberOptions: opt => opt.MapFrom(u => u.Address.PostalCode))
            .ForMember(destinationMember: u => u.AddressDetails, memberOptions: opt => opt.MapFrom(u => u.Address.AddressDetails))
            .ForMember(destinationMember: u => u.UserAddressIsMain, memberOptions: opt => opt.MapFrom(u => u.IsMain)).ReverseMap();
    }
}
