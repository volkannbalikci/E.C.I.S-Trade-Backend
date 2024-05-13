using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.IndividualAdverts.Commands.Create;

public class CreateIndividualAdvertCommand : IRequest<CreatedIndividualAdvertResponse>
{
    public Guid AddressId { get; set; }
    public Guid ProductId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid IndividualUserId { get; set; }
    public decimal Price { get; set; }
    public bool Bargain { get; set; }

    public class CreateIndividualAdvertCommandHandler : IRequestHandler<CreateIndividualAdvertCommand, CreatedIndividualAdvertResponse>
    {
        private readonly IAdvertRepository _advertRepository;
        private readonly IIndividualAdvertRepository _ındividualAdvertRepository;
        private readonly IMapper _mapper;

        public CreateIndividualAdvertCommandHandler(IIndividualAdvertRepository ındividualAdvertRepository, IMapper mapper, IAdvertRepository advertRepository)
        {
            _ındividualAdvertRepository = ındividualAdvertRepository;
            _mapper = mapper;
            _advertRepository = advertRepository;
        }

        public async Task<CreatedIndividualAdvertResponse> Handle(CreateIndividualAdvertCommand request, CancellationToken cancellationToken)
        {
            Advert advert = _mapper.Map<Advert>(request);
            advert.Id = Guid.NewGuid();
            await _advertRepository.AddAsync(advert);

            IndividualAdvert individualAdvert = _mapper.Map<IndividualAdvert>(request);
            individualAdvert.Id = Guid.NewGuid();
            individualAdvert.AdvertId = advert.Id;
            await _ındividualAdvertRepository.AddAsync(individualAdvert);

            CreatedIndividualAdvertResponse createdIndividualAdvertResponse = _mapper.Map<CreatedIndividualAdvertResponse>(request);
            createdIndividualAdvertResponse.AdvertId = advert.Id;
            createdIndividualAdvertResponse.IndividualAdvertId = individualAdvert.Id;
            return createdIndividualAdvertResponse;
        }
    }
}
