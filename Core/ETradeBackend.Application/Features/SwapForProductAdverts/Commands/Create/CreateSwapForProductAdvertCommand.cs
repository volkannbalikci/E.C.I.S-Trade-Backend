using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.SwapForProductAdverts.Commands.Create;

public class CreateSwapForProductAdvertCommand : IRequest<CreatedSwapForProductAdvertResponse>
{
    public Guid SwapAdvertId { get; set; }
    public Guid DesiredProductId { get; set; }

    public class CreateSwapForProductAdvertCommandHandler : IRequestHandler<CreateSwapForProductAdvertCommand, CreatedSwapForProductAdvertResponse>
    {
        private readonly ISwapForProductAdvertRepository _swapForProductAdvertRepository;
        private readonly IMapper _mapper;

        public CreateSwapForProductAdvertCommandHandler(ISwapForProductAdvertRepository swapForProductAdvertRepository, IMapper mapper)
        {
            _swapForProductAdvertRepository = swapForProductAdvertRepository;
            _mapper = mapper;
        }

        public async Task<CreatedSwapForProductAdvertResponse> Handle(CreateSwapForProductAdvertCommand request, CancellationToken cancellationToken)
        {
            SwapForProductAdvert swapForProductAdvert = _mapper.Map<SwapForProductAdvert>(request);
            swapForProductAdvert.Id = Guid.NewGuid();
            await _swapForProductAdvertRepository.AddAsync(swapForProductAdvert);

            CreatedSwapForProductAdvertResponse createdSwapForProductAdvertResponse = _mapper.Map<CreatedSwapForProductAdvertResponse>(swapForProductAdvert);
            return createdSwapForProductAdvertResponse;
        }
    }
}
