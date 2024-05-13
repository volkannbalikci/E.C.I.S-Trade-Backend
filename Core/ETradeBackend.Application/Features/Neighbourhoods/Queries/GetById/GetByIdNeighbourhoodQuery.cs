using AutoMapper;
using ETradeBackend.Application.Features.Districts.Queries.GetById;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Neighbourhoods.Queries.GetById;

public class GetByIdNeighbourhoodQuery : IRequest<GetByIdNeighbourhoodResponse>
{
    public Guid Id { get; set; }

    public class GetByIdNeighbourhoodQueryHandler : IRequestHandler<GetByIdNeighbourhoodQuery, GetByIdNeighbourhoodResponse>
    {
        private readonly INeighbourhoodRepository _neighbourhoodRepository;
        private readonly IMapper _mapper;

        public GetByIdNeighbourhoodQueryHandler(INeighbourhoodRepository neighbourhoodRepository, IMapper mapper)
        {
            _neighbourhoodRepository = neighbourhoodRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdNeighbourhoodResponse> Handle(GetByIdNeighbourhoodQuery request, CancellationToken cancellationToken)
        {
            Neighbourhood neighbourhood = await _neighbourhoodRepository.GetAsync(
                predicate: d => d.Id == request.Id,
                cancellationToken: cancellationToken
                );
            GetByIdNeighbourhoodResponse getByIdNeighbourhoodResponse= _mapper.Map<GetByIdNeighbourhoodResponse>(neighbourhood);
            return getByIdNeighbourhoodResponse;
        }
    }
}

