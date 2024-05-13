using AutoMapper;
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

namespace ETradeBackend.Application.Features.Admins.Queries.GetList;

public class GetListAdminQuery : IRequest<GetListResponse<GetListAdminListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListAdminQueryHandler : IRequestHandler<GetListAdminQuery, GetListResponse<GetListAdminListItemDto>>
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public GetListAdminQueryHandler(IAdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAdminListItemDto>> Handle(GetListAdminQuery request, CancellationToken cancellationToken)
        {
            //Paginate<Admin> admins = await _adminRepository.GetListByPaginateAsync(
            //    include: a => a.Include(a => a.IndividualUser),
            //    index: request.PageRequest.PageIndex,
            //    size: request.PageRequest.PageSize,
            //    cancellationToken: cancellationToken);
            //GetListResponse<GetListAdminListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListAdminListItemDto>>(admins);
            return null;
        }
    }
}
