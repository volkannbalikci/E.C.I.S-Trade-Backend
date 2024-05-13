using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Neighbourhoods.Commands.Create;

public class CreateNeighbourhoodCommand : IRequest<CreatedNeighbourhoodResponse>
{
    public Guid DistrictId { get; set; }
    public string Name { get; set; }

    public class CreateNeighbourhoodCommandHandler : IRequestHandler<CreateNeighbourhoodCommand, CreatedNeighbourhoodResponse>
    {
        private readonly INeighbourhoodRepository _neighbourhoodRepository;
        private readonly IMapper _mapper;

        public CreateNeighbourhoodCommandHandler(INeighbourhoodRepository neighbourhoodRepository, IMapper mapper)
        {
            _neighbourhoodRepository = neighbourhoodRepository;
            _mapper = mapper;
        }

        public async Task<CreatedNeighbourhoodResponse> Handle(CreateNeighbourhoodCommand request, CancellationToken cancellationToken)
        {
            Neighbourhood neighbourhood = _mapper.Map<Neighbourhood>(request);
            neighbourhood.Id = Guid.NewGuid();
            await _neighbourhoodRepository.AddAsync(neighbourhood);
            CreatedNeighbourhoodResponse createdNeighbourhoodResponse = _mapper.Map<CreatedNeighbourhoodResponse>(neighbourhood);
            return createdNeighbourhoodResponse;
        }
    }
}
