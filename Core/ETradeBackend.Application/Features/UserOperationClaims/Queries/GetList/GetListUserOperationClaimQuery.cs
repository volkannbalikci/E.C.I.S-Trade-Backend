using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using Framework.Application.Requests;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.UserOperationClaims.Queries.GetList;

public class GetListUserOperationClaimQuery : IRequest<GetListResponse<GetListUserOperationClaimListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListUserOperationClaimQueryHandler : IRequestHandler<GetListUserOperationClaimQuery, GetListResponse<GetListUserOperationClaimListItemDto>>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public GetListUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserOperationClaimListItemDto>> Handle(GetListUserOperationClaimQuery request, CancellationToken cancellationToken)
        {
            Paginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListByPaginateAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: u => u.Include(u => u.OperationClaim),
                cancellationToken: cancellationToken
                );
            GetListResponse<GetListUserOperationClaimListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListUserOperationClaimListItemDto>>(userOperationClaims);
            return getListResponse;
        }
    }
}
