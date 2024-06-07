using AutoMapper;
using ETradeBackend.Application.Features.Addresses.Queries.GetListByCityId;
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

namespace ETradeBackend.Application.Features.Addresses.Queries.GetListByDistrictId;

public class GetListByDistrictIdAddressQuery : IRequest<GetListResponse<GetListByDistrictIdAddressListItemDto>>
{
    public Guid DistrictId { get; set; }
    public PageRequest PageRequest { get; set; }
    public class GetListByDistrictIdAddressQueryHandler : IRequestHandler<GetListByDistrictIdAddressQuery, GetListResponse<GetListByDistrictIdAddressListItemDto>>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public GetListByDistrictIdAddressQueryHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByDistrictIdAddressListItemDto>> Handle(GetListByDistrictIdAddressQuery request, CancellationToken cancellationToken)
        {
            Paginate<Address> addresses = await _addressRepository.GetListByPaginateAsync(
               predicate: u => u.DistrictId == request.DistrictId,
               include: a => a.Include(a => a.Country).Include(a => a.City).Include(a => a.District).Include(a => a.Neighbourhood),
               index: request.PageRequest.PageIndex,
               size: request.PageRequest.PageSize,
               cancellationToken: cancellationToken
               );
            GetListResponse<GetListByDistrictIdAddressListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListByDistrictIdAddressListItemDto>>(addresses);
            return getListResponse;
        }
    }
}
