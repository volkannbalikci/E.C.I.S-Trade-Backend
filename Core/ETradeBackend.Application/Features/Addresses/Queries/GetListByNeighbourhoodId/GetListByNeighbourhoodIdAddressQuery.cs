using AutoMapper;
using ETradeBackend.Application.Features.Addresses.Queries.GetListByDistrictId;
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

namespace ETradeBackend.Application.Features.Addresses.Queries.GetListByNeighbourhoodId;

public class GetListByNeighbourhoodIdAddressQuery : IRequest<GetListResponse<GetListByNeighbourhoodIdAddressListItemDto>>
{
    public Guid NeighbourhoodId { get; set; }
    public PageRequest PageRequest { get; set; }

    public class GetListByNeighbourhoodIdAddressQueryHandler : IRequestHandler<GetListByNeighbourhoodIdAddressQuery, GetListResponse<GetListByNeighbourhoodIdAddressListItemDto>>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public GetListByNeighbourhoodIdAddressQueryHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByNeighbourhoodIdAddressListItemDto>> Handle(GetListByNeighbourhoodIdAddressQuery request, CancellationToken cancellationToken)
        {
            Paginate<Address> addresses = await _addressRepository.GetListByPaginateAsync(
              predicate: u => u.NeighbourhoodId == request.NeighbourhoodId,
              include: a => a.Include(a => a.Country).Include(a => a.City).Include(a => a.District).Include(a => a.Neighbourhood),
              index: request.PageRequest.PageIndex,
              size: request.PageRequest.PageSize,
              cancellationToken: cancellationToken
              );
            GetListResponse<GetListByNeighbourhoodIdAddressListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListByNeighbourhoodIdAddressListItemDto>>(addresses);
            return getListResponse;
        }
    }
}
