using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.OperationClaims.Commands.Update;

public class UpdateOperationClaimCommand : IRequest<UpdatedOperationClaimResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOperationClaimRepository _operationClaimRepository;

        public UpdateOperationClaimCommandHandler(IMapper mapper, IOperationClaimRepository operationClaimRepository)
        {
            _mapper = mapper;
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task<UpdatedOperationClaimResponse> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
        {
            OperationClaim operationClaim = await _operationClaimRepository.GetAsync(o => o.Id == request.Id);
            operationClaim = _mapper.Map(request, operationClaim);
            await _operationClaimRepository.UpdateAsync(operationClaim);
            UpdatedOperationClaimResponse updatedOperationClaimResponse = _mapper.Map<UpdatedOperationClaimResponse>(operationClaim);
            return updatedOperationClaimResponse;
        }
    }
}
