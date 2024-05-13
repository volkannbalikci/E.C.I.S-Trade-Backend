using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.AdvertPhotoPaths.Commands.Update;

public class UpdateAdvertPhotoPathCommand : IRequest<UpdatedAdvertPhotoPathResponse>
{
    public Guid Id { get; set; }
    public Guid AdvertId { get; set; }
    public string PhotoPath { get; set; }

    public class UpdateAdvertPhotoPathCommandHandler : IRequestHandler<UpdateAdvertPhotoPathCommand, UpdatedAdvertPhotoPathResponse>
    {
        private readonly IAdvertPhotoPathRepository _advertPhotoPathRepository;
        private readonly IMapper _mapper;

        public UpdateAdvertPhotoPathCommandHandler(IAdvertPhotoPathRepository advertPhotoPathRepository, IMapper mapper)
        {
            _advertPhotoPathRepository = advertPhotoPathRepository;
            _mapper = mapper;
        }
        public async Task<UpdatedAdvertPhotoPathResponse> Handle(UpdateAdvertPhotoPathCommand request, CancellationToken cancellationToken)
        {
            AdvertPhotoPath? advertPhotoPath = await _advertPhotoPathRepository.GetAsync(p => p.Id == request.Id);
            advertPhotoPath = _mapper.Map(request, advertPhotoPath);
            await _advertPhotoPathRepository.UpdateAsync(advertPhotoPath);
            UpdatedAdvertPhotoPathResponse updatedAdvertPhotoPathResponse = _mapper.Map<UpdatedAdvertPhotoPathResponse>(advertPhotoPath);
            return updatedAdvertPhotoPathResponse;
        }
    }
}
