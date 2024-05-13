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

namespace ETradeBackend.Application.Features.Countries.Queries.GetList;

public class GetListCountryQuery : IRequest<GetListResponse<GetListCountryListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCountryQueryHandler : IRequestHandler<GetListCountryQuery, GetListResponse<GetListCountryListItemDto>>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public GetListCountryQueryHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCountryListItemDto>> Handle(GetListCountryQuery request, CancellationToken cancellationToken)
        {
            Paginate<Country> countries = await _countryRepository.GetListByPaginateAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
                );
            GetListResponse<GetListCountryListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListCountryListItemDto>>(countries);
            return getListResponse;
        }
    }
}
