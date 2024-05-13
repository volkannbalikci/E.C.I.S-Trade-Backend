using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using Framework.Application.Security.Hashing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Users.Commands.Create;

public class CreateUserCommand : IRequest<CreatedUserResponse>
{
    public string Password { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreatedUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<CreatedUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = _mapper.Map<User>(request);
            user.Id = Guid.NewGuid();
            HashingHelper.CreatePasswordHash(request.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
                );
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;
            await _userRepository.AddAsync(user);
            CreatedUserResponse createdUserResponse = _mapper.Map<CreatedUserResponse>(user);
            return createdUserResponse;
        }
    }
}
