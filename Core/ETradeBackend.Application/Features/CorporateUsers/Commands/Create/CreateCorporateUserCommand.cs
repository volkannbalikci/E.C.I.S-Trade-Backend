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

namespace ETradeBackend.Application.Features.CorporateUsers.Commands.Create;

public class CreateCorporateUserCommand : IRequest<CreatedCorporateUserResponse>
{
    public string CompanyName { get; set; }
    public string TaxIdentityNumber { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }

    public class CreateCorporateUserCommandHandler : IRequestHandler<CreateCorporateUserCommand, CreatedCorporateUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ICorporateUserRepository _corporateUserRepository;

        public CreateCorporateUserCommandHandler(IMapper mapper, ICorporateUserRepository corporateUserRepository, IUserRepository userRepository)
        {
            _mapper = mapper;
            _corporateUserRepository = corporateUserRepository;
            _userRepository = userRepository;
        }

        public async Task<CreatedCorporateUserResponse> Handle(CreateCorporateUserCommand request, CancellationToken cancellationToken)
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

            CorporateUser corporateUser = _mapper.Map<CorporateUser>(request);
            corporateUser.Id = Guid.NewGuid();
            corporateUser.UserId = user.Id;
            await _corporateUserRepository.AddAsync(corporateUser);

            CreatedCorporateUserResponse createdCorporateUserResponse = _mapper.Map<CreatedCorporateUserResponse>(corporateUser);
            return createdCorporateUserResponse;
        }
    }
}
