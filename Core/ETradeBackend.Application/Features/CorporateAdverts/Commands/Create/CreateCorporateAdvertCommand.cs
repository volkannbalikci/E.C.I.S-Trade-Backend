using AutoMapper;
using ETradeBackend.Application.Abstractions.Storage;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateAdverts.Commands.Create;

public class CreateCorporateAdvertCommand : IRequest<CreatedCorporateAdvertResponse>
{
    public Guid AddressId { get; set; }
    public Guid ProductId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CorporateUserId { get; set; }
    public decimal UnitPrice { get; set; }
    public int StockAmount { get; set; }
    public IFormFileCollection? Files { get; set; }

    public class CreateCorporateAdvertCommandHandler : IRequestHandler<CreateCorporateAdvertCommand, CreatedCorporateAdvertResponse>
    {
        private readonly ICorporateAdvertRepository _corporateAdvertRepository;
        private readonly IAdvertRepository _advertRepository;
        readonly IStorageService _storageService;
        readonly IAdvertImageFileRepository _advertImageFileRepository;
        private readonly IMapper _mapper;

        public CreateCorporateAdvertCommandHandler(ICorporateAdvertRepository corporateAdvertRepository, IAdvertRepository advertRepository, IMapper mapper, IStorageService storageService, IAdvertImageFileRepository advertImageFileRepository)
        {
            _corporateAdvertRepository = corporateAdvertRepository;
            _advertRepository = advertRepository;
            _mapper = mapper;
            _storageService = storageService;
            _advertImageFileRepository = advertImageFileRepository;
        }

        public async Task<CreatedCorporateAdvertResponse> Handle(CreateCorporateAdvertCommand request, CancellationToken cancellationToken)
        {
            Advert advert = _mapper.Map<Advert>(request);
            advert.Id = Guid.NewGuid();
            await _advertRepository.AddAsync(advert);

            List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-images", request.Files);


            await _advertImageFileRepository.AddRangeAsync(result.Select(r => new Domain.Entities.AdvertImageFile
            {
                FileName = r.fileName,
                Path = r.pathOrContainerName,
                Storage = _storageService.StorageName,
                AdvertId = advert.Id
            }).ToList());

            CorporateAdvert corporateAdvert = _mapper.Map<CorporateAdvert>(request);
            corporateAdvert.Id = Guid.NewGuid();
            corporateAdvert.AdvertId = advert.Id;
            await _corporateAdvertRepository.AddAsync(corporateAdvert);

            CreatedCorporateAdvertResponse createdCorporateAdvertResponse = _mapper.Map<CreatedCorporateAdvertResponse>(request);
            createdCorporateAdvertResponse.AdvertId = advert.Id;
            createdCorporateAdvertResponse.CorporateAdvertId = corporateAdvert.Id;
            return createdCorporateAdvertResponse;
        }
    }
}
