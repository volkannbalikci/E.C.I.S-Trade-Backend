using AutoMapper;
using ETradeBackend.Application.Features.Addresses.Commands.Create;
using ETradeBackend.Application.Features.Addresses.Commands.Delete;
using ETradeBackend.Application.Features.Addresses.Commands.Update;
using ETradeBackend.Application.Features.Addresses.Queries.GetById;
using ETradeBackend.Application.Features.Addresses.Queries.GetList;
using ETradeBackend.Domain.Entities;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Addresses.Profiles;

public class AddressMappingProfiles : Profile
{
    public AddressMappingProfiles()
    {
        CreateMap<Address, CreateAddressCommand>().ReverseMap();
        CreateMap<Address, CreatedAddressResponse>().ReverseMap();
        CreateMap<Address, UpdateAddressCommand>().ReverseMap();
        CreateMap<Address, UpdatedAddressResponse>().ReverseMap();
        CreateMap<Address, DeleteAddressCommand>().ReverseMap();
        CreateMap<Address, DeletedAddressResponse>().ReverseMap();

        CreateMap<Paginate<Address>, GetListResponse<GetListAddressListItemDto>>().ReverseMap();
        CreateMap<Address, GetListAddressListItemDto>()
            .ForMember(destinationMember: a => a.AddressId, memberOptions: opt => opt.MapFrom(a => a.Id))
            .ForMember(destinationMember: a => a.CountryId, memberOptions: opt => opt.MapFrom(a => a.Country.Id))
            .ForMember(destinationMember: a => a.CityId, memberOptions: opt => opt.MapFrom(a => a.City.Id))
            .ForMember(destinationMember: a => a.DistrictId, memberOptions: opt => opt.MapFrom(a => a.District.Id))
            .ForMember(destinationMember: a => a.NeighbourhoodId, memberOptions: opt => opt.MapFrom(a => a.Neighbourhood.Id))
            .ForMember(destinationMember: a => a.CountryName, memberOptions: opt => opt.MapFrom(a => a.Country.Name))
            .ForMember(destinationMember: a => a.CityName, memberOptions: opt => opt.MapFrom(a => a.City.Name))
            .ForMember(destinationMember: a => a.DistrictName, memberOptions: opt => opt.MapFrom(a => a.District.Name))
            .ForMember(destinationMember: a => a.NeighbourhoodName, memberOptions: opt => opt.MapFrom(a => a.Neighbourhood.Name))
            .ForMember(destinationMember: a => a.PostalCode, memberOptions: opt => opt.MapFrom(a => a.PostalCode))
            .ForMember(destinationMember: a => a.AddressDetails, memberOptions: opt => opt.MapFrom(a => a.AddressDetails)).ReverseMap();

        CreateMap<Address, GetByIdAddressResponse>()
            .ForMember(destinationMember: a => a.CountryName, memberOptions: opt => opt.MapFrom(a => a.Country.Name))
            .ForMember(destinationMember: a => a.CityName, memberOptions: opt => opt.MapFrom(a => a.City.Name))
            .ForMember(destinationMember: a => a.DistrictName, memberOptions: opt => opt.MapFrom(a => a.District.Name))
            .ForMember(destinationMember: a => a.NeighbourhoodName, memberOptions: opt => opt.MapFrom(a => a.Neighbourhood.Name)).ReverseMap();
    }
}
