using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using Framework.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateAdvertOrders.Commands.Create;

public class CreateCorporateAdvertOrderCommand : IRequest<CreatedCorporateAdvertOrderResponse>
{
    public Guid IndividualUserId { get; set; }
    public Guid UserAddressId { get; set; }
    public string Description { get; set; }

    public class CreateCorporateAdvertOrderCommandHandler : IRequestHandler<CreateCorporateAdvertOrderCommand, CreatedCorporateAdvertOrderResponse>
    {
        private readonly ICorporateAdvertOrderRepository _corporateAdvertOrderRepository;
        private readonly ICorporateAdvertOrderItemRepository _corporateAdvertOrderItemRepository;
        private readonly IMapper _mapper;

        public CreateCorporateAdvertOrderCommandHandler(ICorporateAdvertOrderRepository corporateAdvertOrderRepository, IMapper mapper, ICorporateAdvertOrderItemRepository corporateAdvertOrderItemRepository)
        {
            _corporateAdvertOrderRepository = corporateAdvertOrderRepository;
            _mapper = mapper;
            _corporateAdvertOrderItemRepository = corporateAdvertOrderItemRepository;
        }

        public async Task<CreatedCorporateAdvertOrderResponse> Handle(CreateCorporateAdvertOrderCommand request, CancellationToken cancellationToken)
        {
            CorporateAdvertOrder corporateAdvertOrder = _mapper.Map<CorporateAdvertOrder>(request);
            corporateAdvertOrder.Id = Guid.NewGuid();
            corporateAdvertOrder.Code = $"{corporateAdvertOrder.Id.ToString()[1]}{corporateAdvertOrder.Id.ToString()[2]}_{corporateAdvertOrder.IndividualUserId.ToString()[2]}{corporateAdvertOrder.IndividualUserId.ToString()[0]}";
            foreach (var item in corporateAdvertOrder.CorporateAdvertOrderItems)
            {
                corporateAdvertOrder.TotalPrice += item.BoughtPrice * item.Amount;
            }
            await _corporateAdvertOrderRepository.AddAsync(corporateAdvertOrder);

            CreatedCorporateAdvertOrderResponse createdCorporateAdvertOrderResponse = _mapper.Map<CreatedCorporateAdvertOrderResponse>(corporateAdvertOrder);
            return createdCorporateAdvertOrderResponse;
        }
    }
}
