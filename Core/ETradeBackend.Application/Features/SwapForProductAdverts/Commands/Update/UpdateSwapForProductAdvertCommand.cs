using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.SwapForProductAdverts.Commands.Update;

public class UpdateSwapForProductAdvertCommand :IRequest<UpdatedSwapForProductAdvertResponse>
{
    public Guid SwapForProductAdvertId { get; set; }
    public Guid DesiredProductId { get; set; }

    public Guid AddressId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }


    public class UpdateSwapForProductAdvertCommandHandler : IRequestHandler<UpdateSwapForProductAdvertCommand, UpdatedSwapForProductAdvertResponse>
    {
        private readonly ISwapForProductAdvertRepository _swapForProductAdvertRepository;
        private readonly ISwapAdvertRepository _swapAdvertRepository;
        private readonly IAdvertRepository _advertRepository;
        private readonly IMapper _mapper;

        public UpdateSwapForProductAdvertCommandHandler(ISwapForProductAdvertRepository swapForProductAdvertRepository, IMapper mapper, IAdvertRepository advertRepository, ISwapAdvertRepository swapAdvertRepository)
        {
            _swapForProductAdvertRepository = swapForProductAdvertRepository;
            _mapper = mapper;
            _advertRepository = advertRepository;
            _swapAdvertRepository = swapAdvertRepository;
        }

        public async Task<UpdatedSwapForProductAdvertResponse> Handle(UpdateSwapForProductAdvertCommand request, CancellationToken cancellationToken)
        {
            SwapForProductAdvert? swapForProductAdvert = await _swapForProductAdvertRepository.GetAsync(s => s.Id == request.SwapForProductAdvertId);
            swapForProductAdvert = _mapper.Map(request, swapForProductAdvert);
            await _swapForProductAdvertRepository.UpdateAsync(swapForProductAdvert);

            SwapAdvert swapAdvert = await _swapAdvertRepository.GetAsync(s => s.Id == swapForProductAdvert.SwapAdvertId);
            swapAdvert = _mapper.Map(request, swapAdvert);

            Advert advert = await _advertRepository.GetAsync(a => a.Id == swapAdvert.AdvertId);
            advert = _mapper.Map(request, advert);
            await _advertRepository.UpdateAsync(advert);

            SwapForProductAdvert includedSwapForProductAdvert = await _swapForProductAdvertRepository.GetAsync(
                predicate: s => s.Id == request.SwapForProductAdvertId,
                            include: i => i.Include(i => i.SwapAdvert.Advert)
           .Include(i => i.SwapAdvert.Advert.Address.Country)
           .Include(i => i.SwapAdvert.Advert.Address.City)
           .Include(i => i.SwapAdvert.Advert.Address.District)
           .Include(i => i.SwapAdvert.Advert.Address.Neighbourhood)
           .Include(i => i.SwapAdvert.Advert.Product)
           .Include(i => i.SwapAdvert.Advert.Product.Brand)
           .Include(i => i.SwapAdvert.Advert.Product.Category)
           .Include(i => i.SwapAdvert.IndividualUser)
           .Include(i => i.DesiredProduct)
           .Include(i => i.DesiredProduct.Brand)
           .Include(i => i.DesiredProduct.Category),
           cancellationToken: cancellationToken
                );

            UpdatedSwapForProductAdvertResponse updatedSwapForProductAdvertResponse = _mapper.Map<UpdatedSwapForProductAdvertResponse>(includedSwapForProductAdvert);
            return updatedSwapForProductAdvertResponse;
        }
    }

}
