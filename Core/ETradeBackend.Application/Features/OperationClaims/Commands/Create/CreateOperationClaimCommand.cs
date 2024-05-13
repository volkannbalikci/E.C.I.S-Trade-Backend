using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.OperationClaims.Commands.Create;

public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimResponse>
{
    public string Name { get; set; }

    public class CreateOperationClaimHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOperationClaimRepository _operationClaimRepository;

        public CreateOperationClaimHandler(IMapper mapper, IOperationClaimRepository operationClaimRepository)
        {
            _mapper = mapper;
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task<CreatedOperationClaimResponse> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
        {
            OperationClaim operationClaim = _mapper.Map<OperationClaim>(request);
            operationClaim.Id = Guid.NewGuid();
            await _operationClaimRepository.AddAsync(operationClaim);
            CreatedOperationClaimResponse createdOperationClaimResponse = _mapper.Map<CreatedOperationClaimResponse>(operationClaim);
            return createdOperationClaimResponse;
        }
    }
}
