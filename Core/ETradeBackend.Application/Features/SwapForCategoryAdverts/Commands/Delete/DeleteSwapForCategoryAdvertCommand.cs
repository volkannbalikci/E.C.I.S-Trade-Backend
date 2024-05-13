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

    public class DeleteSwapForCategoryAdvertCommandHandler : IRequestHandler<DeleteSwapForCategoryAdvertCommand, DeletedSwapForCategoryAdvertResponse>
    {
        private readonly ISwapForCategoryAdvertRepository _swapForCategoryAdvertRepository;
        private readonly IMapper _mapper;

        public DeleteSwapForCategoryAdvertCommandHandler(ISwapForCategoryAdvertRepository swapForCategoryAdvertRepository, IMapper mapper)
        {
            _swapForCategoryAdvertRepository = swapForCategoryAdvertRepository;
            _mapper = mapper;
        }

        public async Task<DeletedSwapForCategoryAdvertResponse> Handle(DeleteSwapForCategoryAdvertCommand request, CancellationToken cancellationToken)
        {
            SwapForCategoryAdvert swapForCategoryAdvert = await _swapForCategoryAdvertRepository.GetAsync(s => s.Id == request.SwapForCategoryAdvertId);
            await _swapForCategoryAdvertRepository.DeleteAsync(swapForCategoryAdvert);

            DeletedSwapForCategoryAdvertResponse deletedSwapForCategoryAdvertResponse = _mapper.Map<DeletedSwapForCategoryAdvertResponse>(swapForCategoryAdvert);
            return deletedSwapForCategoryAdvertResponse;
        }
    }
}
