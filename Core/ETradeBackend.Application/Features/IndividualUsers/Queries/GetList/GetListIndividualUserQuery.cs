using AutoMapper;
using ETradeBackend.Application.Features.UserAddresses.Queries.GetList;
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

namespace ETradeBackend.Application.Features.IndividualUsers.Queries.GetList;

public class GetListIndividualUserQuery : IRequest<GetListResponse<GetListIndividualUserListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListIndividualUserQueryHandler : IRequestHandler<GetListIndividualUserQuery, GetListResponse<GetListIndividualUserListItemDto>>
    {
        private readonly IIndividualUserRepository _individualUserRepository;
        private readonly IMapper _mapper;
        private readonly IUserAddressRepository _userAddressRepository;

        public GetListIndividualUserQueryHandler(IIndividualUserRepository individualUserRepository, IMapper mapper, IUserAddressRepository userAddressRepository)
        {
            _individualUserRepository = individualUserRepository;
            _mapper = mapper;
            _userAddressRepository = userAddressRepository;
        }

        public async Task<GetListResponse<GetListIndividualUserListItemDto>> Handle(GetListIndividualUserQuery request, CancellationToken cancellationToken)
        {
            Paginate<IndividualUser> individualUsers = await _individualUserRepository.GetListByPaginateAsync(
                include: i => i.Include(i => i.User),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
                );
            GetListResponse<GetListIndividualUserListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListIndividualUserListItemDto>>(individualUsers);
            foreach ( var item in getListResponse.Items )
            {
                var _userAddresses = _userAddressRepository.GetListByQueryable(
                    include: u => u.Include(u => u.Address)
                    .Include(u => u.Address.Country)
                    .Include(u => u.Address.City)
                    .Include(u => u.Address.District)
                    .Include(u => u.Address.Neighbourhood),
                    predicate: u => u.UserId == item.UserId).ToList();
                    
                item.UserAddresses = _mapper.Map<List<GetListUserAddressListItemDto>>(_userAddresses);
            }
            return getListResponse;
        }
    }
}
