using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Neighbourhoods.Commands.Delete;

public class DeleteNeighbourhoodCommand : IRequest<DeletedNeighbourhoodResponse>
{
    public Guid Id { get; set; }

    public class DeleteNeighbourhoodCommandHandler : IRequestHandler<DeleteNeighbourhoodCommand, DeletedNeighbourhoodResponse>
    {
        private readonly INeighbourhoodRepository _neighbourhoodRepository;
        private readonly IMapper _mapper;

        public DeleteNeighbourhoodCommandHandler(INeighbourhoodRepository neighbourhoodRepository, IMapper mapper)
        {
            _neighbourhoodRepository = neighbourhoodRepository;
            _mapper = mapper;
        }

        public async Task<DeletedNeighbourhoodResponse> Handle(DeleteNeighbourhoodCommand request, CancellationToken cancellationToken)
        {
            Neighbourhood neighbourhood = await _neighbourhoodRepository.GetAsync(n => n.Id == request.Id);
            await _neighbourhoodRepository.DeleteAsync(neighbourhood);
            DeletedNeighbourhoodResponse deletedNeighbourhoodRespone = _mapper.Map<DeletedNeighbourhoodResponse>(neighbourhood);
            return deletedNeighbourhoodRespone;
        }
    }
}
