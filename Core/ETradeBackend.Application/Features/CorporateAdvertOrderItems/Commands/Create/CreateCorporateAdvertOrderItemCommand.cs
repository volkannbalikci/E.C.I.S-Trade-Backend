using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateAdvertOrderItems.Commands.Create;

public class CreateCorporateAdvertOrderItemCommand : IRequest<CreatedCorporateAdvertOrderItemResponse>
{
    public Guid CorporateAdvertOrderId { get; set; }
    public Guid CorporateAdvertId { get; set; }
    public int Amount { get; set; }
    public decimal BoughtPrice { get; set; }

    public class CreateCorporateAdvertOrderItemCommandHandler : IRequestHandler<CreateCorporateAdvertOrderItemCommand, CreatedCorporateAdvertOrderItemResponse>
    {
        private readonly ICorporateAdvertOrderItemRepository _corporateAdvertOrderItemRepository;
        private readonly ICorporateAdvertRepository _corporateAdvertRepository;
        private readonly IMapper _mapper;

        public CreateCorporateAdvertOrderItemCommandHandler(ICorporateAdvertOrderItemRepository corporateAdvertOrderItemRepository, IMapper mapper, ICorporateAdvertRepository corporateAdvertRepository)
        {
            _corporateAdvertOrderItemRepository = corporateAdvertOrderItemRepository;
            _mapper = mapper;
            _corporateAdvertRepository = corporateAdvertRepository;
        }

        public async Task<CreatedCorporateAdvertOrderItemResponse> Handle(CreateCorporateAdvertOrderItemCommand request, CancellationToken cancellationToken)
        {
            CorporateAdvertOrderItem corporateAdvertOrderItem = _mapper.Map<CorporateAdvertOrderItem>(request);
            corporateAdvertOrderItem.Id = Guid.NewGuid();

            CorporateAdvert corporateAdvert = await _corporateAdvertRepository.GetAsync(c => c.Id == request.CorporateAdvertId);
            corporateAdvertOrderItem.BoughtPrice = corporateAdvert.UnitPrice;
            await _corporateAdvertOrderItemRepository.AddAsync(corporateAdvertOrderItem);

            CreatedCorporateAdvertOrderItemResponse createdCorporateAdvertOrderItemResponse = _mapper.Map<CreatedCorporateAdvertOrderItemResponse>(request);
            return createdCorporateAdvertOrderItemResponse;   
        }
    }
}
