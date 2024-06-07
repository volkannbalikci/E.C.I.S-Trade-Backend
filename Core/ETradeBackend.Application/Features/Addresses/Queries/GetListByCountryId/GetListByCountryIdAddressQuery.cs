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

namespace ETradeBackend.Application.Features.Addresses.Queries.GetListByCountryId;

public class GetListByCountryIdAddressQuery : IRequest<GetListResponse<GetListByCountryIdAddressListItemDto>>
{
    public Guid CountryId { get; set; }
    public PageRequest PageRequest { get; set; }
    
    public class GetListByCountryIdAddressQueryHandler : IRequestHandler<GetListByCountryIdAddressQuery, GetListResponse<GetListByCountryIdAddressListItemDto>>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public GetListByCountryIdAddressQueryHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByCountryIdAddressListItemDto>> Handle(GetListByCountryIdAddressQuery request, CancellationToken cancellationToken)
        {
            Paginate<Address> addresses = await _addressRepository.GetListByPaginateAsync(
               predicate: u => u.CountryId == request.CountryId,
               include: a => a.Include(a => a.Country).Include(a => a.City).Include(a => a.District).Include(a => a.Neighbourhood),
               index: request.PageRequest.PageIndex,
               size: request.PageRequest.PageSize,
               cancellationToken: cancellationToken
               );
            GetListResponse<GetListByCountryIdAddressListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListByCountryIdAddressListItemDto>>(addresses);
            return getListResponse;
        }
    }
}
