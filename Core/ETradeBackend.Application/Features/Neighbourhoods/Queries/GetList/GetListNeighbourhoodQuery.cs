using AutoMapper;
using ETradeBackend.Application.Features.Districts.Queries.GetList;
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

namespace ETradeBackend.Application.Features.Neighbourhoods.Queries.GetList;

public class GetListNeighbourhoodQuery : IRequest<GetListResponse<GetListNeighbourhoodListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListNeighbourhoodQueryHandler : IRequestHandler<GetListNeighbourhoodQuery, GetListResponse<GetListNeighbourhoodListItemDto>>
    {
        private readonly INeighbourhoodRepository _neighbourhoodRepository;
        private readonly IMapper _mapper;

        public GetListNeighbourhoodQueryHandler(INeighbourhoodRepository neighbourhoodRepository, IMapper mapper)
        {
            _neighbourhoodRepository = neighbourhoodRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListNeighbourhoodListItemDto>> Handle(GetListNeighbourhoodQuery request, CancellationToken cancellationToken)
        {
            Paginate<Neighbourhood> neighbourhoods = await _neighbourhoodRepository.GetListByPaginateAsync(
                include: n => n.Include(n => n.District),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
                );
            GetListResponse<GetListNeighbourhoodListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListNeighbourhoodListItemDto>>(neighbourhoods);
            return getListResponse;
        }
    }
}
