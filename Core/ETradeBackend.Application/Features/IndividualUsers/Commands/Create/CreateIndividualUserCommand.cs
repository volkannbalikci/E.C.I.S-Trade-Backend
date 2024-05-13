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

namespace ETradeBackend.Application.Features.IndividualUsers.Commands.Create;

public class CreateIndividualUserCommand : IRequest<CreatedIndividualUserResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }

    public class CreateIndividualUserCommandHandler : IRequestHandler<CreateIndividualUserCommand, CreatedIndividualUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IIndividualUserRepository _ındividualUserRepository;

        public CreateIndividualUserCommandHandler(IMapper mapper, IIndividualUserRepository ındividualUserRepository, IUserRepository userRepository)
        {
            _mapper = mapper;
            _ındividualUserRepository = ındividualUserRepository;
            _userRepository = userRepository;
        }

        public async Task<CreatedIndividualUserResponse> Handle(CreateIndividualUserCommand request, CancellationToken cancellationToken)
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

            IndividualUser individualUser = _mapper.Map<IndividualUser>(request);
            individualUser.Id = Guid.NewGuid();
            individualUser.UserId = user.Id;
            await _ındividualUserRepository.AddAsync(individualUser);

            CreatedIndividualUserResponse createdIndividualUserResponse = _mapper.Map<CreatedIndividualUserResponse>(individualUser);
            return createdIndividualUserResponse;
        }
    }
}
