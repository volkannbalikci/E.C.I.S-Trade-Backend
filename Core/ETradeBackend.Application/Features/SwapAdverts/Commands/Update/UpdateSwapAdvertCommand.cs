using AutoMapper;
using ETradeBackend.Application.Features.IndividualAdverts.Commands.Update;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.SwapAdverts.Commands.Update;

public class UpdateSwapAdvertCommand : IRequest<UpdatedSwapAdvertResponse>
{
    public Guid SwapAdvertId { get; set; }
    public Guid AdvertId { get; set; }
    public Guid AddressId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public class UpdateSwapAdvertCommandHandler : IRequestHandler<UpdateSwapAdvertCommand, UpdatedSwapAdvertResponse>
    {
        private readonly ISwapAdvertRepository _swapAdvertRepository;
        private readonly IAdvertRepository _advertRepository;
        private readonly IMapper _mapper;

        public UpdateSwapAdvertCommandHandler(IAdvertRepository advertRepository, IMapper mapper, ISwapAdvertRepository swapAdvertRepository)
        {
            _advertRepository = advertRepository;
            _mapper = mapper;
            _swapAdvertRepository = swapAdvertRepository;
        }

        public async Task<UpdatedSwapAdvertResponse> Handle(UpdateSwapAdvertCommand request, CancellationToken cancellationToken)
        {
            Advert? advert = await _advertRepository.GetAsync(a => a.Id == request.AdvertId);
            advert.Title = request.Title;
            advert.Description = request.Description;
            advert.AddressId = request.AddressId;
            await _advertRepository.UpdateAsync(advert);

            SwapAdvert? includedSwapAdvert = await _swapAdvertRepository.GetAsync(
            predicate: i => i.Id == request.SwapAdvertId,
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

            UpdatedSwapAdvertResponse updatedSwapAdvertResponse = _mapper.Map<UpdatedSwapAdvertResponse>(includedSwapAdvert);
            return updatedSwapAdvertResponse;
        }
    }
}
