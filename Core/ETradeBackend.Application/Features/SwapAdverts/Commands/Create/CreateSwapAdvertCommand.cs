using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.SwapAdverts.Commands.Create;

public class CreateSwapAdvertCommand : IRequest<CreatedSwapAdvertResponse>
{
    public Guid AddressId { get; set; }
    public Guid ProductId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid IndividualUserId { get; set; }

    public class CreateSwapAdvertCommandHandler : IRequestHandler<CreateSwapAdvertCommand, CreatedSwapAdvertResponse>
    {
        private readonly ISwapAdvertRepository _swapAdvertRepository;
        private readonly IAdvertRepository _advertRepository;
        private readonly IMapper _mapper;

        public CreateSwapAdvertCommandHandler(ISwapAdvertRepository swapAdvertRepository, IMapper mapper, IAdvertRepository advertRepository)
        {
            _swapAdvertRepository = swapAdvertRepository;
            _mapper = mapper;
            _advertRepository = advertRepository;
        }

        public async Task<CreatedSwapAdvertResponse> Handle(CreateSwapAdvertCommand request, CancellationToken cancellationToken)
        {
            Advert advert = _mapper.Map<Advert>(request);
            advert.Id = Guid.NewGuid();
            await _advertRepository.AddAsync(advert);

            SwapAdvert swapAdvert = _mapper.Map<SwapAdvert>(request);
            swapAdvert.Id = Guid.NewGuid();
            swapAdvert.AdvertId = advert.Id;
            await _swapAdvertRepository.AddAsync(swapAdvert);

            CreatedSwapAdvertResponse createdSwapAdvertResponse = _mapper.Map<CreatedSwapAdvertResponse>(request);
            return createdSwapAdvertResponse;
        }
    }
}
