using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.UserOperationClaims.Commands.Delete;

public class DeleteUserOperationClaimCommand : IRequest<DeletedUserOperationClaimResponse>
{
    public Guid Id { get; set; }

    public class DeleteUserOperationClaimHandler : IRequestHandler<DeleteUserOperationClaimCommand, DeletedUserOperationClaimResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public DeleteUserOperationClaimHandler(IMapper mapper, IUserOperationClaimRepository userOperationClaimRepository)
        {
            _mapper = mapper;
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<DeletedUserOperationClaimResponse> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            UserOperationClaim userOperationClaim = await _userOperationClaimRepository.GetAsync(u => u.Id == request.Id);
            await _userOperationClaimRepository.DeleteAsync(userOperationClaim);
            DeletedUserOperationClaimResponse deletedUserOperationClaimResponse = _mapper.Map<DeletedUserOperationClaimResponse>(userOperationClaim);
            return deletedUserOperationClaimResponse;
        }
    }
}
