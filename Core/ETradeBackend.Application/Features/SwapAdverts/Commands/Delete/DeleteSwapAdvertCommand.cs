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
    public Guid Id { get; set; }

    public class DeleteSwapAdvertCommandHandler : IRequestHandler<DeleteSwapAdvertCommand, DeletedSwapAdvertResponse>
    {
        private readonly ISwapAdvertRepository _swapAdvertRepository;
        private readonly IMapper _mapper;

        public DeleteSwapAdvertCommandHandler(ISwapAdvertRepository swapAdvertRepository, IMapper mapper)
        {
            _swapAdvertRepository = swapAdvertRepository;
            _mapper = mapper;
        }

        public async Task<DeletedSwapAdvertResponse> Handle(DeleteSwapAdvertCommand request, CancellationToken cancellationToken)
        {
            SwapAdvert? swapAdvert = await _swapAdvertRepository.GetAsync(s => s.Id == request.Id);
            await _swapAdvertRepository.DeleteAsync(swapAdvert);

            DeletedSwapAdvertResponse deletedSwapAdvertResponse = _mapper.Map<DeletedSwapAdvertResponse>(request);
            return deletedSwapAdvertResponse;
        }
    }
}
