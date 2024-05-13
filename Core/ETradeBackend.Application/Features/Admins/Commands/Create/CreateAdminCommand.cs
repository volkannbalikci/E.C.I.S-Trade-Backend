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

namespace ETradeBackend.Application.Features.Admins.Commands.Create;

public class CreateAdminCommand : IRequest<CreatedAdminResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string ContactNumber  { get; set; }

    public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, CreatedAdminResponse>
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateAdminCommandHandler(IAdminRepository adminRepository, IUserRepository userRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CreatedAdminResponse> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            User user = _mapper.Map<User>(request);
            user.Id = Guid.NewGuid();
            HashingHelper.CreatePasswordHash(
                  request.Password,
                  passwordHash: out byte[] passwordHash,
                  passwordSalt: out byte[] passwordSalt
                 );
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _userRepository.AddAsync(user);

            Admin admin = new Admin(request.FirstName, request.LastName);
            admin = _mapper.Map<Admin>(request);
            admin.Id = Guid.NewGuid();
            admin.UserId = user.Id;
            await _adminRepository.AddAsync(admin);

            CreatedAdminResponse createdAdminResponse = _mapper.Map<CreatedAdminResponse>(admin);
            return createdAdminResponse;
        }
    }
}
