using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Districts.Queries.GetById;

public class GetByIdDistrictQuery : IRequest<GetByIdDistrictResponse>
{
    public Guid Id { get; set; }

    public class GetByIdDistrictQueryHandler : IRequestHandler<GetByIdDistrictQuery, GetByIdDistrictResponse>
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IMapper _mapper;

        public GetByIdDistrictQueryHandler(IDistrictRepository districtRepository, IMapper mapper)
        {
            _districtRepository = districtRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdDistrictResponse> Handle(GetByIdDistrictQuery request, CancellationToken cancellationToken)
        {
            District district = await _districtRepository.GetAsync(
                predicate: d => d.Id == request.Id,
                cancellationToken: cancellationToken
                );
            GetByIdDistrictResponse getByIdDistrictResponse = _mapper.Map<GetByIdDistrictResponse>(district);
            return getByIdDistrictResponse;
        }
    }
}
