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

namespace ETradeBackend.Application.Features.Cities.Queries.GetList;

public class GetListCityQuery : IRequest<GetListResponse<GetListCityListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCityQueryHandler : IRequestHandler<GetListCityQuery, GetListResponse<GetListCityListItemDto>>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public GetListCityQueryHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCityListItemDto>> Handle(GetListCityQuery request, CancellationToken cancellationToken)
        {
            Paginate<City> cities = await _cityRepository.GetListByPaginateAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: c => c.Include(c => c.Country)
                );
            GetListResponse<GetListCityListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListCityListItemDto>>(cities);
            return getListResponse;
        }
    }
}
