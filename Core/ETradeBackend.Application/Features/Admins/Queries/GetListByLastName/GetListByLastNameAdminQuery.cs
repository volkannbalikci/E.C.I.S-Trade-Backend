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

namespace ETradeBackend.Application.Features.Admins.Queries.GetListByLastName;

public class GetListByLastNameAdminQuery : IRequest<GetListResponse<GetListByLastNameAdminListItemDto>>
{
    public string LastName { get; set; }
    public PageRequest PageRequest { get; set; }

    public class GetListByLastNameAdminQueryHandler : IRequestHandler<GetListByLastNameAdminQuery, GetListResponse<GetListByLastNameAdminListItemDto>>
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public GetListByLastNameAdminQueryHandler(IAdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByLastNameAdminListItemDto>> Handle(GetListByLastNameAdminQuery request, CancellationToken cancellationToken)
        {
            Paginate<Admin> admins = await _adminRepository.GetListByPaginateAsync(
                predicate: a => a.LastName == request.LastName,
                include: a => a.Include(a => a.User),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken);
            GetListResponse<GetListByLastNameAdminListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListByLastNameAdminListItemDto>>(admins);
            return getListResponse;
        }
    }
}
