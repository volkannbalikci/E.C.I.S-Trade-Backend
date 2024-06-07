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

namespace ETradeBackend.Application.Features.Addresses.Queries.GetListByPostalCode;

public class GetListByPostalCodeAddressQuery : IRequest<GetListResponse<GetListByPostalCodeAddressListItemDto>>
{
    public string PostalCode { get; set; }
    public PageRequest PageRequest { get; set; }

    public class GetListByPostalCodeAddressQueryHandler : IRequestHandler<GetListByPostalCodeAddressQuery, GetListResponse<GetListByPostalCodeAddressListItemDto>>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public GetListByPostalCodeAddressQueryHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByPostalCodeAddressListItemDto>> Handle(GetListByPostalCodeAddressQuery request, CancellationToken cancellationToken)
        {
            Paginate<Address> addresses = await _addressRepository.GetListByPaginateAsync(
            predicate: u => u.PostalCode == request.PostalCode,
            include: a => a.Include(a => a.Country).Include(a => a.City).Include(a => a.District).Include(a => a.Neighbourhood),
            index: request.PageRequest.PageIndex,
            size: request.PageRequest.PageSize,
            cancellationToken: cancellationToken
            );
            GetListResponse<GetListByPostalCodeAddressListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListByPostalCodeAddressListItemDto>>(addresses);
            return getListResponse;
        }
    }
}
