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

namespace ETradeBackend.Application.Features.Admins.Queries.GetById;

public class GetByIdAdminQuery : IRequest<GetByIdAdminResponse>
{
    public Guid Id { get; set; }

    public class GetByIdAdminQueryHandler : IRequestHandler<GetByIdAdminQuery, GetByIdAdminResponse>
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public GetByIdAdminQueryHandler(IAdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdAdminResponse> Handle(GetByIdAdminQuery request, CancellationToken cancellationToken)
        {
            //Admin admin = await _adminRepository.GetAsync(
            //    predicate: a => a.Id == request.Id,
            //    include: a => a.Include(a => a.IndividualUser)
            //    );
            //GetByIdAdminResponse getByIdAdminResponse = _mapper.Map<GetByIdAdminResponse>(admin);
            return null;
        }
    }
}
