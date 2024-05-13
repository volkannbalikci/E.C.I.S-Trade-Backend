using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.UserOperationClaims.Commands.Update
{
    public class UpdateUserOperationClaimCommand : IRequest<UpdatedUserOperationClaimResponse>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }

        public class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand, UpdatedUserOperationClaimResponse>
        {
            private readonly IMapper _mapper;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;

            public UpdateUserOperationClaimCommandHandler(IMapper mapper, IUserOperationClaimRepository userOperationClaimRepository)
            {
                _mapper = mapper;
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<UpdatedUserOperationClaimResponse> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                UserOperationClaim userOperationClaim = await _userOperationClaimRepository.GetAsync(u => u.Id == request.Id);
                userOperationClaim = _mapper.Map(request, userOperationClaim);
                await _userOperationClaimRepository.UpdateAsync(userOperationClaim);
                UpdatedUserOperationClaimResponse updatedUserOperationClaimResponse = _mapper.Map<UpdatedUserOperationClaimResponse>(userOperationClaim);
                return updatedUserOperationClaimResponse;
            }
        }
    }
}
