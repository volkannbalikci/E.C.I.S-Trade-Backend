using AutoMapper;
using ETradeBackend.Application.Features.CorporateUsers.Commands.Create;
using ETradeBackend.Application.Features.CorporateUsers.Commands.Delete;
using ETradeBackend.Application.Features.CorporateUsers.Commands.Update;
using ETradeBackend.Application.Features.CorporateUsers.Queries.GetById;
using ETradeBackend.Application.Features.CorporateUsers.Queries.GetList;
using ETradeBackend.Domain.Entities;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateUsers.Profiles;

public class CorporateUserMappingProfiles : Profile
{
    public CorporateUserMappingProfiles()
    {
        CreateMap<CorporateUser, CreateCorporateUserCommand>().ReverseMap();
        CreateMap<CorporateUser, CreatedCorporateUserResponse>().ReverseMap();
        CreateMap<CorporateUser, DeleteCorporateUserCommand>().ReverseMap();
        CreateMap<CorporateUser, DeletedCorporateUserResponse>().ReverseMap();
        CreateMap<CorporateUser, UpdateCorporateUserCommand>().ReverseMap();
        CreateMap<CorporateUser, UpdatedCorporateUserResponse>().ReverseMap();
        CreateMap<User, CreateCorporateUserCommand>().ReverseMap();

        CreateMap<Paginate<CorporateUser>, GetListResponse<GetListCorporateUserListItemDto>>().ReverseMap();
        CreateMap<CorporateUser, GetListCorporateUserListItemDto>()
            .ForMember(u => u.Id, u => u.MapFrom(u => u.Id))
            .ForMember(u => u.UserId, u => u.MapFrom(u => u.UserId))
            .ForMember(u => u.CompanyName, u => u.MapFrom(u => u.CompanyName))
            .ForMember(u => u.TaxIdentityNumber, u => u.MapFrom(u => u.TaxIdentityNumber))
            .ForMember(u => u.Email, u => u.MapFrom(u => u.User.Email))
            .ReverseMap();
        CreateMap<CorporateUser, GetByIdCorporateUserResponse>().ReverseMap();

        //CreateMap<CreateCorporateUserCommand, User>().ForMember(e => e.PasswordHash, e => e.MapFrom(e => HashHashingHelper.GetHashByKey(e.Password)))
        //                                             .ForMember(e => e.PasswordSalt, e => e.MapFrom(e => HashHashingHelper.GetSaltByKey(e.Password)))
    }
}
