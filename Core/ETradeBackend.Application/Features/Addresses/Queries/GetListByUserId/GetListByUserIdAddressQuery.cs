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

namespace ETradeBackend.Application.Features.Addresses.Queries.GetListByUserId;

public class GetListByUserIdAddressQuery : IRequest<GetListResponse<GetListByUserIdAddressListItemDto>>
{
    public Guid UserId { get; set; }
    public PageRequest PageRequest { get; set; }

    public class GetListByUserIdAddressQueryHandler : IRequestHandler<GetListByUserIdAddressQuery, GetListResponse<GetListByUserIdAddressListItemDto>>
    {
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly IMapper _mapper;

        public GetListByUserIdAddressQueryHandler(IUserAddressRepository userAddressRepository, IMapper mapper)
        {
            _userAddressRepository = userAddressRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByUserIdAddressListItemDto>> Handle(GetListByUserIdAddressQuery request, CancellationToken cancellationToken)
        {
            Paginate<Address> addresses = await _userAddressRepository.GetListByQueryable(
                predicate: u => u.UserId == request.UserId,
                include: a => a.Include(a => a.Address).ThenInclude(a => a.Country)
                .Include(a => a.Address).ThenInclude(a => a.City)
                .Include(a => a.Address).ThenInclude(a => a.District)
                .Include(a => a.Address).ThenInclude(a => a.Neighbourhood)
                ).Select(a => a.Address).ToPaginateAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize);
            GetListResponse<GetListByUserIdAddressListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListByUserIdAddressListItemDto>>(addresses);
            return getListResponse;
        }
    }
}
