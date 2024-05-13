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

namespace ETradeBackend.Application.Features.SwapForCategoryAdverts.Commands.Update;

public class UpdateSwapForCategoryAdvertCommand : IRequest<UpdatedSwapForCategoryAdvertResponse>
{
    public Guid SwapForCategoryAdvertId { get; set; }
    public Guid DesiredCategoryId { get; set; }

    public Guid AddressId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public class UpdateSwapForCategoryAdvertCommandHandler : IRequestHandler<UpdateSwapForCategoryAdvertCommand, UpdatedSwapForCategoryAdvertResponse>
    {
        private readonly ISwapForCategoryAdvertRepository _swapForCategoryAdvertRepository;
        private readonly ISwapAdvertRepository _swapAdvertRepository;
        private readonly IAdvertRepository _advertRepository;
        private readonly IMapper _mapper;

        public UpdateSwapForCategoryAdvertCommandHandler(ISwapForCategoryAdvertRepository swapForCategoryAdvertRepository, IMapper mapper, ISwapAdvertRepository swapAdvertRepository, IAdvertRepository advertRepository)
        {
            _swapForCategoryAdvertRepository = swapForCategoryAdvertRepository;
            _mapper = mapper;
            _swapAdvertRepository = swapAdvertRepository;
            _advertRepository = advertRepository;
        }

        public async Task<UpdatedSwapForCategoryAdvertResponse> Handle(UpdateSwapForCategoryAdvertCommand request, CancellationToken cancellationToken)
        {
            SwapForCategoryAdvert swapForCategoryAdvert = await _swapForCategoryAdvertRepository.GetAsync(s => s.Id == request.SwapForCategoryAdvertId);
            swapForCategoryAdvert = _mapper.Map(request, swapForCategoryAdvert);
            await _swapForCategoryAdvertRepository.UpdateAsync(swapForCategoryAdvert);

            SwapAdvert swapAdvert = await _swapAdvertRepository.GetAsync(s => s.Id == swapForCategoryAdvert.SwapAdvertId);
            swapAdvert = _mapper.Map(request, swapAdvert);

            Advert advert = await _advertRepository.GetAsync(a => a.Id == swapAdvert.AdvertId);
            advert = _mapper.Map(request, advert);
            await _advertRepository.UpdateAsync(advert);

            SwapForCategoryAdvert includedSwapForCategoryAdvert = await _swapForCategoryAdvertRepository.GetAsync(
               predicate: s => s.Id == request.SwapForCategoryAdvertId,
                           include: i => i.Include(i => i.SwapAdvert.Advert)
          .Include(i => i.SwapAdvert.Advert.Address.Country)
          .Include(i => i.SwapAdvert.Advert.Address.City)
          .Include(i => i.SwapAdvert.Advert.Address.District)
          .Include(i => i.SwapAdvert.Advert.Address.Neighbourhood)
          .Include(i => i.SwapAdvert.Advert.Product)
          .Include(i => i.SwapAdvert.Advert.Product.Brand)
          .Include(i => i.SwapAdvert.Advert.Product.Category)
          .Include(i => i.SwapAdvert.IndividualUser)
          .Include(i => i.DesiredCategory),
          cancellationToken: cancellationToken
               );

            UpdatedSwapForCategoryAdvertResponse updatedSwapForCategoryAdvertResponse = _mapper.Map<UpdatedSwapForCategoryAdvertResponse>(includedSwapForCategoryAdvert);
            return updatedSwapForCategoryAdvertResponse;
        }
    }
}
