using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.IndividualAdverts.Commands.Delete;

public class DeleteIndividualAdvertCommand : IRequest<DeletedIndividualAdvertResponse>
{
    public Guid IndividualAdvertId { get; set; }
    public Guid AdvertId { get; set; }

    public class DeleteIndividualAdvertCommandHandler : IRequestHandler<DeleteIndividualAdvertCommand, DeletedIndividualAdvertResponse>
    {
        private readonly IIndividualAdvertRepository _ındividualAdvertRepository;
        private readonly IAdvertRepository _advertRepository;
        private readonly IMapper _mapper;

        public DeleteIndividualAdvertCommandHandler(IIndividualAdvertRepository ındividualAdvertRepository, IAdvertRepository advertRepository, IMapper mapper)
        {
            _ındividualAdvertRepository = ındividualAdvertRepository;
            _advertRepository = advertRepository;
            _mapper = mapper;
        }

        public async Task<DeletedIndividualAdvertResponse> Handle(DeleteIndividualAdvertCommand request, CancellationToken cancellationToken)
        {
            IndividualAdvert individualAdvert = await _ındividualAdvertRepository.GetAsync(i => i.Id == request.IndividualAdvertId);
            await _ındividualAdvertRepository.DeleteAsync(individualAdvert);

            Advert advert = await _advertRepository.GetAsync(a => a.Id == request.AdvertId);
            await _advertRepository.DeleteAsync(advert);

            DeletedIndividualAdvertResponse deletedIndividualAdvertResponse = _mapper.Map<DeletedIndividualAdvertResponse>(individualAdvert);
            deletedIndividualAdvertResponse.AdvertId = request.AdvertId;
            return deletedIndividualAdvertResponse;
        }
    }
}
