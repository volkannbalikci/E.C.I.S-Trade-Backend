using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Admins.Queries.GetByRegisterNumber;

public class GetByRegisterNumberAdminQuery : IRequest<GetByRegisterNumberAdminResponse>
{
    public string RegisterNumber { get; set; }

    public class GetByRegisterNumberAdminQueryHandler : IRequestHandler<GetByRegisterNumberAdminQuery, GetByRegisterNumberAdminResponse>
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public GetByRegisterNumberAdminQueryHandler(IAdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

        public async Task<GetByRegisterNumberAdminResponse> Handle(GetByRegisterNumberAdminQuery request, CancellationToken cancellationToken)
        {
            Admin admin = await _adminRepository.GetAsync(
                predicate: u => u.RegisterNumber == request.RegisterNumber,
                cancellationToken: cancellationToken
                );
            GetByRegisterNumberAdminResponse response = _mapper.Map<GetByRegisterNumberAdminResponse>(admin);
            return  response;
        }
    }
}
