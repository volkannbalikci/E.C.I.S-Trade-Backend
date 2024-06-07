using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.SwapForProductAdverts.Commands.Create;

public class CreateSwapForProductAdvertCommand : IRequest<CreatedSwapForProductAdvertResponse>
{
    public Guid IndividualUserId { get; set; }
    public Guid AddressId { get; set; }
    public Guid ProductId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid DesiredProductId { get; set; }

    public class CreateSwapForProductAdvertCommandHandler : IRequestHandler<CreateSwapForProductAdvertCommand, CreatedSwapForProductAdvertResponse>
    {
        private readonly ISwapForProductAdvertRepository _swapForProductAdvertRepository;
        private readonly IAdvertRepository _advertRepository;
        private readonly ISwapAdvertRepository _swapAdvertRepository;
        private readonly IMapper _mapper;

        public CreateSwapForProductAdvertCommandHandler(ISwapForProductAdvertRepository swapForProductAdvertRepository, IMapper mapper, IAdvertRepository advertRepository, ISwapAdvertRepository swapAdvertRepository)
        {
            _swapForProductAdvertRepository = swapForProductAdvertRepository;
            _mapper = mapper;
            _advertRepository = advertRepository;
            _swapAdvertRepository = swapAdvertRepository;
        }

        public async Task<CreatedSwapForProductAdvertResponse> Handle(CreateSwapForProductAdvertCommand request, CancellationToken cancellationToken)
        {
            Advert advert = _mapper.Map<Advert>(request);
            advert.Id = Guid.NewGuid();
            await _advertRepository.AddAsync(advert);

            SwapAdvert swapAdvert = _mapper.Map<SwapAdvert>(request);
            swapAdvert.Id = Guid.NewGuid();
            swapAdvert.AdvertId = advert.Id;
            await _swapAdvertRepository.AddAsync(swapAdvert);

            SwapForProductAdvert swapForProductAdvert = _mapper.Map<SwapForProductAdvert>(request);
            swapForProductAdvert.Id = Guid.NewGuid();
            swapForProductAdvert.SwapAdvertId = swapAdvert.Id;
            await _swapForProductAdvertRepository.AddAsync(swapForProductAdvert);

            CreatedSwapForProductAdvertResponse createdSwapForProductAdvertResponse = _mapper.Map<CreatedSwapForProductAdvertResponse>(swapForProductAdvert);
            return createdSwapForProductAdvertResponse;
        }
    }
}
