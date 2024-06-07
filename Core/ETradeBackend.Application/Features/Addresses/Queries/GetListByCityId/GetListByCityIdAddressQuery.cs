using AutoMapper;
using ETradeBackend.Application.Features.Addresses.Queries.GetList;
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

namespace ETradeBackend.Application.Features.Addresses.Queries.GetListByCityId;

public class GetListByCityIdAddressQuery : IRequest<GetListResponse<GetListByCityIdAddressListItemDto>>
{
    public Guid CityId { get; set; }
    public PageRequest PageRequest { get; set; }

    public class GetListByCityIdAddressQueryHandler : IRequestHandler<GetListByCityIdAddressQuery, GetListResponse<GetListByCityIdAddressListItemDto>>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public GetListByCityIdAddressQueryHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByCityIdAddressListItemDto>> Handle(GetListByCityIdAddressQuery request, CancellationToken cancellationToken)
        {
            Paginate<Address> addresses = await _addressRepository.GetListByPaginateAsync(
                predicate: u => u.CityId == request.CityId,
                include: a => a.Include(a => a.Country).Include(a => a.City).Include(a => a.District).Include(a => a.Neighbourhood),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
                );
            GetListResponse<GetListByCityIdAddressListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListByCityIdAddressListItemDto>>(addresses);
            return getListResponse;
        }
    }
}

