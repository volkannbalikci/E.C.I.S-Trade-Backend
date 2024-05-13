using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateAdvertOrderItems.Commands.Update;

public class UpdateCorporateAdvertOrderItemCommand : IRequest<UpdatedCorporateAdvertOrderItemResponse>
{
    public Guid Id { get; set; }
    public int Amount { get; set; }
    public decimal BoughtPrice { get; set; }

    public class UpdateCorporateAdvertOrderItemCommandHandler : IRequestHandler<UpdateCorporateAdvertOrderItemCommand, UpdatedCorporateAdvertOrderItemResponse>
    {
        private readonly ICorporateAdvertOrderItemRepository _corporateAdvertOrderItemRepository;
        private readonly IMapper _mapper;
        public UpdateCorporateAdvertOrderItemCommandHandler(ICorporateAdvertOrderItemRepository corporateAdvertOrderItemRepository, IMapper mapper)
        {
            _corporateAdvertOrderItemRepository = corporateAdvertOrderItemRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedCorporateAdvertOrderItemResponse> Handle(UpdateCorporateAdvertOrderItemCommand request, CancellationToken cancellationToken)
        {
            CorporateAdvertOrderItem corporateAdvertOrderItem = await _corporateAdvertOrderItemRepository.GetAsync(c => c.Id == request.Id);
            corporateAdvertOrderItem = _mapper.Map(request, corporateAdvertOrderItem);
            await _corporateAdvertOrderItemRepository.UpdateAsync(corporateAdvertOrderItem);

            UpdatedCorporateAdvertOrderItemResponse updatedCorporateAdvertOrderItemResponse = _mapper.Map<UpdatedCorporateAdvertOrderItemResponse>(corporateAdvertOrderItem);
            return updatedCorporateAdvertOrderItemResponse; 
        }
    }
}
