using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using Framework.Application.Requests;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateUsers.Queries.GetList;

public class GetListCorporateUserQuery : IRequest<GetListResponse<GetListCorporateUserListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCorporateUserQueryHandler : IRequestHandler<GetListCorporateUserQuery, GetListResponse<GetListCorporateUserListItemDto>>
    {
        private readonly ICorporateUserRepository _corporateUserRepository;
        private readonly IMapper _mapper;

        public GetListCorporateUserQueryHandler(ICorporateUserRepository corporateUserRepository, IMapper mapper)
        {
            _corporateUserRepository = corporateUserRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCorporateUserListItemDto>> Handle(GetListCorporateUserQuery request, CancellationToken cancellationToken)
        {
            Paginate<CorporateUser> corporateUsers = await _corporateUserRepository.GetListByPaginateAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
                );
            GetListResponse<GetListCorporateUserListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListCorporateUserListItemDto>>(corporateUsers);
            return getListResponse;
        }
    }
}
