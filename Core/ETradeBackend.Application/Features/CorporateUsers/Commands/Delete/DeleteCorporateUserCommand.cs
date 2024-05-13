using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateUsers.Commands.Delete;

public class DeleteCorporateUserCommand : IRequest<DeletedCorporateUserResponse>
{
    public Guid Id { get; set; }

    public class DeleteCorporateUserCommandHandler : IRequestHandler<DeleteCorporateUserCommand, DeletedCorporateUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICorporateUserRepository _corporateUserRepository;

        public DeleteCorporateUserCommandHandler(IMapper mapper, ICorporateUserRepository corporateUserRepository)
        {
            _mapper = mapper;
            _corporateUserRepository = corporateUserRepository;
        }

        public async Task<DeletedCorporateUserResponse> Handle(DeleteCorporateUserCommand request, CancellationToken cancellationToken)
        {
            CorporateUser corporateUser = await _corporateUserRepository.GetAsync(c => c.Id == request.Id);
            await _corporateUserRepository.DeleteAsync(corporateUser);
            DeletedCorporateUserResponse deletedCorporateUserResponse = _mapper.Map<DeletedCorporateUserResponse>(corporateUser);
            return deletedCorporateUserResponse;
        }
    }
}
