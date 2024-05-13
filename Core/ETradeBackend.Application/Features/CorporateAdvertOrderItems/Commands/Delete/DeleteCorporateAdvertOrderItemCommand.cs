using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateAdvertOrderItems.Commands.Delete;

public class DeleteCorporateAdvertOrderItemCommand : IRequest<DeletedCorporateAdvertOrderItemResponse>
{
    public Guid Id { get; set; }

    public class DeleteCorporateAdvertOrderItemCommandHandler : IRequestHandler<DeleteCorporateAdvertOrderItemCommand, DeletedCorporateAdvertOrderItemResponse>
    {
        private readonly ICorporateAdvertOrderItemRepository _corporateAdvertOrderItemRepository;
        private readonly IMapper _mapper;

        public DeleteCorporateAdvertOrderItemCommandHandler(ICorporateAdvertOrderItemRepository corporateAdvertOrderItemRepository, IMapper mapper)
        {
            _corporateAdvertOrderItemRepository = corporateAdvertOrderItemRepository;
            _mapper = mapper;
        }

        public async Task<DeletedCorporateAdvertOrderItemResponse> Handle(DeleteCorporateAdvertOrderItemCommand request, CancellationToken cancellationToken)
        {
            CorporateAdvertOrderItem corporateAdvertOrderItem = await _corporateAdvertOrderItemRepository.GetAsync(c => c.Id == request.Id);
            await _corporateAdvertOrderItemRepository.DeleteAsync(corporateAdvertOrderItem);

            DeletedCorporateAdvertOrderItemResponse deletedCorporateAdvertOrderItemResponse = _mapper.Map<DeletedCorporateAdvertOrderItemResponse>(request);
            return deletedCorporateAdvertOrderItemResponse;
        }
    }
}
