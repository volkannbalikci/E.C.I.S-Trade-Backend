using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Neighbourhoods.Commands.Update;

public class UpdateNeighbourhoodCommand : IRequest<UpdatedNeighbourhoodResponse>
{
    public Guid Id { get; set; }
    public Guid DistrictId { get; set; }
    public string Name { get; set; }

    public class UpdateNeighbourhoodCommandHandler : IRequestHandler<UpdateNeighbourhoodCommand, UpdatedNeighbourhoodResponse>
    {
        private readonly INeighbourhoodRepository _neighbourhoodRepository;
        private readonly IMapper _mapper;

        public UpdateNeighbourhoodCommandHandler(INeighbourhoodRepository neighbourhoodRepository, IMapper mapper)
        {
            _neighbourhoodRepository = neighbourhoodRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedNeighbourhoodResponse> Handle(UpdateNeighbourhoodCommand request, CancellationToken cancellationToken)
        {
            Neighbourhood neighbourhood = await _neighbourhoodRepository.GetAsync(n => n.Id == request.Id);
            neighbourhood = _mapper.Map(request, neighbourhood);
            await _neighbourhoodRepository.UpdateAsync(neighbourhood);
            UpdatedNeighbourhoodResponse updatedNeighbourhoodResponse = _mapper.Map<UpdatedNeighbourhoodResponse>(neighbourhood);
            return updatedNeighbourhoodResponse;
        }
    }
}
