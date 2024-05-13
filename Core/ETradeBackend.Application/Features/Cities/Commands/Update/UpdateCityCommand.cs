using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Cities.Commands.Update;

public class UpdateCityCommand : IRequest<UpdatedCityResponse>
{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public string Name { get; set; }

    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, UpdatedCityResponse>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public UpdateCityCommandHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedCityResponse> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            City city = await _cityRepository.GetAsync(c => c.Id == request.Id);
            city = _mapper.Map(request, city);
            await _cityRepository.UpdateAsync(city);
            UpdatedCityResponse updatedCityResponse = _mapper.Map<UpdatedCityResponse>(city);
            return updatedCityResponse;
        }
    }
}
