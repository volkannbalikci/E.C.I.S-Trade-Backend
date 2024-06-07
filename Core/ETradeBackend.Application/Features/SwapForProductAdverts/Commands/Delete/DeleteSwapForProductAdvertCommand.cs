using AutoMapper;
using ETradeBackend.Application.Features.SwapForProductAdverts.Commands.Create;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.SwapForProductAdverts.Commands.Delete;

public class DeleteSwapForProductAdvertCommand : IRequest<DeletedSwapForProductAdvertResponse>
{
    public Guid SwapForProductAdvertId { get; set; }
    public Guid SwapAdvertId { get; set; }
    public Guid AdvertId { get; set; }

    public class DeleteSwapForProductAdvertCommandHandler : IRequestHandler<DeleteSwapForProductAdvertCommand, DeletedSwapForProductAdvertResponse>
    {
        private readonly ISwapForProductAdvertRepository _swapForProductAdvertRepository;
        private readonly ISwapAdvertRepository _swapAdvertRepository;
        private readonly IAdvertRepository _advertRepository;
        private readonly IMapper _mapper;

        public DeleteSwapForProductAdvertCommandHandler(ISwapForProductAdvertRepository swapForProductAdvertRepository, IMapper mapper, ISwapAdvertRepository swapAdvertRepository, IAdvertRepository advertRepository)
        {
            _swapForProductAdvertRepository = swapForProductAdvertRepository;
            _mapper = mapper;
            _swapAdvertRepository = swapAdvertRepository;
            _advertRepository = advertRepository;
        }

        public async Task<DeletedSwapForProductAdvertResponse> Handle(DeleteSwapForProductAdvertCommand request, CancellationToken cancellationToken)
        {
            SwapForProductAdvert? swapForProductAdvert = await _swapForProductAdvertRepository.GetAsync(s => s.Id == request.SwapForProductAdvertId);
            await _swapForProductAdvertRepository.DeleteAsync(swapForProductAdvert); 
            
            SwapAdvert? swapAdvert = await _swapAdvertRepository.GetAsync(s => s.Id == request.SwapAdvertId);
            await _swapAdvertRepository.DeleteAsync(swapAdvert);  
            
            Advert? advert = await _advertRepository.GetAsync(s => s.Id == request.AdvertId);
            await _advertRepository.DeleteAsync(advert);

            DeletedSwapForProductAdvertResponse deletedSwapForProductAdvertResponse = _mapper.Map<DeletedSwapForProductAdvertResponse>(swapForProductAdvert);
            return deletedSwapForProductAdvertResponse;
        }
    }
}
