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
    public Guid SwapAdvertId { get; set; }
    public Guid DesiredCategoryId { get; set; }

    public class CreateSwapForCategoryAdvertCommandHandler : IRequestHandler<CreateSwapForCategoryAdvertCommand, CreatedSwapForCategoryAdvertResponse>
    {
        private readonly ISwapForCategoryAdvertRepository _swapForCategoryAdvertRepository;
        private readonly IMapper _mapper;

        public CreateSwapForCategoryAdvertCommandHandler(ISwapForCategoryAdvertRepository swapForCategoryAdvertRepository, IMapper mapper)
        {
            _swapForCategoryAdvertRepository = swapForCategoryAdvertRepository;
            _mapper = mapper;
        }

        public async Task<CreatedSwapForCategoryAdvertResponse> Handle(CreateSwapForCategoryAdvertCommand request, CancellationToken cancellationToken)
        {
            SwapForCategoryAdvert swapForCategoryAdvert = _mapper.Map<SwapForCategoryAdvert>(request);
            swapForCategoryAdvert.Id = Guid.NewGuid();
            await _swapForCategoryAdvertRepository.AddAsync(swapForCategoryAdvert);

            CreatedSwapForCategoryAdvertResponse createdSwapForCategoryAdvertResponse = _mapper.Map<CreatedSwapForCategoryAdvertResponse>(swapForCategoryAdvert);
            return createdSwapForCategoryAdvertResponse;
        }
    }
}
