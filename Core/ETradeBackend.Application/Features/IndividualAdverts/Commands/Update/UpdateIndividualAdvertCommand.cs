using AutoMapper;
using ETradeBackend.Application.Features.IndividualAdverts.Commands.Create;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.IndividualAdverts.Commands.Update;

public class UpdateIndividualAdvertCommand : IRequest<UpdatedIndividualAdvertResponse>
{
    public Guid IndividualAdvertId { get; set; }
    public Guid AdvertId { get; set; }
    public Guid AddressId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool Bargain { get; set; }

    public class UpdateIndividualAdvertCommandHandler : IRequestHandler<UpdateIndividualAdvertCommand, UpdatedIndividualAdvertResponse>
    {
        private readonly IIndividualAdvertRepository _individualAdvertRepository;
        private readonly IAdvertRepository _advertRepository;
        private readonly IMapper _mapper;

        public UpdateIndividualAdvertCommandHandler(IIndividualAdvertRepository ındividualAdvertRepository, IMapper mapper, IAdvertRepository advertRepository)
        {
            _individualAdvertRepository = ındividualAdvertRepository;
            _mapper = mapper;
            _advertRepository = advertRepository;
        }

        public async Task<UpdatedIndividualAdvertResponse> Handle(UpdateIndividualAdvertCommand request, CancellationToken cancellationToken)
        {
            Advert? advert = await _advertRepository.GetAsync(a => a.Id == request.AdvertId);
            advert.Title = request.Title;
            advert.Description = request.Description;
            advert.AddressId = request.AddressId;
            await _advertRepository.UpdateAsync(advert);

            IndividualAdvert? individualAdvert = await _individualAdvertRepository.GetAsync(i => i.Id == request.IndividualAdvertId);
            individualAdvert.Bargain = request.Bargain;
            individualAdvert.Price = request.Price;
            await _individualAdvertRepository.UpdateAsync(individualAdvert);

            IndividualAdvert includedIndividualAdvert = await _individualAdvertRepository.GetAsync(
             predicate: i => i.Id == request.IndividualAdvertId,
             include: i => i.Include(i => i.Advert)
            .Include(i => i.Advert.Address.Country)
            .Include(i => i.Advert.Address.City)
            .Include(i => i.Advert.Address.District)
            .Include(i => i.Advert.Address.Neighbourhood)
            .Include(i => i.Advert.Product.Brand)
            .Include(i => i.Advert.Product.Category)
            .Include(i => i.IndividualUser),
            cancellationToken: cancellationToken
            );

            UpdatedIndividualAdvertResponse updatedIndividualAdvertResponse = _mapper.Map<UpdatedIndividualAdvertResponse>(includedIndividualAdvert);
            return updatedIndividualAdvertResponse;
        }
    }
}
