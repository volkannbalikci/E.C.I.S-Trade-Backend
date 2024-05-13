using AutoMapper;
using ETradeBackend.Application.Features.CorporateAdvertOrders.Queries.GetList;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateAdvertOrders.Queries.GetById;

public class GetByIdCorporateAdvertOrderQuery : IRequest<GetByIdCorporateAdvertOrderResponse>
{
    public Guid Id { get; set; }

    public class GetByIdCorporateAdvertOrderQueryHandler : IRequestHandler<GetByIdCorporateAdvertOrderQuery, GetByIdCorporateAdvertOrderResponse>
    {
        private readonly ICorporateAdvertOrderRepository _corporateAdvertOrderRepository;
        private readonly ICorporateAdvertOrderItemRepository _corporateAdvertOrderItemRepository;
        private readonly IMapper _mapper;

        public GetByIdCorporateAdvertOrderQueryHandler(ICorporateAdvertOrderRepository corporateAdvertOrderRepository, ICorporateAdvertOrderItemRepository corporateAdvertOrderItemRepository, IMapper mapper)
        {
            _corporateAdvertOrderRepository = corporateAdvertOrderRepository;
            _corporateAdvertOrderItemRepository = corporateAdvertOrderItemRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCorporateAdvertOrderResponse> Handle(GetByIdCorporateAdvertOrderQuery request, CancellationToken cancellationToken)
        {
            CorporateAdvertOrder corporateAdvertOrder = await _corporateAdvertOrderRepository.GetAsync(
                predicate: c => c.Id == request.Id,
                include: c => c.Include(c => c.IndividualUser)
                .Include(c => c.UserAddress)
                .Include(c => c.UserAddress.Address)
                .Include(c => c.UserAddress.Address.Country)
                .Include(c => c.UserAddress.Address.City)
                .Include(c => c.UserAddress.Address.District)
                .Include(c => c.UserAddress.Address.Neighbourhood)
                .Include(c => c.CorporateAdvertOrderItems),
                cancellationToken: cancellationToken
                );

            GetByIdCorporateAdvertOrderResponse getByIdCorporateAdvertOrderResponse = _mapper.Map<GetByIdCorporateAdvertOrderResponse>(corporateAdvertOrder);

            getByIdCorporateAdvertOrderResponse.OrderItems = _corporateAdvertOrderItemRepository.GetListByQueryable(predicate: c => c.CorporateAdvertOrderId == corporateAdvertOrder.Id).ToList();
            return getByIdCorporateAdvertOrderResponse;
        }
    }
}
