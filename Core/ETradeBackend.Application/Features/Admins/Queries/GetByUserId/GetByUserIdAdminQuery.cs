using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Admins.Queries.GetByUserId;

public class GetByUserIdAdminQuery : IRequest<GetByUserIdAdminResponse>
{
    public Guid UserId { get; set; }

    public class GetByUserIdAdminQueryHandler : IRequestHandler<GetByUserIdAdminQuery, GetByUserIdAdminResponse>
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public GetByUserIdAdminQueryHandler(IAdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

        public async Task<GetByUserIdAdminResponse> Handle(GetByUserIdAdminQuery request, CancellationToken cancellationToken)
        {
            Admin admin = await _adminRepository.GetAsync(
                predicate: u => u.UserId == request.UserId,
                cancellationToken: cancellationToken
                );
            GetByUserIdAdminResponse response = _mapper.Map<GetByUserIdAdminResponse>(admin);
            return response;
        }
    }
}
