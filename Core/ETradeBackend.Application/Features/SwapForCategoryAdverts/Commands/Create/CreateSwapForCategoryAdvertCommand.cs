using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.SwapForCategoryAdverts.Commands.Create;

public class CreateSwapForCategoryAdvertCommand : IRequest<CreatedSwapForCategoryAdvertResponse>
{
    public Guid IndividualUserId { get; set; }
    public Guid DesiredCategoryId { get; set; }
    public Guid AddressId { get; set; }
    public Guid ProductId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public class CreateSwapForCategoryAdvertCommandHandler : IRequestHandler<CreateSwapForCategoryAdvertCommand, CreatedSwapForCategoryAdvertResponse>
    {
        private readonly ISwapForCategoryAdvertRepository _swapForCategoryAdvertRepository;
        private readonly IAdvertRepository _advertRepository;
        private readonly ISwapAdvertRepository _swapAdvertRepository;
        private readonly IMapper _mapper;

        public CreateSwapForCategoryAdvertCommandHandler(ISwapForCategoryAdvertRepository swapForCategoryAdvertRepository, IMapper mapper, IAdvertRepository productRepository, ISwapAdvertRepository swapAdvertRepository)
        {
            _swapForCategoryAdvertRepository = swapForCategoryAdvertRepository;
            _mapper = mapper;
            _advertRepository = productRepository;
            _swapAdvertRepository = swapAdvertRepository;
        }

        public async Task<CreatedSwapForCategoryAdvertResponse> Handle(CreateSwapForCategoryAdvertCommand request, CancellationToken cancellationToken)
        {
            Advert advert = _mapper.Map<Advert>(request);
            advert.Id = Guid.NewGuid();
            await _advertRepository.AddAsync(advert);

            SwapAdvert swapAdvert = _mapper.Map<SwapAdvert>(request);
            swapAdvert.Id = Guid.NewGuid();
            swapAdvert.AdvertId = advert.Id;
            _swapAdvertRepository.AddAsync(swapAdvert);

            SwapForCategoryAdvert swapForCategoryAdvert = _mapper.Map<SwapForCategoryAdvert>(request);
            swapForCategoryAdvert.Id = Guid.NewGuid();
            swapForCategoryAdvert.SwapAdvertId = swapAdvert.Id;
            await _swapForCategoryAdvertRepository.AddAsync(swapForCategoryAdvert);

            CreatedSwapForCategoryAdvertResponse createdSwapForCategoryAdvertResponse = _mapper.Map<CreatedSwapForCategoryAdvertResponse>(swapForCategoryAdvert);
            return createdSwapForCategoryAdvertResponse;
        }
    }
}
