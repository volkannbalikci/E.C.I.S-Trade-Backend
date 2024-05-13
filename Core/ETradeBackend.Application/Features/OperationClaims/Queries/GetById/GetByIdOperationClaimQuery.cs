using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.OperationClaims.Queries.GetById;

public class GetByIdOperationClaimQuery : IRequest<GetByIdOpereationClaimResponse>
{
    public Guid Id { get; set; }

    public class GetByIdOperationClaimQueryHandler : IRequestHandler<GetByIdOperationClaimQuery, GetByIdOpereationClaimResponse>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public GetByIdOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdOpereationClaimResponse> Handle(GetByIdOperationClaimQuery request, CancellationToken cancellationToken)
        {
            OperationClaim operationClaim = await _operationClaimRepository.GetAsync(
                predicate: o => o.Id == request.Id,
                cancellationToken: cancellationToken
                );
            GetByIdOpereationClaimResponse getByIdOpereationClaimResponse = _mapper.Map<GetByIdOpereationClaimResponse>(operationClaim);
            return getByIdOpereationClaimResponse;
        }
    }
}
