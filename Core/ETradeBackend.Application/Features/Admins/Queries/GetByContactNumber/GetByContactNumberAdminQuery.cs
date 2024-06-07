using AutoMapper;
using ETradeBackend.Application.Features.Admins.Queries.GetByFirstName;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using Framework.Application.Requests;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Admins.Queries.GetListByContactNumber;

public class GetByContactNumberAdminQuery : IRequest<GetByContactNumberAdminResponse>
{
    public string ContactNumber { get; set; }

    public class GetByContactNumberAdminQueryHandler : IRequestHandler<GetByContactNumberAdminQuery, GetByContactNumberAdminResponse>
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public GetByContactNumberAdminQueryHandler(IAdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }
        public async Task<GetByContactNumberAdminResponse> Handle(GetByContactNumberAdminQuery request, CancellationToken cancellationToken)
        {
            Admin admins = await _adminRepository.GetAsync(
               predicate: a => a.ContactNumber == request.ContactNumber,
               include: a => a.Include(a => a.User),
               cancellationToken: cancellationToken);
            GetByContactNumberAdminResponse getByContactNumberAdminResponse = _mapper.Map<GetByContactNumberAdminResponse>(admins);
            return getByContactNumberAdminResponse;
        }
    }
}
