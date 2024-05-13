using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Cities.Commands.Delete;

public class DeleteCityCommand : IRequest<DeletedCityResponse>
{
    public Guid Id { get; set; }

    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, DeletedCityResponse>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public DeleteCityCommandHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<DeletedCityResponse> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            City city = await _cityRepository.GetAsync(c => c.Id == request.Id);
            await _cityRepository.DeleteAsync(city);
            DeletedCityResponse deletedCityResponse = _mapper.Map<DeletedCityResponse>(city);
            return deletedCityResponse;
        }
    }
}
