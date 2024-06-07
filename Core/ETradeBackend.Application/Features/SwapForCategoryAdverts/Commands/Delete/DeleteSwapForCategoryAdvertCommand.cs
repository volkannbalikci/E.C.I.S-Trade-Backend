using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.SwapForCategoryAdverts.Commands.Delete;

public class DeleteSwapForCategoryAdvertCommand : IRequest<DeletedSwapForCategoryAdvertResponse>
{
    public Guid SwapForCategoryAdvertId { get; set; }
    public Guid SwapAdvertId { get; set; }
    public Guid AdvertId { get; set; }

    public class DeleteSwapForCategoryAdvertCommandHandler : IRequestHandler<DeleteSwapForCategoryAdvertCommand, DeletedSwapForCategoryAdvertResponse>
    {
        private readonly ISwapForCategoryAdvertRepository _swapForCategoryAdvertRepository;
        private readonly ISwapAdvertRepository _swapAdvertRepository;
        private readonly IAdvertRepository _advertRepository;
        private readonly IMapper _mapper;

        public DeleteSwapForCategoryAdvertCommandHandler(ISwapForCategoryAdvertRepository swapForCategoryAdvertRepository, IMapper mapper, ISwapAdvertRepository swapAdvertRepository, IAdvertRepository advertRepository)
        {
            _swapForCategoryAdvertRepository = swapForCategoryAdvertRepository;
            _mapper = mapper;
            _swapAdvertRepository = swapAdvertRepository;
            _advertRepository = advertRepository;
        }

        public async Task<DeletedSwapForCategoryAdvertResponse> Handle(DeleteSwapForCategoryAdvertCommand request, CancellationToken cancellationToken)
        {
            SwapForCategoryAdvert swapForCategoryAdvert = await _swapForCategoryAdvertRepository.GetAsync(s => s.Id == request.SwapForCategoryAdvertId);
            await _swapForCategoryAdvertRepository.DeleteAsync(swapForCategoryAdvert);

            SwapAdvert swapAdvert = await _swapAdvertRepository.GetAsync(s => s.Id == request.SwapAdvertId);
            await _swapAdvertRepository.DeleteAsync(swapAdvert);

            Advert advert = await _advertRepository.GetAsync(s => s.Id == request.AdvertId);
            await _advertRepository.DeleteAsync(advert);

            DeletedSwapForCategoryAdvertResponse deletedSwapForCategoryAdvertResponse = _mapper.Map<DeletedSwapForCategoryAdvertResponse>(swapForCategoryAdvert);
            return deletedSwapForCategoryAdvertResponse;
        }
    }
}
