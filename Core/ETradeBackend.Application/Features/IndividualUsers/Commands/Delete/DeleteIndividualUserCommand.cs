using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.IndividualUsers.Commands.Delete;

public class DeleteIndividualUserCommand : IRequest<DeletedIndividualUserResponse>
{
    public Guid Id { get; set; }

    public class DeleteIndividualUserCommandHandler : IRequestHandler<DeleteIndividualUserCommand, DeletedIndividualUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IIndividualUserRepository _individualUserRepository;

        public DeleteIndividualUserCommandHandler(IMapper mapper, IIndividualUserRepository individualUserRepository)
        {
            _mapper = mapper;
            _individualUserRepository = individualUserRepository;
        }

        public async Task<DeletedIndividualUserResponse> Handle(DeleteIndividualUserCommand request, CancellationToken cancellationToken)
        {
            IndividualUser individualUser = await _individualUserRepository.GetAsync(i => i.Id == request.Id);
            await _individualUserRepository.DeleteAsync(individualUser);
            DeletedIndividualUserResponse deletedIndividualUserResponse = _mapper.Map<DeletedIndividualUserResponse>(individualUser);
            return deletedIndividualUserResponse;
        }
    }
}
