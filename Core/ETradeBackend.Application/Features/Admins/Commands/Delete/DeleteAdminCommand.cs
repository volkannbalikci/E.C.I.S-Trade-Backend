using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Admins.Commands.Delete;

public class DeleteAdminCommand : IRequest<DeletedAdminResponse>
{
    public Guid AdminId { get; set; }

    public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand, DeletedAdminResponse>
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteAdminCommandHandler(IAdminRepository adminRepository, IMapper mapper, IUserRepository userRepository)
        {
            this._adminRepository = adminRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<DeletedAdminResponse> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
        {
            Admin? admin = await _adminRepository.GetAsync(p => p.Id == request.AdminId);
            await _adminRepository.DeleteAsync(admin);

            User? user = await _userRepository.GetAsync(u => u.Id == admin.UserId);
            await _userRepository.DeleteAsync(user);

            DeletedAdminResponse deletedAdminResponse = _mapper.Map<DeletedAdminResponse>(request);
            deletedAdminResponse.UserId = admin.UserId;
            return deletedAdminResponse;
        }
    }
}
