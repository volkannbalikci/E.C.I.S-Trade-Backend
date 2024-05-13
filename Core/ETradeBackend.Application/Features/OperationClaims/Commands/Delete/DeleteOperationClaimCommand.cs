using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.OperationClaims.Commands.Delete;

public class DeleteOperationClaimCommand : IRequest<DeletedOperationClaimResponse>
{
    public Guid Id { get; set; }

    public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, DeletedOperationClaimResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOperationClaimRepository _operationClaimRepository;

        public DeleteOperationClaimCommandHandler(IMapper mapper, IOperationClaimRepository operationClaimRepository)
        {
            _mapper = mapper;
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task<DeletedOperationClaimResponse> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
        {
            OperationClaim operationClaim = await _operationClaimRepository.GetAsync(o => o.Id == request.Id);
            await _operationClaimRepository.DeleteAsync(operationClaim);
            DeletedOperationClaimResponse deletedOperationClaimResponse = _mapper.Map<DeletedOperationClaimResponse>(operationClaim);
            return deletedOperationClaimResponse;
        }
    }
}
