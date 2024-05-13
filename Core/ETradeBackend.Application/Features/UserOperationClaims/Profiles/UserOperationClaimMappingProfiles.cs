using AutoMapper;
using ETradeBackend.Application.Features.UserOperationClaims.Commands.Create;
using ETradeBackend.Application.Features.UserOperationClaims.Commands.Delete;
using ETradeBackend.Application.Features.UserOperationClaims.Commands.Update;
using ETradeBackend.Application.Features.UserOperationClaims.Queries.GetById;
using ETradeBackend.Application.Features.UserOperationClaims.Queries.GetList;
using ETradeBackend.Domain.Entities;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.UserOperationClaims.Profiles;

public class UserOperationClaimMappingProfiles : Profile
{
    public UserOperationClaimMappingProfiles()
    {
        CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
        CreateMap<UserOperationClaim, CreatedUserOperationClaimResponse>().ReverseMap();
        CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();
        CreateMap<UserOperationClaim, DeletedUserOperationClaimResponse>().ReverseMap();
        CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();
        CreateMap<UserOperationClaim, UpdatedUserOperationClaimResponse>().ReverseMap();

        CreateMap<Paginate<UserOperationClaim>, GetListResponse<GetListUserOperationClaimListItemDto>>().ReverseMap();
        CreateMap<UserOperationClaim, GetListUserOperationClaimListItemDto>()
            .ForMember(destinationMember: u => u.UserId, memberOptions: opt => opt.MapFrom(u => u.UserId))
            .ForMember(destinationMember: u => u.OperationClaimName, memberOptions: opt => opt.MapFrom(u => u.OperationClaim.Name)).ReverseMap();

        CreateMap<UserOperationClaim, GetByIdUserOperationClaimResponse>()
            .ForMember(destinationMember: u => u.UserId, memberOptions: opt => opt.MapFrom(u => u.UserId))
            .ForMember(destinationMember: u => u.OperationClaimName, memberOptions: opt => opt.MapFrom(u => u.OperationClaim.Name)).ReverseMap();
    }
}
