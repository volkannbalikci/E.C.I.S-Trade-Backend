using AutoMapper;
using ETradeBackend.Application.Features.OperationClaims.Commands.Create;
using ETradeBackend.Application.Features.OperationClaims.Commands.Delete;
using ETradeBackend.Application.Features.OperationClaims.Commands.Update;
using ETradeBackend.Application.Features.OperationClaims.Queries.GetById;
using ETradeBackend.Application.Features.OperationClaims.Queries.GetByPrefix;
using ETradeBackend.Application.Features.OperationClaims.Queries.GetList;
using ETradeBackend.Domain.Entities;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.OperationClaims.Profiles;

public class OperationClaimMappingProfiles : Profile
{
    public OperationClaimMappingProfiles()
    {
        CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();
        CreateMap<OperationClaim, CreatedOperationClaimResponse>().ReverseMap();
        CreateMap<OperationClaim, DeleteOperationClaimCommand>().ReverseMap();
        CreateMap<OperationClaim, DeletedOperationClaimResponse>().ReverseMap();
        CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();
        CreateMap<OperationClaim, UpdatedOperationClaimResponse>().ReverseMap();

        CreateMap<Paginate<OperationClaim>, GetListResponse<GetListOperationClaimListItemDto>>().ReverseMap();
        CreateMap<Paginate<OperationClaim>, GetListResponse<GetListByPrefixOperationClaimListItemDto>>().ReverseMap();

        CreateMap<OperationClaim, GetListOperationClaimListItemDto>()
            .ForMember(destinationMember: o => o.OperationClaimName, memberOptions: opt => opt.MapFrom(o => o.Name)).ReverseMap();

        CreateMap<OperationClaim, GetByIdOpereationClaimResponse>()
            .ForMember(destinationMember: o => o.OperationClaimName, memberOptions: opt => opt.MapFrom(o => o.Name)).ReverseMap();
    }
}
