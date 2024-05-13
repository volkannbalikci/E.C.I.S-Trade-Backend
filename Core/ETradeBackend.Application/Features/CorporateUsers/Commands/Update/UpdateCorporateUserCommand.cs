using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateUsers.Commands.Update;

public class UpdateCorporateUserCommand : IRequest<UpdatedCorporateUserResponse>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string CompanyName { get; set; }
    public string TaxIdentityNumber { get; set; }

    public class UpdateCorporateUserCommandHandler : IRequestHandler<UpdateCorporateUserCommand, UpdatedCorporateUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICorporateUserRepository _corporateUserRepository;

        public UpdateCorporateUserCommandHandler(IMapper mapper, ICorporateUserRepository corporateUserRepository)
        {
            _mapper = mapper;
            _corporateUserRepository = corporateUserRepository;
        }

        public async Task<UpdatedCorporateUserResponse> Handle(UpdateCorporateUserCommand request, CancellationToken cancellationToken)
        {
            CorporateUser corporateUser = await _corporateUserRepository.GetAsync(c => c.Id == request.Id);
            corporateUser = _mapper.Map(request, corporateUser);
            await _corporateUserRepository.UpdateAsync(corporateUser);
            UpdatedCorporateUserResponse updatedCorporateUserResponse = _mapper.Map<UpdatedCorporateUserResponse>(corporateUser);
            return updatedCorporateUserResponse;
        }
    }
}
