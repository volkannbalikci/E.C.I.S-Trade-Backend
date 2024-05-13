using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateAdverts.Commands.Delete;

public class DeleteCorporateAdvertCommand : IRequest<DeletedCorporateAdvertResponse>
{
    public Guid CorporateAdvertId { get; set; }
    public Guid AdvertId { get; set; }

    public class DeleteCorporateAdvertCommandHandler : IRequestHandler<DeleteCorporateAdvertCommand, DeletedCorporateAdvertResponse>
    {
        private readonly ICorporateAdvertRepository _corporateAdvertRepository;
        private readonly IAdvertRepository _advertRepository;
        private readonly IMapper _mapper;

        public DeleteCorporateAdvertCommandHandler(ICorporateAdvertRepository corporateAdvertRepository, IMapper mapper, IAdvertRepository advertRepository)
        {
            _corporateAdvertRepository = corporateAdvertRepository;
            _mapper = mapper;
            _advertRepository = advertRepository;
        }

        public async Task<DeletedCorporateAdvertResponse> Handle(DeleteCorporateAdvertCommand request, CancellationToken cancellationToken)
        {
            CorporateAdvert corporateAdvert = await _corporateAdvertRepository.GetAsync(c => c.Id == request.CorporateAdvertId);
            await _corporateAdvertRepository.DeleteAsync(corporateAdvert);

            Advert advert = await _advertRepository.GetAsync(a => a.Id == request.AdvertId);
            await _advertRepository.DeleteAsync(advert);

            DeletedCorporateAdvertResponse deletedCorporateAdvertResponse = _mapper.Map<DeletedCorporateAdvertResponse>(corporateAdvert);
            deletedCorporateAdvertResponse.AdvertId = request.AdvertId;
            return deletedCorporateAdvertResponse;
        }
    }
}
