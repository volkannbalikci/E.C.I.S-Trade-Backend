using AutoMapper;
using ETradeBackend.Application.Features.IndividualUsers.Commands.Create;
using ETradeBackend.Application.Features.IndividualUsers.Commands.Delete;
using ETradeBackend.Application.Features.IndividualUsers.Commands.Update;
using ETradeBackend.Application.Features.IndividualUsers.Queries.GetById;
using ETradeBackend.Application.Features.IndividualUsers.Queries.GetList;
using ETradeBackend.Application.Features.UserAddresses.Queries.GetList;
using ETradeBackend.Domain.Entities;
using Framework.Application.Responses;
using Framework.Application.Security.Hashing;
using Framework.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.IndividualUsers.Profiles;

public class IndividualUserMappingProfiles : Profile
{
    public IndividualUserMappingProfiles()
    {
        CreateMap<IndividualUser, CreateIndividualUserCommand>().ReverseMap();
        CreateMap<User, CreateIndividualUserCommand>().ReverseMap();
        CreateMap<IndividualUser, CreatedIndividualUserResponse>().ReverseMap();
        CreateMap<User, CreatedIndividualUserResponse>().ReverseMap();

        CreateMap<IndividualUser, DeleteIndividualUserCommand>().ReverseMap();
        CreateMap<IndividualUser, DeletedIndividualUserResponse>().ReverseMap();
        CreateMap<IndividualUser, UpdateIndividualUserCommand>().ReverseMap();
        CreateMap<IndividualUser, UpdatedIndividualUserReponse>().ReverseMap();

        CreateMap<Paginate<IndividualUser>, GetListResponse<GetListIndividualUserListItemDto>>().ReverseMap();
        CreateMap<IndividualUser, GetListIndividualUserListItemDto>()
                        .ForMember(destinationMember: i => i.Email, memberOptions: opt => opt.MapFrom(i => i.User.Email)).ReverseMap();

        CreateMap<UserAddress, GetListUserAddressListItemDto>()
            .ForMember(destinationMember: i => i.CountryId, memberOptions: opt => opt.MapFrom(i => i.Address.CountryId))
            .ForMember(destinationMember: i => i.CityId, memberOptions: opt => opt.MapFrom(i => i.Address.CityId))
            .ForMember(destinationMember: i => i.DistrictId, memberOptions: opt => opt.MapFrom(i => i.Address.DistrictId))
            .ForMember(destinationMember: i => i.NeighbourhoodId, memberOptions: opt => opt.MapFrom(i => i.Address.NeighbourhoodId))
            .ForMember(destinationMember: i => i.CountryName, memberOptions: opt => opt.MapFrom(i => i.Address.Country.Name))
            .ForMember(destinationMember: i => i.CityName, memberOptions: opt => opt.MapFrom(i => i.Address.City.Name))
            .ForMember(destinationMember: i => i.DistrictName, memberOptions: opt => opt.MapFrom(i => i.Address.District.Name))
            .ForMember(destinationMember: i => i.NeighbourhoodName, memberOptions: opt => opt.MapFrom(i => i.Address.Neighbourhood.Name))
            .ForMember(destinationMember: i => i.AddressPostalCode, memberOptions: opt => opt.MapFrom(i => i.Address.PostalCode))
            .ForMember(destinationMember: i => i.AddressDetails, memberOptions: opt => opt.MapFrom(i => i.Address.AddressDetails))
            .ReverseMap();

        CreateMap<IndividualUser, GetByIdIndividualUserResponse>().ReverseMap();
    }
}
