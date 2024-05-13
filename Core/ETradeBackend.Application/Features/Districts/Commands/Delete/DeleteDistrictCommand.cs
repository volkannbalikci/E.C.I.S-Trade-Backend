using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Districts.Commands.Delete;

public class DeleteDistrictCommand : IRequest<DeletedDistrictResponse>
{
    public Guid Id { get; set; }

    public class DeleteDistrictCommandHandler : IRequestHandler<DeleteDistrictCommand, DeletedDistrictResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDistrictRepository _districtRepository;

        public DeleteDistrictCommandHandler(IMapper mapper, IDistrictRepository districtRepository)
        {
            _mapper = mapper;
            _districtRepository = districtRepository;
        }

        public async Task<DeletedDistrictResponse> Handle(DeleteDistrictCommand request, CancellationToken cancellationToken)
        {
            District district = await _districtRepository.GetAsync(d => d.Id == request.Id);
            await _districtRepository.DeleteAsync(district);
            DeletedDistrictResponse deletedDistrictResponse = _mapper.Map<DeletedDistrictResponse>(district);
            return deletedDistrictResponse;
        }
    }
}
