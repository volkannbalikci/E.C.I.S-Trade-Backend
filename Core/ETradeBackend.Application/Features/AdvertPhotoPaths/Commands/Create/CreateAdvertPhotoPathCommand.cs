using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.AdvertPhotoPaths.Commands.Create;

public class CreateAdvertPhotoPathCommand : IRequest<CreatedAdvertPhotoPathResponse>
{
    public Guid AdvertId { get; set; }
    public string PhotoPath { get; set; }

    public class CreateAdvertPhotoPathCommandHandler : IRequestHandler<CreateAdvertPhotoPathCommand, CreatedAdvertPhotoPathResponse>
    {
        private readonly IAdvertPhotoPathRepository _advertPhotoPathRepository;
        private readonly IMapper _mapper;

        public CreateAdvertPhotoPathCommandHandler(IAdvertPhotoPathRepository advertPhotoPathRepository, IMapper mapper)
        {
            _advertPhotoPathRepository = advertPhotoPathRepository;
            _mapper = mapper;
        }

        public async Task<CreatedAdvertPhotoPathResponse> Handle(CreateAdvertPhotoPathCommand request, CancellationToken cancellationToken)
        {
            AdvertPhotoPath advertPhotoPath = _mapper.Map<AdvertPhotoPath>(request);
            advertPhotoPath.Id = Guid.NewGuid();
            await _advertPhotoPathRepository.AddAsync(advertPhotoPath);
            CreatedAdvertPhotoPathResponse createdAdvertPhotoPathResponse = _mapper.Map<CreatedAdvertPhotoPathResponse>(advertPhotoPath);
            return createdAdvertPhotoPathResponse;
        }
    }
}
