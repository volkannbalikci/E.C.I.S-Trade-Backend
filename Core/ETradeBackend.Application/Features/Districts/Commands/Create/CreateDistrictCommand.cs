using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Districts.Commands.Create;

public class CreateDistrictCommand : IRequest<CreatedDistrictResponse>
{
    public Guid CityId { get; set; }
    public string Name { get; set; }

    public class CreateDistrictCommandHandler : IRequestHandler<CreateDistrictCommand, CreatedDistrictResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDistrictRepository _districtRepository;

        public CreateDistrictCommandHandler(IMapper mapper, IDistrictRepository districtRepository)
        {
            _mapper = mapper;
            _districtRepository = districtRepository;
        }

        public async Task<CreatedDistrictResponse> Handle(CreateDistrictCommand request, CancellationToken cancellationToken)
        {
            District district = _mapper.Map<District>(request);
            district.Id = Guid.NewGuid();
            await _districtRepository.AddAsync(district);
            CreatedDistrictResponse createdDistrictResponse = _mapper.Map<CreatedDistrictResponse>(district);
            return createdDistrictResponse;
        }
    }
}
