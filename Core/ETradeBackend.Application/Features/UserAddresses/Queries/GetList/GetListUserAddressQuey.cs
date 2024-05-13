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

public class GetListUserAddressQuey : IRequest<GetListResponse<GetListUserAddressListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListUserAddressQueyHandler : IRequestHandler<GetListUserAddressQuey, GetListResponse<GetListUserAddressListItemDto>>
    {
        public IUserAddressRepository _userAddressRepository { get; set; }
        public IMapper _mapper { get; set; }

        public GetListUserAddressQueyHandler(IUserAddressRepository userAddressRepository, IMapper mapper)
        {
            _userAddressRepository = userAddressRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserAddressListItemDto>> Handle(GetListUserAddressQuey request, CancellationToken cancellationToken)
        {
            Paginate<UserAddress> userAddresses = await _userAddressRepository.GetListByPaginateAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: u => u.Include(u => u.Address),
                cancellationToken: cancellationToken
                );
            GetListResponse<GetListUserAddressListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListUserAddressListItemDto>>(userAddresses);
            return getListResponse;
        }
    }
}
