using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.SwapAdverts.Commands.Delete;

public class DeleteSwapAdvertCommand : IRequest<DeletedSwapAdvertResponse>
{
    public Guid SwapAdvertId { get; set; }
    public Guid AdvertId { get; set; }

    public class DeleteSwapAdvertCommandHandler : IRequestHandler<DeleteSwapAdvertCommand, DeletedSwapAdvertResponse>
    {
        private readonly ISwapAdvertRepository _swapAdvertRepository;
        private readonly IAdvertRepository _advertRepository;
        private readonly IMapper _mapper;

        public DeleteSwapAdvertCommandHandler(ISwapAdvertRepository swapAdvertRepository, IMapper mapper, IAdvertRepository advertRepository)
        {
            _swapAdvertRepository = swapAdvertRepository;
            _mapper = mapper;
            _advertRepository = advertRepository;
        }

        public async Task<DeletedSwapAdvertResponse> Handle(DeleteSwapAdvertCommand request, CancellationToken cancellationToken)
        {
            SwapAdvert? swapAdvert = await _swapAdvertRepository.GetAsync(s => s.Id == request.SwapAdvertId);
            await _swapAdvertRepository.DeleteAsync(swapAdvert);

            Advert? advert = await _advertRepository.GetAsync(a => a.Id == request.AdvertId);
            await _advertRepository.DeleteAsync(advert);

            DeletedSwapAdvertResponse deletedSwapAdvertResponse = _mapper.Map<DeletedSwapAdvertResponse>(request);
            return deletedSwapAdvertResponse;
        }
    }
}
