using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Users.Commands.Delete;

public class DeleteUserCommand : IRequest<DeletedUserResponse>
{
    public Guid Id { get; set; }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeletedUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<DeletedUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetAsync(u => u.Id == request.Id);
            await _userRepository.DeleteAsync(user);
            DeletedUserResponse deletedUserResponse = _mapper.Map<DeletedUserResponse>(user);
            return deletedUserResponse;
        }
    }
}
