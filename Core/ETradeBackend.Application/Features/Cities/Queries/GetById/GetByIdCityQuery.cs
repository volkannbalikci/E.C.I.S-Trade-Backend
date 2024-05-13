using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Cities.Queries.GetById;

public class GetByIdCityQuery : IRequest<GetByIdCityResponse>
{
    public Guid Id { get; set; }

    public class GetByIdCityQueryHandler : IRequestHandler<GetByIdCityQuery, GetByIdCityResponse>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public GetByIdCityQueryHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCityResponse> Handle(GetByIdCityQuery request, CancellationToken cancellationToken)
        {
            City city = await _cityRepository.GetAsync(
                predicate: c => c.Id == request.Id,
                include: c => c.Include(c => c.Country)
                );
            GetByIdCityResponse getByIdCityResponse = _mapper.Map<GetByIdCityResponse>(city);
            return getByIdCityResponse;
        }
    }
}
