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
    public Guid Id { get; set; }

    public class DeleteSwapForProductAdvertCommandHandler : IRequestHandler<DeleteSwapForProductAdvertCommand, DeletedSwapForProductAdvertResponse>
    {
        private readonly ISwapForProductAdvertRepository _swapForProductAdvertRepository;
        private readonly IMapper _mapper;

        public DeleteSwapForProductAdvertCommandHandler(ISwapForProductAdvertRepository swapForProductAdvertRepository, IMapper mapper)
        {
            _swapForProductAdvertRepository = swapForProductAdvertRepository;
            _mapper = mapper;
        }

        public async Task<DeletedSwapForProductAdvertResponse> Handle(DeleteSwapForProductAdvertCommand request, CancellationToken cancellationToken)
        {
            SwapForProductAdvert? swapForProductAdvert = await _swapForProductAdvertRepository.GetAsync(s => s.Id == request.Id);
            await _swapForProductAdvertRepository.DeleteAsync(swapForProductAdvert);

            DeletedSwapForProductAdvertResponse deletedSwapForProductAdvertResponse = _mapper.Map<DeletedSwapForProductAdvertResponse>(swapForProductAdvert);
            return deletedSwapForProductAdvertResponse;
        }
    }
}
