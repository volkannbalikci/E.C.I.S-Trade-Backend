using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.UserOperationClaims.Commands.Create;

public class CreateUserOperationClaimCommand : IRequest<CreatedUserOperationClaimResponse>
{
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }

    public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, CreatedUserOperationClaimResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public CreateUserOperationClaimCommandHandler(IMapper mapper, IUserOperationClaimRepository userOperationClaimRepository)
        {
            _mapper = mapper;
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<CreatedUserOperationClaimResponse> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            UserOperationClaim userOperationClaim = _mapper.Map<UserOperationClaim>(request);
            userOperationClaim.Id = Guid.NewGuid();
            await _userOperationClaimRepository.AddAsync(userOperationClaim);
            CreatedUserOperationClaimResponse createdUserOperationClaimResponse = _mapper.Map<CreatedUserOperationClaimResponse>(userOperationClaim);
            return createdUserOperationClaimResponse;
        }
    }
}
