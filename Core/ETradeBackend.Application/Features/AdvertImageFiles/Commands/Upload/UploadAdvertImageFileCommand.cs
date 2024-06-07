using ETradeBackend.Application.Abstractions.Storage;
using ETradeBackend.Application.Services.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.AdvertImageFiles.Commands.Upload;

public class UploadAdvertImageFileCommand : IRequest<UploadAdvertImageFileResponse>
{
    public Guid AdvertId { get; set; }

    public IFormFileCollection? Files { get; set; }

    public class UploadAdvertImageFileCommandHandler : IRequestHandler<UploadAdvertImageFileCommand, UploadAdvertImageFileResponse>
    {
        readonly IStorageService _storageService;
        readonly IAdvertRepository _advertRepository;
        readonly IAdvertImageFileRepository _advertImageFileRepository;
        public UploadAdvertImageFileCommandHandler(IStorageService storageService, IAdvertRepository productReadRepository, IAdvertImageFileRepository productImageFileWriteRepository)
        {
            _storageService = storageService;
            _advertRepository = productReadRepository;
            _advertImageFileRepository = productImageFileWriteRepository;
        }

        public async Task<UploadAdvertImageFileResponse> Handle(UploadAdvertImageFileCommand request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-images", request.Files);


            await _advertImageFileRepository.AddRangeAsync(result.Select(r => new Domain.Entities.AdvertImageFile
            {
                FileName = r.fileName,
                Path = r.pathOrContainerName,
                Storage = _storageService.StorageName,
                AdvertId = request.AdvertId
            }).ToList());

            return new();
        }
    }
}
