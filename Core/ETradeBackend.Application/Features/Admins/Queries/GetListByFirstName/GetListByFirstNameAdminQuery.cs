using AutoMapper;
using ETradeBackend.Application.Features.Admins.Queries.GetList;
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

namespace ETradeBackend.Application.Features.Admins.Queries.GetByFirstName;

public class GetListByFirstNameAdminQuery : IRequest<GetListResponse<GetListByFirstNameAdminListItemDto>>
{
    public string FirstName { get; set; }
    public PageRequest PageRequest { get; set; }

    public class GetListByFirstNameAdminQueryHandler : IRequestHandler<GetListByFirstNameAdminQuery, GetListResponse<GetListByFirstNameAdminListItemDto>>
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public GetListByFirstNameAdminQueryHandler(IAdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByFirstNameAdminListItemDto>> Handle(GetListByFirstNameAdminQuery request, CancellationToken cancellationToken)
        {
            Paginate<Admin> admins = await _adminRepository.GetListByPaginateAsync(
                predicate: a => a.FirstName == request.FirstName,
                include: a => a.Include(a => a.User),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken);
            GetListResponse<GetListByFirstNameAdminListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListByFirstNameAdminListItemDto>>(admins);
            return getListResponse;
        }
    }
}
