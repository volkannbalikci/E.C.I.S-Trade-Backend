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
    public Guid AdvertId { get; set; }
    public Guid IndividualUserId { get; set; }

    public class CreateSwapAdvertCommandHandler : IRequestHandler<CreateSwapAdvertCommand, CreatedSwapAdvertResponse>
    {
        private readonly ISwapAdvertRepository _swapAdvertRepository;
        private readonly IMapper _mapper;

        public CreateSwapAdvertCommandHandler(ISwapAdvertRepository swapAdvertRepository, IMapper mapper)
        {
            _swapAdvertRepository = swapAdvertRepository;
            _mapper = mapper;
        }

        public async Task<CreatedSwapAdvertResponse> Handle(CreateSwapAdvertCommand request, CancellationToken cancellationToken)
        {
            SwapAdvert swapAdvert = _mapper.Map<SwapAdvert>(request);
            swapAdvert.Id = Guid.NewGuid();
            await _swapAdvertRepository.AddAsync(swapAdvert);

            CreatedSwapAdvertResponse createdSwapAdvertResponse = _mapper.Map<CreatedSwapAdvertResponse>(request);
            return createdSwapAdvertResponse;
        }
    }
}
