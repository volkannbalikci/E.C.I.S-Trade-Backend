using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.UserOperationClaims.Queries.GetById;

public class GetByIdUserOperationClaimQuery : IRequest<GetByIdUserOperationClaimResponse>
{
    public Guid Id { get; set; }

    public class GetByIdUserOperationClaimQueryHandler : IRequestHandler<GetByIdUserOperationClaimQuery, GetByIdUserOperationClaimResponse>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public GetByIdUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdUserOperationClaimResponse> Handle(GetByIdUserOperationClaimQuery request, CancellationToken cancellationToken)
        {
            UserOperationClaim userOperationClaim = await _userOperationClaimRepository.GetAsync(
                predicate: u => u.Id == request.Id,
                include: u => u.Include(u => u.OperationClaim),
                cancellationToken: cancellationToken
                );
            GetByIdUserOperationClaimResponse getByIdUserOperationClaimResponse = _mapper.Map<GetByIdUserOperationClaimResponse>(userOperationClaim);
            return getByIdUserOperationClaimResponse;
        }
    }
}
