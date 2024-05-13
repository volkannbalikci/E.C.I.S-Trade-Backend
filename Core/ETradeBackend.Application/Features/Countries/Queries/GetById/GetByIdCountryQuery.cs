using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Countries.Queries.GetById
{
    public class GetByIdCountryQuery : IRequest<GetByIdCountryResponse>
    {
        public Guid Id { get; set; }

        public class GetByIdCountryQueryHandler : IRequestHandler<GetByIdCountryQuery, GetByIdCountryResponse>
        {
            private readonly ICountryRepository _countryRepository;
            private readonly IMapper _mapper;

            public GetByIdCountryQueryHandler(ICountryRepository countryRepository, IMapper mapper)
            {
                _countryRepository = countryRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdCountryResponse> Handle(GetByIdCountryQuery request, CancellationToken cancellationToken)
            {
                Country country = await _countryRepository.GetAsync(
                    predicate: c => c.Id == request.Id,
                    cancellationToken: cancellationToken
                    );
                GetByIdCountryResponse getByIdCountryResponse = _mapper.Map<GetByIdCountryResponse>(country);
                return getByIdCountryResponse;
            }
        }
    }
}
