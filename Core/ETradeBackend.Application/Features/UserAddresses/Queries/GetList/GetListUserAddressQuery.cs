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

namespace ETradeBackend.Application.Features.UserAddresses.Queries.GetList;

public class GetListUserAddressQuery : IRequest<GetListResponse<GetListUserAddressListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListUserAddressQueryHandler : IRequestHandler<GetListUserAddressQuery, GetListResponse<GetListUserAddressListItemDto>>
    {
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly IMapper _mapper;

        public GetListUserAddressQueryHandler(IUserAddressRepository userAddressRepository, IMapper mapper)
        {
            _userAddressRepository = userAddressRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserAddressListItemDto>> Handle(GetListUserAddressQuery request, CancellationToken cancellationToken)
        {
            Paginate<UserAddress> paginate = await _userAddressRepository.GetListByPaginateAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: u => u.Include(u => u.Address)
                .Include(u => u.Address.Country) 
                .Include(u => u.Address.City) 
                .Include(u => u.Address.District) 
                .Include(u => u.Address.Neighbourhood),
                cancellationToken: cancellationToken
                );
            GetListResponse<GetListUserAddressListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListUserAddressListItemDto>>(paginate);
            return getListResponse;
        }
    }
}
