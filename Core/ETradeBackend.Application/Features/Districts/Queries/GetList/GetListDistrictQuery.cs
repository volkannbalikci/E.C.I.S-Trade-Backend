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

namespace ETradeBackend.Application.Features.Districts.Queries.GetList;

public class GetListDistrictQuery : IRequest<GetListResponse<GetListDistrictListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListDistrictQueryHandler : IRequestHandler<GetListDistrictQuery, GetListResponse<GetListDistrictListItemDto>>
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IMapper _mapper;

        public GetListDistrictQueryHandler(IDistrictRepository districtRepository, IMapper mapper)
        {
            _districtRepository = districtRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDistrictListItemDto>> Handle(GetListDistrictQuery request, CancellationToken cancellationToken)
        {
            Paginate<District> districts = await _districtRepository.GetListByPaginateAsync(
                include: d => d.Include(d => d.City),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
                ) ;
            GetListResponse<GetListDistrictListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListDistrictListItemDto>>(districts);
            return getListResponse;
        }
    }
}
