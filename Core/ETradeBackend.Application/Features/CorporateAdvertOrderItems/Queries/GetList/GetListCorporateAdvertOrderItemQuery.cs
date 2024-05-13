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
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateAdvertOrderItems.Queries.GetList;

public class GetListCorporateAdvertOrderItemQuery : IRequest<GetListResponse<GetListCorporateAdvertOrderItemListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCorporateAdvertOrderItemQueryHandler : IRequestHandler<GetListCorporateAdvertOrderItemQuery, GetListResponse<GetListCorporateAdvertOrderItemListItemDto>>
    {
        private readonly ICorporateAdvertOrderItemRepository _corporateAdvertOrderItemRepository;
        private readonly IMapper _mapper;

        public GetListCorporateAdvertOrderItemQueryHandler(ICorporateAdvertOrderItemRepository corporateAdvertOrderItemRepository, IMapper mapper)
        {
            _corporateAdvertOrderItemRepository = corporateAdvertOrderItemRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCorporateAdvertOrderItemListItemDto>> Handle(GetListCorporateAdvertOrderItemQuery request, CancellationToken cancellationToken)
        {
            Paginate<CorporateAdvertOrderItem> paginate = await _corporateAdvertOrderItemRepository.GetListByPaginateAsync(
                include: c => c.Include(c => c.CorporateAdvert.Advert),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
                );
            GetListResponse<GetListCorporateAdvertOrderItemListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListCorporateAdvertOrderItemListItemDto>>(paginate);
            return getListResponse;
        }
    }
}
