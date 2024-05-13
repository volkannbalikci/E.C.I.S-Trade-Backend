using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Districts.Commands.Update;

public class UpdateDistrictCommand : IRequest<UpdatedDistrictResponse>
{
    public Guid Id { get; set; }
    public Guid CityId { get; set; }
    public string Name { get; set; }

    public class UpdateDistrictCommandHandler : IRequestHandler<UpdateDistrictCommand, UpdatedDistrictResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDistrictRepository _districtRepository;

        public UpdateDistrictCommandHandler(IMapper mapper, IDistrictRepository districtRepository)
        {
            _mapper = mapper;
            _districtRepository = districtRepository;
        }

        public async Task<UpdatedDistrictResponse> Handle(UpdateDistrictCommand request, CancellationToken cancellationToken)
        {
            District district = await _districtRepository.GetAsync(d => d.Id == request.Id);
            district = _mapper.Map(request, district);
            await _districtRepository.UpdateAsync(district);
            UpdatedDistrictResponse updatedDistrictResponse = _mapper.Map<UpdatedDistrictResponse>(district);
            return updatedDistrictResponse;
        }
    }
}
