using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.IndividualUsers.Commands.Update;

public class UpdateIndividualUserCommand : IRequest<UpdatedIndividualUserReponse>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }

    public class UpdateIndividualUserCommandHandler : IRequestHandler<UpdateIndividualUserCommand, UpdatedIndividualUserReponse>
    {
        private readonly IMapper _mapper;
        private readonly IIndividualUserRepository _ındividualUserRepository;

        public UpdateIndividualUserCommandHandler(IMapper mapper, IIndividualUserRepository ındividualUserRepository)
        {
            _mapper = mapper;
            _ındividualUserRepository = ındividualUserRepository;
        }

        public async Task<UpdatedIndividualUserReponse> Handle(UpdateIndividualUserCommand request, CancellationToken cancellationToken)
        {
            IndividualUser individualUser = await _ındividualUserRepository.GetAsync(i => i.Id == request.Id);
            individualUser = _mapper.Map(request, individualUser);
            await _ındividualUserRepository.UpdateAsync(individualUser);
            UpdatedIndividualUserReponse updatedIndividualUserReponse = _mapper.Map<UpdatedIndividualUserReponse>(individualUser);
            return updatedIndividualUserReponse;
        }
    }
}
