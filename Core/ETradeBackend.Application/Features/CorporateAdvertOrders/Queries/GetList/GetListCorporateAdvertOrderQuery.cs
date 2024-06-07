using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using Framework.Application.Requests;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using ETradeBackend.Application.Features.CorporateAdvertOrderItems.Queries.GetList;

namespace ETradeBackend.Application.Features.CorporateAdvertOrders.Queries.GetList;

public class GetListCorporateAdvertOrderQuery : IRequest<GetListResponse<GetListCorporateAdvertOrderListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCorporateAdvertOrderQueryHandler : IRequestHandler<GetListCorporateAdvertOrderQuery, GetListResponse<GetListCorporateAdvertOrderListItemDto>>
    {
        private readonly ICorporateAdvertOrderRepository _corporateAdvertOrderRepository;
        private readonly ICorporateAdvertOrderItemRepository _corporateAdvertOrderItemRepository;
        private readonly IMapper _mapper;

        public GetListCorporateAdvertOrderQueryHandler(ICorporateAdvertOrderRepository corporateAdvertOrderRepository, IMapper mapper, ICorporateAdvertOrderItemRepository corporateAdvertOrderItemRepository)
        {
            _corporateAdvertOrderRepository = corporateAdvertOrderRepository;
            _mapper = mapper;
            _corporateAdvertOrderItemRepository = corporateAdvertOrderItemRepository;
        }

        public async Task<GetListResponse<GetListCorporateAdvertOrderListItemDto>> Handle(GetListCorporateAdvertOrderQuery request, CancellationToken cancellationToken)
        {
            Paginate<CorporateAdvertOrder> paginate = await _corporateAdvertOrderRepository.GetListByPaginateAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: c => c.Include(c => c.IndividualUser)
                .Include(c => c.UserAddress)
                .Include(c => c.UserAddress.Address)
                .Include(c => c.UserAddress.Address.Country)
                .Include(c => c.UserAddress.Address.City)
                .Include(c => c.UserAddress.Address.District)
                .Include(c => c.UserAddress.Address.Neighbourhood)
                .Include(c => c.CorporateAdvertOrderItems)
                );
            GetListResponse<GetListCorporateAdvertOrderListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListCorporateAdvertOrderListItemDto>>(paginate);
            foreach (var item in getListResponse.Items)
            {
                var _orderItems = _corporateAdvertOrderItemRepository.GetListByQueryable(
                    include: c => c.Include(c => c.CorporateAdvert).ThenInclude(c => c.Advert),
                    predicate: c => c.CorporateAdvertOrderId == item.CorporateAdvertOrderId).ToList();
                item.OrderItems = _mapper.Map<List<GetListCorporateAdvertOrderItemListItemDto>>(_orderItems);
            }
            return getListResponse;
        }
    }
}
