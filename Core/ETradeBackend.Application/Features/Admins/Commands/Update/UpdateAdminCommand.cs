using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Admins.Commands.Update;

public class UpdateAdminCommand : IRequest<UpdatedAdminResponse>
{
    public Guid AdminId { get; set; }
    public string AdminFirstName { get; set; }
    public string AdminLastName { get; set; }
    public string AdminContactNumber { get; set; }
    public string UserEmail { get; set; }

    public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand, UpdatedAdminResponse>
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateAdminCommandHandler(IAdminRepository adminRepository, IMapper mapper, IUserRepository userRepository)
        {
            this._adminRepository = adminRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UpdatedAdminResponse> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
            Admin? admin = await _adminRepository.GetAsync(
                predicate: p => p.Id == request.AdminId,
                include: p => p.Include(p => p.User),
                cancellationToken: cancellationToken
                );
            admin = _mapper.Map(request, admin);  
            await _adminRepository.UpdateAsync(admin);

            User? user = await _userRepository.GetAsync(u => u.Id == admin.UserId);
            user = _mapper.Map(request, user);
            await _userRepository.UpdateAsync(user);

            UpdatedAdminResponse updatedAdminResponse = _mapper.Map<UpdatedAdminResponse>(admin);   
            return updatedAdminResponse;
        }
    }
}
